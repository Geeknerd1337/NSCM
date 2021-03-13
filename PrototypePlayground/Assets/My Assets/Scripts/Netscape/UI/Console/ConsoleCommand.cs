using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CommandBase
{
    private string _commandID;
    private string _commandDescription;
    private string _commandFormat;

    public string commandID { get { return _commandID; } }
    public string commandDescription { get { return _commandDescription; } }
    public string commandFormat { get { return _commandFormat;  } }
    public CommandBase(string id, string description, string format)
    {
        _commandID = id;
        _commandDescription = description;
        _commandFormat = format;
    }
}
public class Command : CommandBase
{
    private UnityAction command;

    public Command(string id, string description, string format, UnityAction command) : base(id, description, format)
    {
        this.command = command;
    }
    public void Invoke()
    {
        command.Invoke();
    }
}

// An alt class type of Command that can take a generic type for the UnityAction.
public class Command<T1> : CommandBase
{
    private UnityAction<T1> command;

    public Command(string id, string description, string format, UnityAction<T1> command) : base (id, description, format)
    {
        this.command = command;
    }
    public void Invoke(T1 value)
    {
        command.Invoke(value);
    }
}
