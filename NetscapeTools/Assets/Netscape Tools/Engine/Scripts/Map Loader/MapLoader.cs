#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;

static class MapLoader
{
	[MenuItem("Netscape Tools/Load Map")]
	private static void LoadMap()
	{
		var assetBundle = AssetBundle.LoadFromFile(EditorUtility.OpenFilePanel("Map File - \"Typically .map\"", "", ""));
		UnityEngine.SceneManagement.SceneManager.LoadScene(assetBundle.GetAllScenePaths()[0]);
	}
}

#endif