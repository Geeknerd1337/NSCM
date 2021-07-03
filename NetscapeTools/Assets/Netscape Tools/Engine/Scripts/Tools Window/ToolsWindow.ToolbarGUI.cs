#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;

namespace Armadillo.Netscape
{
	public partial class ToolsWindow : EditorWindow
	{
		private static int currentSelectedToolbar
		{
			get { return EditorPrefs.GetInt("NetscapeTools.CurrentToolbar", 0); }
			set { EditorPrefs.SetInt("NetscapeTools.CurrentToolbar", value); }
		}

		private void ToolbarGUI()
		{
			var style = new GUIStyle(EditorStyles.miniButtonMid)
			{
				richText = true,
				fixedHeight = 0
			};

			var toolbarRect = new Rect(16, 32 / 2, Screen.width - 32, 20);
			currentSelectedToolbar = GUI.SelectionGrid(toolbarRect, currentSelectedToolbar, new GUIContent[] { new GUIContent("Info"), new GUIContent("Game"), new GUIContent("Compiler")/* , new GUIContent("Workshop") */ }, 5, style);

			if (GUI.Button(new Rect(toolbarRect) { width = toolbarRect.width / 6, x = toolbarRect.width - (toolbarRect.width / 6) + 16 }, new GUIContent("About", EditorGUIUtility.IconContent("_Help@2x").image), style))
			{
				AboutWindow.ShowWindow();
			}

			GUILayout.Space((toolbarRect.height));
		}
	}
}

#endif