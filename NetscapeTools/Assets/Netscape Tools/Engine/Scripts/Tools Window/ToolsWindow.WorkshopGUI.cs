#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;

namespace Armadillo.Netscape
{
	public partial class ToolsWindow : EditorWindow
	{
		public static string cachedName;
		public static string cachedDesc;
		public static string cachedChangelog;
		public static string[] cachedTags;
		public static Texture cachedThumbnail;

		private void WorkshopGUI()
		{
			GUILayout.Label("Workshop Uploader", ToolsStyles.Title);
			EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

			// Dont do crap if steam isnt valid
			if (!Steamworks.SteamClient.IsValid)
			{
				GUILayout.Label("Steam not connected!", ToolsStyles.SubTitle);
				return;
			}

			GUILayout.BeginVertical(ToolsStyles.Panel);
			{
				GUILayout.BeginHorizontal();
				{
					var content = WorkshopItems.UploadNewItem ? new GUIContent("Upload new Item?") : new GUIContent(WorkshopItems.CurrentItem.Title);
					var style = new GUIStyle(EditorStyles.popup) { fixedHeight = 0 };

					var rect = GUILayoutUtility.GetRect(content, style, GUILayout.Height(20));
					if (GUI.Button(rect, content, style))
					{
						var dropdown = new WorkshopItemsList(new UnityEditor.IMGUI.Controls.AdvancedDropdownState());
						dropdown.Show(rect);
					}

					if (!WorkshopItems.UploadNewItem)
						if (GUILayout.Button("View", GUILayout.Width(96), GUILayout.Height(20)))
						{
							Application.OpenURL(WorkshopItems.CurrentItem.Url);
						}
				}
				GUILayout.EndHorizontal();

				GUILayout.Space(4);

				GUILayout.BeginHorizontal(GUILayout.Height(128));
				{
					GUILayout.BeginVertical(GUILayout.Width(128));
					{
						GUILayout.Button(new GUIContent(cachedThumbnail, "Button To Change Thumbnail"), GUILayout.Height(128), GUILayout.Width(128));
					}
					GUILayout.EndVertical();
					GUILayout.BeginVertical();
					{
						EditorGUI.BeginDisabledGroup(!WorkshopItems.UploadNewItem);
						{
							cachedName = ToolsGUI.GhostedTextField(cachedName, true, "Item Name", 24);
							// cachedName = GUILayout.TextField(cachedName, new GUIStyle(EditorStyles.textField) { fontSize = 16 }, GUILayout.Height(24));

							if (WorkshopItems.UploadNewItem)
								cachedDesc = ToolsGUI.GhostedTextField(new GUIContent(cachedDesc), new RectOffset(8, 8, 8, 8), true, "Item Description", 12, TextAnchor.UpperLeft, GUILayout.MaxHeight(124 - 24));
							else
								EditorGUILayout.TextArea(cachedDesc, EditorStyles.textArea, GUILayout.MaxHeight(124 - 24));
						}
						EditorGUI.EndDisabledGroup();
					}
					GUILayout.EndVertical();
				}
				GUILayout.EndHorizontal();
			}
			GUILayout.EndVertical();

			GUILayout.BeginVertical(ToolsStyles.Panel);
			{
				WorkshopItems.ItemToUpload = EditorGUILayout.ObjectField("Content to upload", WorkshopItems.ItemToUpload, typeof(Object), false) as Object;

				EditorGUI.BeginDisabledGroup(WorkshopItems.UploadNewItem);
				{
					cachedChangelog = EditorGUILayout.TextArea(WorkshopItems.UploadNewItem ? "Created Item" : cachedChangelog, EditorStyles.textArea, GUILayout.MaxHeight(32));
				}
				EditorGUI.EndDisabledGroup();

				if (GUILayout.Button("Upload Content", GUILayout.Height(32), GUILayout.ExpandWidth(true)))
				{
					WorkshopItems.BeginWorkshopUpload();
				}
			}
			GUILayout.EndVertical();
		}
	}
}

#endif