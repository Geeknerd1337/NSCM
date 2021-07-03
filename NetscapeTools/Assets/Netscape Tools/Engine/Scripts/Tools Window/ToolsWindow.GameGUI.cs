#if UNITY_EDITOR

using System.Diagnostics;
using UnityEngine;
using UnityEditor;

namespace Armadillo.Netscape
{
	public partial class ToolsWindow : EditorWindow
	{
		private void GameGUI()
		{
			GUILayout.Label("Game Loader", ToolsStyles.Title);
			EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

			/* // Dont do crap if steam isnt valid
			if (!Steamworks.SteamClient.IsValid)
			{
				GUILayout.Label("Steam not connected!", ToolsStyles.SubTitle);
				return;
			} */

			GUILayout.BeginVertical(ToolsStyles.Panel);
			{
				GUILayout.Label("Netscape Install Path: ");
				GUILayout.BeginHorizontal();
				{
					EditorGUI.BeginDisabledGroup(true);
					{
						GUILayout.TextField(ContentTesting.GameInstallPath, EditorStyles.textField, GUILayout.MaxWidth(Screen.width - (128 + 32)));
					}
					EditorGUI.EndDisabledGroup();
					if (GUILayout.Button("Set Install", GUILayout.Width(96)))
					{
						ContentTesting.SetInstallPath();
					}
				}
				GUILayout.EndHorizontal();

				if (GUILayout.Button("Launch Game", GUILayout.Height(24)))
				{
					ContentTesting.LaunchNetscape();
				}
			}
			GUILayout.EndVertical();

			// Test Content
			GUILayout.BeginVertical(ToolsStyles.Panel);
			{
				GUILayout.Button("Content To Test", EditorStyles.popup);
				GUILayout.Button("Test Content");
			}
			GUILayout.EndVertical();
		}
	}
}

#endif