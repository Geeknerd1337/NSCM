#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;

namespace Armadillo.Netscape
{
	public class AboutWindow : EditorWindow
	{
		public static void ShowWindow()
		{
			var window = GetWindow<AboutWindow>(true);
			window.titleContent = new GUIContent("Netscape Tools About");
			window.minSize = new Vector2(400, 200);
			window.maxSize = new Vector2(400, 200);
			window.ShowUtility();
		}

		private void OnGUI()
		{
			GUILayout.BeginVertical(new GUIStyle(EditorStyles.helpBox) { margin = new RectOffset(32, 32, 32, 32), padding = new RectOffset(8, 8, 8, 8) });
			{
				EditorGUIUtility.SetIconSize(new Vector2(128, 128));
				GUILayout.Label(new GUIContent("<size=14>Created by</size>\n<b>Jake K</b>\n<size=12>For Netscape Cybermind</size>"), new GUIStyle(ToolsStyles.Title) { alignment = TextAnchor.MiddleCenter }, GUILayout.ExpandHeight(true), GUILayout.ExpandWidth(true));
				EditorGUIUtility.SetIconSize(new Vector2(0, 0));
			}
			GUILayout.EndVertical();
		}
	}
}

#endif