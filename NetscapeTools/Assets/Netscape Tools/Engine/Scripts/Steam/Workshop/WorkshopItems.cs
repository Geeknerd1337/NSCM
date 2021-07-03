#if UNITY_EDITOR

using System.Collections.Generic;
using Steamworks.Ugc;
using UnityEngine;
using UnityEngine.Networking;

namespace Armadillo.Netscape
{
	public static partial class WorkshopItems
	{
		public static Dictionary<int, Item> ClientItems = new Dictionary<int, Item>();

		public static Item CurrentItem;

		public async static void GetWorkshopItems()
		{
			ClientItems.Clear();
			var query = Query.ItemsReadyToUse;
			query.WhereUserPublished();
			query.SortByTitleAsc();
			var page = await query.GetPageAsync(1);


			if (!page.HasValue) { return; }

			foreach (var item in page.Value.Entries)
			{
				ClientItems.Add(ClientItems.Count + 1, item);
			}
		}

		public static void GetCurrentItemThumbnail()
		{
			if (string.IsNullOrEmpty(CurrentItem.PreviewImageUrl))
			{
				ToolsWindow.cachedThumbnail = null;
				return;
			}

			var www = UnityWebRequestTexture.GetTexture(CurrentItem.PreviewImageUrl);
			var result = www.SendWebRequest();
			result.completed += FinishedImageDownload;
		}

		private static void FinishedImageDownload(AsyncOperation operation)
		{
			var www = operation as UnityWebRequestAsyncOperation;
			ToolsWindow.cachedThumbnail = ((DownloadHandlerTexture)www.webRequest.downloadHandler).texture;
		}
	}
}

#endif