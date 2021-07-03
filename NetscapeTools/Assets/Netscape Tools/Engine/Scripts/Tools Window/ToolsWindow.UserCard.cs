#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;

namespace Armadillo.Netscape
{
	public partial class ToolsWindow : EditorWindow
	{
		private void UserCardGUI()
		{
			GUILayout.BeginHorizontal(new GUIStyle(EditorStyles.helpBox) { margin = new RectOffset(8, 8, 8, 8) }, GUILayout.Height(64));
			{
				// GUILayout.Label(IconCache.NetscapeLogo, new GUIStyle("Label") { alignment = TextAnchor.MiddleLeft, richText = true, padding = new RectOffset(8, 8, 8, 8), margin = new RectOffset(12, 0, 0, 0) }, GUILayout.Height(64), GUILayout.Width(240));
				// GUILayout.Label("", new GUIStyle(GUI.skin.verticalSlider) { margin = new RectOffset(12, 12, 12, 12) }, GUILayout.ExpandHeight(true));

				GUILayout.FlexibleSpace();

				// User Information
				if (Steamworks.SteamClient.IsValid)
				{
					GUILayout.Label($"<size=13><b>{Steamworks.SteamClient.Name}</b></size><size=20>\n</size><b>{SteamManager.ClientStats.Followers}</b> Followers",
				   new GUIStyle("Label") { alignment = TextAnchor.MiddleRight, richText = true, padding = new RectOffset(8, 8, 8, 8) },
				   GUILayout.ExpandHeight(true));

					// Profile Picture
					if (GUILayout.Button(new GUIContent(SteamManager.Avatar, "Click me to go to your workshop!"), GUILayout.Height(64), GUILayout.Width(64)))
					{
						Application.OpenURL($"https://steamcommunity.com/profiles/{Steamworks.SteamClient.SteamId}/myworkshopfiles/?appid=518150");
					}
				}
				else
				{
					GUILayout.BeginVertical();
					{
						GUILayout.Label($"<b>Couldn't connect to Steam!</b>",
					   new GUIStyle("Label") { alignment = TextAnchor.MiddleRight, richText = true, padding = new RectOffset(8, 8, 8, 8) },
					   GUILayout.ExpandHeight(true));

						if (GUILayout.Button(new GUIContent("Reconnect to Steam"), GUILayout.Height(26), GUILayout.ExpandHeight(true)))
						{
							SteamManager.Initialize();
						}
					}
					GUILayout.EndVertical();
				}
			}
			GUILayout.EndHorizontal();
		}
	}
}

#endif