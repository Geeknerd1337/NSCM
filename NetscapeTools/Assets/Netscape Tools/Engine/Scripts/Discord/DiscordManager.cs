#if UNITY_EDITOR

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEditor.SceneManagement;
using Discord;

namespace Armadillo.Netscape
{
    public static class DiscordManager
    {
        public static Discord.Discord discord;

        // [InitializeOnLoadMethod]
        public static void Initialize()
        {
            discord = new Discord.Discord(828917476732436481, (ulong)Discord.CreateFlags.NoRequireDiscord);

            EditorApplication.update -= Update;
            EditorApplication.update += Update;

            EditorApplication.quitting -= OnApplicationQuit;
            EditorApplication.quitting += OnApplicationQuit;

            // Activity Stuff
            DiscordActivities.UpdateActivity(DiscordActivities.CurrentMapActivity(EditorSceneManager.GetActiveScene()));
            EditorSceneManager.sceneOpened += (scene, mode) => DiscordActivities.UpdateActivity(DiscordActivities.CurrentMapActivity(scene));
            EditorSceneManager.newSceneCreated += (scene, setup, mode) => DiscordActivities.UpdateActivity(DiscordActivities.CurrentMapActivity(scene));
            EditorSceneManager.sceneSaved += (scene) => DiscordActivities.UpdateActivity(DiscordActivities.CurrentMapActivity(scene));
        }

        private static void Update()
        {
            if (discord != null)
            {
                try
                {
                    discord.RunCallbacks();
                }
                catch (ResultException e)
                {
                    Debug.LogError("Error running Discord callbacks: " + e);
                    discord = null;
                    return;
                }
            }
        }

        private static void OnApplicationQuit()
        {
            discord.Dispose();
        }
    }
}


#endif