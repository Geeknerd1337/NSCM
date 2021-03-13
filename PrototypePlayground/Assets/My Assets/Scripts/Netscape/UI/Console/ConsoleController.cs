using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConsoleController : MonoBehaviour
{
    public static bool showConsole = false;
    string input;

    // 1. Declare your commands here.
    public static Command HELP;
    public static Command CONSOLE_CLEAR;
    public static Command SCENE_RESTART;
    public static Command<string> SCENE_LOAD;
    public static Command<string> OBJECT_SPAWN;

    public List<object> commandList;
    public List<string> commandHistory;
    public List<string> commandOutput; // Add output/response lines to this list.
    public List<string> sceneList;
    public List<string> prefabList;

    static string myLog = "";
    private string output;
    private string stack;

    private void Start()
    {
        // Collect a list of existing prefabs in the project.
        string[] assetsPaths = AssetDatabase.GetAllAssetPaths();
        foreach (var asset in assetsPaths)
        {
            prefabList.Add(asset);
        }
    }

    void OnEnable()
    {
        Application.logMessageReceived += Log;
    }

    void OnDisable()
    {
        Application.logMessageReceived -= Log;
    }
    public void Log(string logString, string stackTrace, LogType type)
    {
        output = logString;
        stack = stackTrace;
        myLog = output + "\n" + myLog;
        if (myLog.Length > 5000) myLog = myLog.Substring(0, 4000);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.BackQuote) && !showConsole)
        {
            showConsole = true;
            Time.timeScale = 0f;
        }
    }
    private void Awake()
    {
        // 2. Assign your command description and function.

        HELP = new Command("help", "Returns a list of all commands", "help", () =>
        {
            for (int i = 0; i < commandList.Count; i++)
            {
                CommandBase command = commandList[i] as CommandBase;
                string label = $"{command.commandFormat} - {command.commandDescription}";
                //commandOutput.Add(label);
                Log(label, "", LogType.Log);
            }
        });

        CONSOLE_CLEAR = new Command("clear", "Clears the console output.", "clear", () =>
        {
            myLog = "";
        });

        // SCENES
        SCENE_RESTART = new Command("restart", "Restarts the current scene.", "restart", () =>
        {
            showConsole = false;
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        });

        SCENE_LOAD = new Command<string>("load", "Load a different scene. \"load list\" will return known scenes in the project.", "load <scene>", (x) =>
        {
            // Find all scenes in the project.
            List<string> allScenes = new List<string>();

            for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
            {
                string name = System.IO.Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i));
                //Debug.Log(name);
                allScenes.Add(name.ToLower());
            }

            if (x.ToLower() == "list")
            {
                string sceneString = "";
                foreach(var scene in allScenes)
                {
                    sceneString += scene + "  ";
                }
                //commandOutput.Add(sceneString);
                Log(sceneString, "", LogType.Log);
            }
            else
            {
                if (allScenes.Contains(x.ToLower()))
                {
                    showConsole = false;
                    Time.timeScale = 1f;
                    SceneManager.LoadScene(x);
                }
                else
                {
                    Debug.Log("Console: Could not find that scene.");
                    Log("Console: Could not find that scene.", "", LogType.Log);
                }
            }
        });

        // Objects
        OBJECT_SPAWN = new Command<string>("spawn", "Spawn in a prefab", "spawn", (x) =>
        {
            Debug.Log("Spawning object...");
            if(x == "list")
            {
                string prefabListString = "";
                foreach (var prefab in prefabList)
                {
                    prefabListString += prefab + "  ";
                }
                Log(prefabListString, "", LogType.Log);
            }
        });

        // 3. Add your new command(s) to the list.
        commandList = new List<object>
        {   
            HELP,
            CONSOLE_CLEAR,
            SCENE_RESTART,
            SCENE_LOAD,
            //OBJECT_SPAWN,
        };

        //commandOutput.Add("Type \"help\" for commands.");
        Log("Type \"help\" for commands.","",LogType.Log);
    }

    Vector2 scroll;

    private void OnGUI()
    {
        if (!showConsole) return;

        // Toggle the console off.
        Event e = Event.current;

        if(e.keyCode == KeyCode.Escape)
        {
            showConsole = false;
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        // Check for Enter to handle the typed input
        if (e.keyCode == KeyCode.Return)
        {
            if (input == "")
            {
                //showConsole = false;
                //Time.timeScale = 1f;
            }
            else
            {
                HandleInput();
                input = "";
            }
        }

        float y = 0f;

        GUI.Box(new Rect(0, y, Screen.width, 30), "");
        GUI.backgroundColor = new Color(0, 0, 0, 0);
        GUI.SetNextControlName("ConsoleInput");
        GUI.FocusControl("ConsoleInput");
        input = GUI.TextField(new Rect(10f, y + 5f, Screen.width - 20f, 20f), input);

        // Show Console Output
        /*
        GUI.Box(new Rect(0, y, Screen.width, 100), "");

        Rect viewport = new Rect(0, 0, Screen.width - 30, 20 * commandList.Count);
        scroll = GUI.BeginScrollView(new Rect(0, y + 5f, Screen.width, 90), scroll, viewport);
        for(int i = 0; i < commandOutput.Count; i++)
        {
            //CommandBase command = commandList[i] as CommandBase;
            //string label = $"{command.commandFormat} - {command.commandDescription}";
            Rect labelRect = new Rect(5, 20 * i, viewport.width - 100, 20);
            GUI.Label(labelRect, commandOutput[i]);
        }

        GUI.EndScrollView();
        */

        y = 30f;

        myLog = GUI.TextArea(new Rect(10f, y, Screen.width, Screen.height - 10f), myLog);

    }

    private void HandleInput()
    {
        // Add entry to command history.
        if (input.Length > 0) commandHistory.Add(input);

        // Split arguments.
        string[] arguments = input.Split(' ');
        for(var i = 0; i < arguments.Length; i++)
        {
            Debug.Log(arguments[i]);
        }
        
        // Find the command in question, if it exists.
        for (int i = 0; i < commandList.Count; i++)
        {
            CommandBase commandBase = commandList[i] as CommandBase;
            if (input.Contains(commandBase.commandID))
            {
                // If we find the command, invoke it.
                if (commandList[i] as Command != null) // Single word commands.
                {
                    (commandList[i] as Command).Invoke();
                }
                else if(commandList[i] as Command<string> != null) // Use command with arguments.
                {
                    (commandList[i] as Command<string>).Invoke(arguments[1]);
                }
            }
        }
    }
}
