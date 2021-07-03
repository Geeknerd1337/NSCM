#if UNITY_EDITOR

using Steamworks;
using UnityEngine;
using UnityEditor;

namespace Armadillo.Netscape
{
	public partial class SteamManager
	{
		public const uint AppId = 480;

		// [InitializeOnLoadMethod]
		public static void Initialize()
		{
			try
			{
				SteamClient.Init(AppId);
			}
			catch (System.Exception e)
			{
				Debug.Log(e);
				EditorUtility.DisplayDialog("Steam Failed to Connect!", "Look in console for more details", "Okay!");
			}

			if (!SteamClient.IsValid) { return; }
			GetAvatar();
			GetStats();

			WorkshopItems.GetWorkshopItems();
		}
	}
}

#endif