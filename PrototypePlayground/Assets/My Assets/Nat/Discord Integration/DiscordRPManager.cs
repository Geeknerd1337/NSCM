using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Discord;


public class DiscordRPManager : MonoBehaviour
{

    [SerializeField] private DiscordManager dm;

    [SerializeField] public Activity levelStatus;

    [System.NonSerialized] public int currentLevel;

    private DateTime epoch;

    public bool assignOnStart;

    private void Awake()
    {
        epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        if (GetComponent<DiscordManager>() != null)
        {
            dm = GameObject.FindGameObjectWithTag("Player").GetComponent<DiscordManager>();
            print("reassigned dm to " + dm.transform.name);
        }
    }

    private void Start()
    {
        int currentSeconds = (int)(DateTime.UtcNow - epoch).TotalSeconds;
        if (assignOnStart)
        {
            levelStatus.Timestamps.Start = currentSeconds;
            print("setting status in RPManager");
            dm.discord.GetActivityManager().UpdateActivity(levelStatus, (result) =>
            {
                if (result != Result.Ok)
                {
                    Debug.Log("discord failed to update activity in DiscordInformation. Error code " + result);
                }
            }
            );
        }
        
    }

    
    public void assignStatus()
    {
        int currentSeconds = (int)(DateTime.UtcNow - epoch).TotalSeconds;
        levelStatus.Timestamps.Start = currentSeconds;
        print("setting status in RPManager ASSIGNSTATUS");
        dm.discord.GetActivityManager().UpdateActivity(levelStatus, (result) =>
        {
            if (result != Result.Ok)
            {
                Debug.Log("discord failed to update activity in DiscordInformation ASSIGNSTATUS. Error code " + result);
            }
        }
        );
    }
}
