using System;
using UnityEngine;

namespace Armadillo.Netscape
{
    public static class BaseCommands
    {
        [ConsoleCmd("quit", Help = "Quits the game.")]
        public static void QuitGame()
        {
            Application.Quit();
        }

        [ConsoleCmd("echo", Help = "Echos the inputted string")]
        public static void EchoMessage([ParameterDesc("What to echo")] string input)
        {
            Debug.Log(input);
        }

        [ConsoleCmd("clear", Help = "Clears the console log")]
        public static void ClearConsoleLog()
        {
            throw new NotImplementedException();
        }
    }
}
