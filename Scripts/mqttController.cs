using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mqttController : MonoBehaviour
{
    public string nameController = "Controller 1";
    public string tagOfTheMQTTReceiver = "";
    public mqttReciever _eventSender;
    
    void Start()
    {
        _eventSender = GameObject.FindGameObjectsWithTag(tagOfTheMQTTReceiver)[0].gameObject.GetComponent<mqttReciever>();
        _eventSender.OnMessageArrived += OnMessageArrivedHandler;
    }

    private void OnMessageArrivedHandler(string newMsg)
    {
        string[] datavalues = newMsg.Split(',');
        
        foreach(var field in datavalues)
        {
            Debug.Log(field);
        }
        Debug.Log(datavalues);

        Debug.Log("Event Fired. The message, from Object " + nameController + " is = " + newMsg);
    }
}
