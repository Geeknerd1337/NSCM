#if UNITY_EDITOR

using System;
using UnityEngine;
using UnityEditor;
using Discord;

namespace Armadillo.Netscape
{
    public static class DiscordActivities
    {
        public static void UpdateActivity(Discord.Activity activity)
        {
            var activityManager = DiscordManager.discord.GetActivityManager();
            activityManager.RegisterSteam(SteamManager.AppId);

            activityManager.UpdateActivity(activity, (result) =>
            {
                Debug.Log($"Updating activity!\nState: {activity.State}, Description: {activity.Details}");
                if (result != Discord.Result.Ok)
                {
                    Debug.Log("Update Activity Failed : " + result.ToString());
                }
            });
        }

        public static Activity CurrentMapActivity(UnityEngine.SceneManagement.Scene scene)
        {
            var sceneName = string.IsNullOrWhiteSpace(scene.name) ? "Untitled Scene" : scene.name;
            return ActivityTemplate("Creating Map!", $"Active Scene : {sceneName}");
        }

        public static Activity ActivityTemplate(string state, string description)
        {
            return new Activity()
            {
                State = state,
                Details = description,

                Timestamps =
                {
                    Start = (System.DateTimeOffset.Now.Subtract(TimeSpan.FromSeconds(EditorApplication.timeSinceStartup)).ToUnixTimeSeconds()),
                },

                Assets =
                {
                    LargeImage = "discordprensence",
                    LargeText = "Netscape Tools",
                    SmallImage = "unity-tab-square-black",
                    SmallText = Application.unityVersion,
                },
                Instance = false,
            };
        }
    }
}


#endif