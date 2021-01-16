using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageSystem : MonoBehaviour
{

    [SerializeField]
    private string messageColor;
    [SerializeField]
    private string goodNameColor;
    [SerializeField]
    private string badNameColor;

    [SerializeField]
    private Text textField;

    [SerializeField]
    private float subtitleDelay;
    private float subtitleTimer;

    private List<string> messages;
    // Start is called before the first frame update
    void Start()
    {
        textField.text = "";
        messages = new List<string>();
        textField.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            SayDelayedMessage("Kinetik", "Hey man, how's it goin'." + Random.value.ToString(),false,1f);
        }

        if(subtitleTimer > 0)
        {
            subtitleTimer -= Time.deltaTime;
        }

        if(subtitleTimer <= 0)
        {
            if (textField.enabled)
            {
                textField.enabled = false;
            }
        }
        
    }


    //This is the public say message function, this adds a message to the message list
    public void SayMessage(string name, string message, bool enemy)
    {
        string str = "";
        //Chose the color of the name
        string color = goodNameColor;
        if (enemy)
        {
            color = badNameColor;
        }
        //Construct the message, add it to the list, then enable the subtitles momentarily
        str += "<color=#" + color + ">" + name + "</color> : <color=#" + messageColor + ">" + message + "</color> \n";
        AddMessage(str);
        //Renable text reset subtitle timer
        textField.enabled = true;
        subtitleTimer = subtitleDelay;
        
        //Update the text field
        UpdateText();
    }

    //Adds a message to the message list directly, removing the first message (oldest) if there are more than 4 messages
    private void AddMessage(string str)
    {
        messages.Add(str);
        if(messages.Count > 4)
        {
            messages.RemoveAt(0);
        }
    }

    //Updates the text field to contain all our messages
    private void UpdateText()
    {
        string str = "";
        for(int i = 0; i < messages.Count; i++) { 
            str += messages[i];
        }
        textField.text = str;
    }

    //Starts the delayed messgae coroutine
    public void SayDelayedMessage(string name, string message, bool enemy, float delay)
    {
        StartCoroutine(DelayedMessage(name, message, enemy, delay));
    }

    private IEnumerator DelayedMessage(string name, string message, bool enemy, float delay)
    {
        while(delay > 0)
        {
            delay -= Time.deltaTime;
            yield return null;
        }

        if(delay <= 0)
        {
            SayMessage(name, message, enemy);
        }
    }
}
