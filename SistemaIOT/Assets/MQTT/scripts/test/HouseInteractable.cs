using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using uPLibrary.Networking.M2Mqtt.Utility;
using uPLibrary.Networking.M2Mqtt.Exceptions;

public class HouseInteractable : Interactable
{
    public string brokerIpAddress = "127.0.0.1";
	public int brokerPort = 1883;
	public string motionTopic = "casa/puerta/luz";

    private MqttClient client;
    string lastMessage;

    void Start()
    {
        client = new MqttClient(IPAddress.Parse(brokerIpAddress), brokerPort, false, null);
        string clientId = Guid.NewGuid().ToString();
		client.Connect(clientId);
    }
    


    public override void Interact()
    {
        base.Interact();
        Debug.Log("Entro");
        client.Publish(
                motionTopic,
                System.Text.Encoding.UTF8.GetBytes("lightOn"),
                MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE,
                true
            );

    }

    public override void NotInteract()
    {
        base.NotInteract();
        client.Publish(
                motionTopic,
                System.Text.Encoding.UTF8.GetBytes("lightOff"),
                MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE,
                true
            );
    }

    void OnApplicationQuit()
	{
		client.Disconnect();
	}
}
