#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;

namespace Armadillo.Netscape
{
	public partial class ToolsWindow : EditorWindow
	{
		private Vector2 compilerScrollView;

		public static SceneAsset cachedMap;

		public static string[] buildTargets = new string[] { "Windows", "OSX", "Both" };
		public static int buildTargetIndex;
		public static bool cachedBeep;
		public static bool cachedLoadInGame;

		private void CompilerGUI()
		{
			GUILayout.Label("Content Compiler", ToolsStyles.Title);
			EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

			GUILayout.BeginVertical(ToolsStyles.Panel);
			{
				GUILayout.Label("Map To Export", ToolsStyles.SubTitle);
				EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
				GUILayout.BeginHorizontal();
				{
					cachedMap = EditorGUILayout.ObjectField(cachedMap, typeof(SceneAsset), false, GUILayout.Height(32)) as SceneAsset;
					if (GUILayout.Button("Get Open Scene", GUILayout.Width(128), GUILayout.Height(32)))
					{
						cachedMap = AssetDatabase.LoadAssetAtPath<SceneAsset>(UnityEditor.SceneManagement.EditorSceneManager.GetActiveScene().path);
					}
				}
				GUILayout.EndHorizontal();
			}
			GUILayout.EndVertical();

			EditorGUILayout.Space();

			GUILayout.BeginVertical(ToolsStyles.Panel);
			{
				GUILayout.Label("Map Options", ToolsStyles.SubTitle);
				EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
				EditorGUILayout.Toggle(new GUIContent("Export Post Effects", "Disable this if compile times are slow"), true);
				EditorGUILayout.Toggle("Do Sanity Check", true);

				EditorGUILayout.Space();

				buildTargetIndex = EditorGUILayout.Popup("Build Target", buildTargetIndex, buildTargets);
			}
			GUILayout.EndVertical();

			EditorGUILayout.Space();

			GUILayout.BeginVertical(ToolsStyles.Panel);
			{
				GUILayout.Label("On Build Complete", ToolsStyles.SubTitle);
				EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
				cachedBeep = EditorGUILayout.Toggle("Beep on Finish", cachedBeep);
				cachedLoadInGame = EditorGUILayout.Toggle("Launch Map In Game", cachedLoadInGame);
			}
			GUILayout.EndVertical();

			EditorGUILayout.Space();

			GUILayout.BeginVertical(ToolsStyles.Panel);
			{
				if (cachedMap == null)
					EditorGUILayout.HelpBox("Need to add a map to compile!", MessageType.Error);

				EditorGUI.BeginDisabledGroup(cachedMap == null);
				{
					if (GUILayout.Button(new GUIContent("Compile Map"), GUILayout.Height(32)))
					{
						Compiler.GetBuildTarget(buildTargets[buildTargetIndex], out var target);
						Compiler.CompileLevel(UnityEngine.SceneManagement.SceneManager.GetSceneByPath(AssetDatabase.GetAssetPath(cachedMap)), target, cachedBeep, cachedLoadInGame);
					}
				}
				EditorGUI.EndDisabledGroup();
			}
			GUILayout.EndVertical();
		}
	}
}

#endif