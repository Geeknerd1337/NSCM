#if UNITY_EDITOR

using System.IO;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEditor.SceneManagement;

namespace Armadillo.Netscape
{
	public static class Compiler
	{
		public static bool CompileLevel(Scene scene, BuildTarget[] buildTargets, bool buzz = false, bool launchGame = false)
		{
			if (!EditorSceneManager.SaveModifiedScenesIfUserWantsTo(new Scene[] { scene }))
				return false;

			var level = AssetImporter.GetAtPath(scene.path);

			ToolsUtility.DirectoryCheck($"Exports/{scene.name}/");

			foreach (var item in buildTargets)
			{
				ToolsUtility.ClearAllAssetBundleNames();

				level.assetBundleName = $"{scene.name}.map"/*  + (item == BuildTarget.StandaloneWindows ? "w" : "m") */;
				BuildPipeline.BuildAssetBundles($"Exports/{scene.name}/", BuildAssetBundleOptions.ChunkBasedCompression, item);

				ToolsUtility.ClearAllAssetBundleNames();
			}

			ToolsUtility.DeleteAllFilesWithExtensionAtPath($"Exports/{scene.name}/", "manifest");
			ToolsUtility.DeleteAllFilesWithExtensionAtPath($"Exports/{scene.name}/", "");

			AssetDatabase.Refresh();

			if (buzz)
				EditorApplication.Beep();

			if (launchGame)
				ContentTesting.LaunchNetscape(ContentTesting.LoadLevelArgs(Path.GetFullPath($"Exports/{scene.name}/{scene.name}.map")));

			return true;
		}

		public static void GetBuildTarget(string target, out BuildTarget[] targets)
		{
			// Tf why I gotta do this?!
			targets = new BuildTarget[] { BuildTarget.NoTarget };

			// I would switch this to a dictionary but no point, this is easier for now
			switch (target)
			{
				case ("OSX"):
					targets = new BuildTarget[] { BuildTarget.StandaloneOSX };
					break;

				case ("Windows"):
					targets = new BuildTarget[] { BuildTarget.StandaloneWindows64 };
					break;

				case ("Both"):
					targets = new BuildTarget[] { BuildTarget.StandaloneWindows64, BuildTarget.StandaloneOSX };
					break;

				default:
					target = null;
					break;
			}
		}
	}
}

#endif