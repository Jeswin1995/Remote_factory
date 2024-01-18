using Newtonsoft.Json;
using System;
using System.Collections;
using System.Net.Sockets;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using Microsoft.MixedReality.Toolkit.UI;

public class MqttManager : MonoBehaviour
{
    #region Properties
    /// <summary>
    /// Mqtt properties
    /// </summary>
    private MqttClient client;
    private string broker;
    private int port;
    private bool secure;
    private MqttSslProtocols sslprotocol;
    private MqttProtocolVersion protocolversion;
    private string username;
    private string password;
    private string clientId;
    private string topic;
    private string topicPublish;
    private bool publish = false;
    private byte qos;
    private bool retain;
    private bool cleansession;
    private ushort keepalive;

    /// <summary>
    /// Data properties
    /// </summary>
    private bool dataHasBeenUpdated;
    private Telemetry data;

    /// <summary>
    /// Text objects assoicated with the Mqtt data
    /// </summary>
    public TextMeshProUGUI PressureText;
    public TextMeshProUGUI TemperatureText;
    public TextMeshProUGUI GasflowText;
    public TextMeshProUGUI LiquidflowText;
    public TextMeshProUGUI InletPressureText;
    public TextMeshPro Gasflowmin;
    public TextMeshPro Gasflowmax;
    public TextMeshPro Pressuremin;
    public TextMeshPro Pressuremax;
    public TextMeshPro PressureSet;
    public TextMeshPro GasSet;
    /// <summary>
    /// Setting UI
    /// </summary>
    public SettingMenu settings;
    public string Slidervalue ;
    private float GasSliderValue;
    private float GasSliderValueRaw;
    private float PressureSliderValue;
    private float PressureSliderValueRaw = 1f;
    public PinchSlider SliderGasFlow;
    public PinchSlider SliderPressure;
    private float Gasflowmaximum;
    private string Gasflowmaximumstring;
    private bool PublishSwitch = true;
    #endregion

    #region Initilization
    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    private void Start()
    {
        //Set up default Mqtt properties for https://github.com/khilscher/MqttClient
        broker = "mqtt3.thingspeak.com";
        port = 1883;
        secure = false;
        sslprotocol = MqttSslProtocols.None;
        protocolversion = MqttProtocolVersion.Version_3_1_1;
        username = "KSAuBzskKyoMLT0CJS8tJzk";
        password = "NiYHrj4MVu7xSD9auIVrcluo";
        clientId = "KSAuBzskKyoMLT0CJS8tJzk";
        topic = "channels/1468745/subscribe";
        publish = false;
        qos = (byte)00;
        retain = false;
        cleansession = true;
        keepalive = 60;
        /// <summary>
        /// Slider minimum and maximum initial values
        /// </summary>
        Pressuremin.text = "3";
        Pressuremax.text = "25";
        Gasflowmin.text = "200";
        Gasflowmax.text = "800";

        //Update the settings menu with default values
        //settings.MQTTBrokerTextInputButton.TextObject.text = broker;
        //settings.DeviceIDTextInputButton.TextObject.text = clientId;
        //settings.TopicTextInputButton.TextObject.text = topic;
        //PinchSlider pinchSlider = FindObjectOfType<PinchSlider>();
        //PinchSlider.OnValueUpdated.AddListener(PublishMessageRecieve());

        //Default data properties
        data = null;
        dataHasBeenUpdated = false;

        //Connect at the begining
        StartCoroutine(StartConnect());
        
    }
    #endregion

    #region Methods

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        //if we have new data, update the corresponding text in the scene
        if (dataHasBeenUpdated)
        {
            //Debug.Log("field1:" + data.field1);
            //Debug.Log("field2:" + data.field2);
            if (data.field1 != null)
            {
                PressureText.text = data.field1;
            }
            if (data.field2 != null)
            {
                TemperatureText.text = data.field2;
            }
            if (data.field3 != null)
            {
                GasflowText.text = data.field3;
            }
            if (data.field4 != null)
            {
                LiquidflowText.text = data.field4;
            }
            if (data.field5 != null)
            {
                InletPressureText.text = data.field5;
            }
            //GasflowText.text = data.field3;
            //LiquidflowText.text = data.field4;
            //InletPressureText.text = data.field5;
            dataHasBeenUpdated = false;
        }
    }

    //Coroutine to start connecting at the beginning
    IEnumerator StartConnect()
    {
        MqttConnect();
        yield return new WaitForSeconds(2f);

        MqttSubscribe();
        
    }
    /// <summary>
    /// Publishon or off.
    /// </summary>

    public void Publishoff()
    {

        PublishSwitch = false;
        //Debug.Log("False");
    }

    public void Publishon()
    {

        PublishSwitch = true;
        //Debug.Log("True");


    }
    /// <summary>
    /// Updated slidervalue while moving
    /// </summary>
    public void UpdateGasSliderValues()
    {
        PinchSlider Value = SliderGasFlow.GetComponent<PinchSlider>();
        float GasSliderValueRaw = Value.SliderValue;
        GasSliderValue = GasSliderValueRaw * (800f - 200f) * PressureSliderValueRaw + (1 - PressureSliderValueRaw) * GasSliderValueRaw * 50 + 200f;
        Slidervalue = GasSliderValue.ToString("0.00");
        GasSet.text = Slidervalue;
    }

    public void UpdatePressureSliderValues()
    {
        PinchSlider Value = SliderPressure.GetComponent<PinchSlider>();
        PressureSliderValueRaw = Value.SliderValue;
        PressureSliderValue = PressureSliderValueRaw * (25f - 3f) + 3f;
        Slidervalue = PressureSliderValue.ToString("0.00");
        Gasflowmaximum = (800f - 200f) * PressureSliderValueRaw + (1 - PressureSliderValueRaw) * 50 + 200f;
        Gasflowmaximumstring = Gasflowmaximum.ToString("0.00");
        Gasflowmax.text = Gasflowmaximumstring;
        PressureSet.text = Slidervalue;
    }





    /// <summary>
    /// Updated Publish message based on the values from the slider
    /// </summary>
    public void UpdatePublishMessageField6()
    {
        PinchSlider Value = SliderGasFlow.GetComponent<PinchSlider>();
        float GasSliderValueRaw = Value.SliderValue;
        GasSliderValue = GasSliderValueRaw * (800f - 200f) * PressureSliderValueRaw + (1-PressureSliderValueRaw)* GasSliderValueRaw *50 +200f ;
        Slidervalue = GasSliderValue.ToString("0.00");
        GasSet.text = Slidervalue;
        topicPublish = "channels/1468745/publish/fields/field6";
        if (PublishSwitch != false)
        {
            MqttPublish();
            //Debug.Log("Published");
        }
        
    }

    public void UpdatePublishMessageField7()
    {
        PinchSlider Value = SliderPressure.GetComponent<PinchSlider>();
        PressureSliderValueRaw = Value.SliderValue;
        PressureSliderValue = PressureSliderValueRaw * (25f - 3f) + 3f;
        Slidervalue = PressureSliderValue.ToString("0.00");
        Gasflowmaximum = (800f - 200f) * PressureSliderValueRaw + (1 - PressureSliderValueRaw) * 50 + 200f;
        Gasflowmaximumstring = Gasflowmaximum.ToString("0.00");
        Gasflowmax.text = Gasflowmaximumstring;
        PressureSet.text = Slidervalue;
        topicPublish = "channels/1468745/publish/fields/field7";
        if (PublishSwitch != false)
        {
            MqttPublish();
            //Debug.Log("Published");
        }
    }
    
    /// <summary>
    /// Connected to Mqtt.
    /// </summary>
    public void MqttConnect()
    {
        try
        {
            client = new MqttClient(this.broker);

            // Set MQTT version
            client.ProtocolVersion = this.protocolversion;

            // Setup callback for receiving messages
            client.MqttMsgPublishReceived += ClientRecieveMessage;

            // MQTT return codes 
            // https://www.hivemq.com/blog/mqtt-essentials-part-3-client-broker-connection-establishment/
            // https://www.eclipse.org/paho/clients/dotnet/api/html/4158a883-de72-1ec4-2209-632a86aebd74.htm
            byte resp = client.Connect(this.clientId, this.username, this.password, this.cleansession, this.keepalive);
            //settings.DebugConsole.text = "Connect() Response: " + resp.ToString();
        }
        catch (SocketException e)
        {
            //settings.DebugConsole.text = e.Message;
        }
        catch (Exception e)
        {
            //settings.DebugConsole.text = e.Message;

        }
    }

    /// <summary>
    /// Subscribe to predefined Mqtt topic.
    /// </summary>
    public void MqttSubscribe()
    {
        if (client != null && client.IsConnected)
        {
            ushort resp = client.Subscribe(
                new string[] { this.topic },
                new byte[] { this.qos });

            //settings.DebugConsole.text = "Subscribe() Response: " + resp.ToString();

        }
        else
        {
            settings.DebugConsole.text = "Not subscribe";

        }
    }

    /// <summary>
    /// Publish to  Mqtt topic.
    /// </summary>

    public void MqttPublish()
    {
        if (client != null && client.IsConnected)
        {
            ushort resp = client.Publish(topicPublish,
                Encoding.UTF8.GetBytes(Slidervalue));

                Debug.Log("Publish() Response: " + Slidervalue);

        }
        else
        {
            //Debug.Log("NoPublish() Response: ");

        }
    }




    /// <summary>
    /// Call back Method for recieving messages from MQTT.
    /// </summary>
    public void ClientRecieveMessage(object sender, MqttMsgPublishEventArgs e)
    {
        data = JsonConvert.DeserializeObject<Telemetry>(System.Text.UTF8Encoding.UTF8.GetString(e.Message));
        dataHasBeenUpdated = true;
    }

    /// <summary>
    /// Disconnect from Mqtt broker.
    /// </summary>
    private void MqttDisconnect()
    {
        if (client != null && client.IsConnected)
        {
            client.Disconnect();
            settings.DebugConsole.text = "Disconnect()";
        }
        else
        {
            settings.DebugConsole.text = "Not connected";
        }
    }

    /// <summary>
    /// Unsubscribe from Mqtt topic.
    /// </summary>
    private void MqttUnsubscribe()
    {
        if (client != null && client.IsConnected)
        {
            ushort resp = client.Unsubscribe(
                new string[] { this.topic });

            settings.DebugConsole.text = "Unsubscribe() Response: " + resp.ToString();
        }
        else
        {
            settings.DebugConsole.text = "Not connected";

        }
    }
    #endregion
}
