#if UNITY_EDITOR

using System.IO;

using UnityEngine;
using UnityEditor;

namespace Armadillo.Netscape
{
	public static class ToolsUtility
	{
		public static void DirectoryCheck(string path)
		{
			if (!Directory.Exists(path))
				Directory.CreateDirectory(path);
		}

		public static void ClearAllAssetBundleNames()
		{
			foreach (var item in AssetDatabase.GetAllAssetBundleNames())
			{
				AssetDatabase.RemoveAssetBundleName(item, true);
			}
		}

		public static void DeleteAllFilesWithExtensionAtPath(string path, string extension)
		{
			foreach (var item in Directory.GetFiles(Path.GetFullPath(path), $"*.{extension}"))
			{
				File.Delete(item);
			}
		}
	}
}

#endif