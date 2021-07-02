using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Armadillo.Netscape;

public class ConsoleSystemTest
{
    [ConsoleVar("var_test")]
    public static float awesome { get; set; } = 25;

    [ConsoleCmd("test")]
    public static void Test([ParameterDesc("First")] int test, int test2, [ParameterDesc("third")] int test3)
    {
        Debug.Log(test);
    }
}
