using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Discord;

public class DiscordManager : MonoBehaviour
{
    // Start is called before the first frame update
    private static long CLIENT_ID = 810300100655710251;

    public Discord.Discord discord;

    //Activity defAct = new Activity
    //{
    //    State = "Configuring Hardware",
    //    Details = "Surfing the Netscape",
    //    Assets =
    //    {
    //        LargeImage = "nscm_icon",
    //        LargeText = "Netscape Cybermind",
    //    },
    //    Party = { },
    //    Secrets = { },
    //    Instance = true,
    //};

    private void Awake()
    {
        //defAct.Timestamps.Start = 

        discord = new Discord.Discord(CLIENT_ID, (System.UInt64)Discord.CreateFlags.Default);
        print("made a new discord instance");
        var Activitymanager = discord.GetActivityManager();

        //Activitymanager.UpdateActivity(defAct, (result) => { if (result == Discord.Result.Ok) print("Discord presence set"); else Debug.LogError("Default status failed. Error code: " + result); });
    }

    // Update is called once per frame
    void Update()
    {
        discord.RunCallbacks();
    }

    private void OnApplicationQuit()
    {
        discord.Dispose();
    }
}
