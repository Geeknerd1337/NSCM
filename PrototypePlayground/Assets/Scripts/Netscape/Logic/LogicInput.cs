using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LogicInput : MonoBehaviour
{
    public enum State
    {
        True = 0,
        False = 1
    }

    public LogicNode inputNode;
    public State validValue = State.True;
    public bool output;

    public void Update()
    {
        bool input = inputNode.output;
        bool check = (int)validValue == 1 ? true : false;

        if (input == check)
        {
            output = true;
        }
        else
        {
            output = false;
        }

    }
}
