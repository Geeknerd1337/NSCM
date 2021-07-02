using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Armadillo.Netscape;

public class ConsoleSystemTest
{
    [ConsoleCmd("test")]
    public static void Test(int test)
    {
        Debug.Log(test);
    }
}
