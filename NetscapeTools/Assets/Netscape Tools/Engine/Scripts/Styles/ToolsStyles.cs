#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;

namespace Armadillo.Netscape
{
	public class ToolsStyles
	{
		public static readonly GUIStyle Title = new GUIStyle("Label")
		{
			fontSize = 24,
			richText = true
		};

		public static readonly GUIStyle SubTitle = new GUIStyle("Label")
		{
			fontSize = 18
		};

		public static readonly GUIStyle Panel = new GUIStyle("Box")
		{
			padding = new RectOffset(6, 6, 6, 6)
		};

		public static readonly GUIStyle TextField = new GUIStyle(EditorStyles.textField)
		{
			richText = true,
			alignment = TextAnchor.MiddleLeft,
			fontSize = 12,
			wordWrap = true,
			padding = new RectOffset(8, 0, 0, 0)
		};

		public static readonly GUIStyle TextFieldGhost = new GUIStyle("Label")
		{
			richText = true,
			alignment = TextAnchor.MiddleLeft,
			fontSize = 12,
			fontStyle = FontStyle.Bold,
			wordWrap = true,
			padding = new RectOffset(8, 0, 0, 0)
		};
	}
}

#endif