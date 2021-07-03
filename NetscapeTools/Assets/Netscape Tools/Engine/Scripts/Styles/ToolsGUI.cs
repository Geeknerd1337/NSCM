#if UNITY_EDITOR

using System;
using UnityEditor;
using UnityEngine;

namespace Armadillo.Netscape
{
	public class ToolsGUI
	{
		public static string GhostedTextField(string text, bool allowSpaces = true, string ghostedText = "Ghost")
		{
			return GhostedTextField(new GUIContent(text), new RectOffset(8, 0, 0, 0), allowSpaces, ghostedText, 26, 12, TextAnchor.MiddleLeft);
		}

		public static string GhostedTextField(string text, bool allowSpaces = true, string ghostedText = "Ghost", float height = 26, int textSize = 12, TextAnchor textAnchor = TextAnchor.MiddleLeft)
		{
			return GhostedTextField(new GUIContent(text), new RectOffset(8, 0, 0, 0), allowSpaces, ghostedText, height, textSize, textAnchor);
		}

		public static string GhostedTextField(GUIContent text, RectOffset padding, bool allowSpaces = true, string ghostedText = "Ghost", float height = 26, int textSize = 12, TextAnchor textAnchor = TextAnchor.MiddleLeft)
		{
			return GhostedTextField(new GUIContent(text), new RectOffset(8, 0, 0, 0), allowSpaces, ghostedText, textSize, textAnchor, GUILayout.Height(height));
		}

		public static string GhostedTextField(GUIContent text, RectOffset padding, bool allowSpaces = true, string ghostedText = "Ghost", int textSize = 12, TextAnchor textAnchor = TextAnchor.MiddleLeft, params GUILayoutOption[] layoutOptions)
		{
			var style = new GUIStyle(ToolsStyles.TextField) { fontSize = textSize, alignment = textAnchor, padding = padding };

			EditorGUI.BeginChangeCheck();
			var textProcess = EditorGUILayout.TextField(text.text, style, layoutOptions);

			// Remove Spaces from text name
			if (EditorGUI.EndChangeCheck() && !allowSpaces)
				textProcess = string.Join("", text.text.Split(default(string[]), System.StringSplitOptions.RemoveEmptyEntries));

			if (string.IsNullOrEmpty(text.text))
				GUI.Label(GUILayoutUtility.GetLastRect(), $"<color=grey>{ghostedText}</color>", new GUIStyle(ToolsStyles.TextFieldGhost) { fontSize = textSize, alignment = textAnchor, padding = padding });

			return textProcess;
		}
	}
}

#endif