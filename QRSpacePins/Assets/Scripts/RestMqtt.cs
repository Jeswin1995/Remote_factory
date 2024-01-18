using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

public class RestMqtt : MonoBehaviour
{
    private const string Message1 = "Reached";
    private const string Message2 = "Subscribed";
    private MqttClient client;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ConnectToMqttBroker());
    }

    void Update()
    {

    }
    // Create a new MqttClient object

    IEnumerator ConnectToMqttBroker()
    {
        MqttClient client = new MqttClient("mqtt3.thingspeak.com");

        client.ProtocolVersion = MqttProtocolVersion.Version_3_1_1;

        // Connect to the Thingspeak MQTT broker using your Thingspeak API key as the username and password
        client.Connect("LxwZGTMNAAwtARooJAw2Bhs", "LxwZGTMNAAwtARooJAw2Bhs", "OlEj2P5sEWLDh/A/6DE4wqDJ");
        // Wait until the client is connected to the broker
        while (!client.IsConnected)
        {
            // Pause the execution of the code for 1 second
            yield return new WaitForSeconds(1);
        }
        Debug.Log("Connected");
        // The client is now connected to the broker
        // ...
        // Subscribe to a specific topic on Thingspeak
        
        client.Subscribe(new string[] { "channels/1468745/subscribe/fields/field1" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        
        Debug.Log("After subscribe");
        client.MqttMsgPublishReceived += (sender, e) =>
        {
            // Convert the incoming data to a string
            string data = Encoding.UTF8.GetString(e.Message);
            Debug.Log(message: e.Message);
            Debug.Log("Retain message");
            // Process the data as needed
            // ...
        };


    }
}