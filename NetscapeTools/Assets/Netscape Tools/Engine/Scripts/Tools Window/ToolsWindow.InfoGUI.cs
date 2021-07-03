#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;

namespace Armadillo.Netscape
{
	public partial class ToolsWindow : EditorWindow
	{
		private void InfoGUI()
		{
			GUILayout.Label("Netscape Tools", ToolsStyles.Title);
			EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

			// Panel
			GUILayout.BeginVertical(ToolsStyles.Panel);
			{
				GUILayout.Label("What is the NetScape Tools?", ToolsStyles.SubTitle);
				GUILayout.Label("Here you will find all your tools for creating content for Netscape Cybermind\n- If you need any help be sure to click the buttons below\n- Wanna show off cool stuff you've made? Come join the Discord server", new GUIStyle("Label") { wordWrap = true }, GUILayout.ExpandHeight(true), GUILayout.ExpandWidth(true));

			}
			GUILayout.EndVertical();

			EditorGUILayout.Space();

			GUILayout.BeginVertical(ToolsStyles.Panel);
			{
				GUILayout.Label("Get Help", ToolsStyles.SubTitle);
				if (GUILayout.Button("Netscape Discord", GUILayout.Height(32)))
				{
					Application.OpenURL("https://discord.gg/sM5ZTA7");
				}
			}
			GUILayout.EndVertical();

			/* EditorGUILayout.Space();

			GUILayout.BeginVertical(ToolsStyles.Panel);
			{
				GUILayout.Label("Steam Links", ToolsStyles.SubTitle);
				if (GUILayout.Button("Community Hub", GUILayout.Height(32)))
				{
					Application.OpenURL("");
				}

				if (GUILayout.Button("Workshop", GUILayout.Height(32)))
				{
					Application.OpenURL("");
				}
			}
			GUILayout.EndVertical(); */
		}
	}
}

#endif