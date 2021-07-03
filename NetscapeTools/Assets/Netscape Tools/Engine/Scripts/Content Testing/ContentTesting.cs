#if UNITY_EDITOR

using System.Diagnostics;
using UnityEngine;
using UnityEditor;

namespace Armadillo.Netscape
{
	public static class ContentTesting
	{
		public static string GameInstallPath
		{
			get => EditorPrefs.GetString("NetscapeTools.GameInstallPath", "");
			set => EditorPrefs.SetString("NetscapeTools.GameInstallPath", value);
		}

		public static Process LaunchNetscape(string launchArgs = "")
		{
			return Process.Start(GameInstallPath, launchArgs);
		}

		public static void SetInstallPath()
		{
			GameInstallPath = EditorUtility.OpenFilePanelWithFilters("Get Netscape Install", GameInstallPath, new string[] { "Application", "exe" });
		}

		public static string LoadLevelArgs(string path)
		{
			switch (Application.platform)
			{
				case (RuntimePlatform.WindowsPlayer):
				case (RuntimePlatform.WindowsEditor):
					return $"-map \"{path}\"";

				case (RuntimePlatform.OSXPlayer):
				case (RuntimePlatform.OSXEditor):
					return $"-map \"{path}\"";

				default:
					return "";
			}
		}
	}
}

#endif