﻿using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
 
public class OverriddenNetworkDiscovery : NetworkDiscovery
{
 
    public override void OnReceivedBroadcast (string fromAddress, string data)
    {
		Debug.Log ("OnReceivedBroadcast " + fromAddress + " " + data);

        this.StopBroadcast();
        NetworkManager.singleton.networkAddress = fromAddress;
        NetworkManager.singleton.StartClient();
    }
 
}