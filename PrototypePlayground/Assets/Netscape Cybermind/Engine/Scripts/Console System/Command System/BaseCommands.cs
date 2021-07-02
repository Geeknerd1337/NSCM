using System;
using UnityEngine;

namespace Armadillo.Netscape
{
    public static class BaseCommands
    {
        [ConsoleCmd("quit", Help = "Quits the game.")]
        private static void QuitGame()
        {
            Application.Quit();
        }

        [ConsoleCmd("echo", Help = "Echos the inputted string")]
        private static void EchoMessage(string input)
        {
            Debug.Log(input);
        }

        [ConsoleCmd("clear", Help = "Clears the console log")]
        private static void ClearConsoleLog()
        {
            throw new NotImplementedException();
        }
    }
}
