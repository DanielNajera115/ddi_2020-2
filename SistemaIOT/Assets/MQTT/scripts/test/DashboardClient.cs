using UnityEngine;
using System.Collections;
using System.Net;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using uPLibrary.Networking.M2Mqtt.Utility;
using uPLibrary.Networking.M2Mqtt.Exceptions;
using UnityEngine.UI;

using System;

public class DashboardClient : MonoBehaviour {
	public string brokerIpAddress = "192.168.0.113";
	public int brokerPort = 5001;
	public string temperatureTopic = "casa/sala/temperatura";
	public string lightTopic = "casa/sala/luz";
	public string lightFrontDoorTopic = "casa/puerta/luz";
	public string garageTopic = "casa/patio/garage";
	private MqttClient client;
	public Text displayText;
	public GameObject directionalLight;
	public GameObject garageDoor;
	string lastMessage;
	volatile bool lightState = false;
	volatile bool garageState = true;
	// Use this for initialization
	void Start () {
		// create client instance 
		client = new MqttClient(IPAddress.Parse(brokerIpAddress), brokerPort, false, null); 
		
		// register to message received 
		client.MqttMsgPublishReceived += client_MqttMsgPublishReceived; 
		
		string clientId = Guid.NewGuid().ToString(); 
		client.Connect(clientId); 
		
		// subscribe to the topic "/home/temperature" with QoS 2 
		client.Subscribe(new string[] { temperatureTopic }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
		client.Subscribe(new string[] { lightFrontDoorTopic }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });  
		client.Subscribe(new string[] { garageTopic }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE }); 
	}
	void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e) 
	{ 
		Debug.Log("Received: " + System.Text.Encoding.UTF8.GetString(e.Message)  );
		lastMessage = System.Text.Encoding.UTF8.GetString(e.Message);
		if(e.Topic.Equals(lightFrontDoorTopic))
		{
			if(lastMessage.Equals("lightOn"))
			{
				lightState = true;
			}
			else if(lastMessage.Equals("lightOff"))
			{
				lightState = false;
			}
		}
		 if(e.Topic.Equals(garageTopic)){
			if(lastMessage.Equals("close"))
			{
				garageState = true;
			}
			else if(lastMessage.Equals("open"))
			{
				garageState = false;
			}
		}
	}

	void Update()
	{
		if (lightState != directionalLight.activeSelf)
			directionalLight.SetActive(lightState);
		if (garageState != garageDoor.activeSelf)
			garageDoor.SetActive(garageState);
	}

	void OnApplicationQuit()
	{
		client.Disconnect();
	}
}
