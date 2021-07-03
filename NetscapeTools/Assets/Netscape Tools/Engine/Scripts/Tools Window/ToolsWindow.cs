#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;

namespace Armadillo.Netscape
{
	public partial class ToolsWindow : EditorWindow
	{
		[MenuItem("Netscape Tools/Tools Window"), MenuItem("Window/Netscape Tools/Tools")]
		private static void ShowWindow()
		{
			var window = GetWindow<ToolsWindow>();
			window.titleContent = new GUIContent("Netscape Tools");
			window.minSize = new Vector2(500, 450);
			window.Show();
		}

/* 		private void OnEnable()
		{
			// SteamManager.GetAvatar();

			if (WorkshopItems.UploadNewItem)
				cachedThumbnail = IconCache.NoThumbnail;
		}
 */
		private static Vector2 scrollView;
		private void OnGUI()
		{
			ToolbarGUI();
			GUILayout.Space(15);
			GUILayout.BeginVertical(new GUIStyle(EditorStyles.helpBox) { padding = new RectOffset(12, 12, 8, 8), margin = new RectOffset(8, 8, 0, 0) });
			{
				scrollView = GUILayout.BeginScrollView(scrollView);
				{
					switch (currentSelectedToolbar)
					{
						case 0:
							InfoGUI();
							break;
						case 1:
							GameGUI();
							break;
						case 2:
							CompilerGUI();
							break;
						case 3:
							WorkshopGUI();
							break;
					}
				}
				GUILayout.EndScrollView();
				GUILayout.FlexibleSpace();
			}
			GUILayout.EndVertical();
			GUILayout.Space(8);
			// UserCardGUI();
		}
	}
}

#endif