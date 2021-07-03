#if UNITY_EDITOR

using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using UnityEditor;
using Steamworks;
using Steamworks.Ugc;

namespace Armadillo.Netscape
{
	public static partial class WorkshopItems
	{
		public static bool UploadNewItem = true;
		public static Object ItemToUpload;

		public static async void BeginWorkshopUpload()
		{
			PublishResult? publishResult = null;

			if (UploadNewItem)
			{
				var item = Steamworks.Ugc.Editor.NewCommunityFile;
				item.WithTitle(ToolsWindow.cachedName);
				publishResult = await UploadWorkshopItem(new DirectoryInfo(AssetDatabase.GetAssetPath(ItemToUpload)), item);
			}

			if (!publishResult.HasValue) { return; }

			OnFinishUpload(publishResult.Value);
		}

		// Upload new workshop item
		private static async Task<PublishResult?> UploadWorkshopItem(DirectoryInfo directory, Steamworks.Ugc.Editor item)
		{
			item.WithChangeLog("Created Item");
			item.WithContent(directory);
			return await item.SubmitAsync();
		}

		// Update old workshop item
		private static async Task<PublishResult?> UploadWorkshopItem(DirectoryInfo directory, ulong id, string changeLog)
		{
			var editor = new Steamworks.Ugc.Editor(new Steamworks.Data.PublishedFileId() { Value = id });
			editor.WithContent(directory);
			editor.WithChangeLog(changeLog);
			return await editor.SubmitAsync();
		}

		private static async void OnFinishUpload(PublishResult publishResult)
		{
			var item = await Item.GetAsync(publishResult.FileId);
			await item.Value.Subscribe();
			await item.Value.Vote(true);
			await item.Value.AddFavorite();

			WorkshopItems.GetWorkshopItems();
			WorkshopItems.CurrentItem = item.Value;
			WorkshopItems.UploadNewItem = false;
		}
	}
}

#endif