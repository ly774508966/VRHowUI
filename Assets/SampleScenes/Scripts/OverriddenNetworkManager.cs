using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class OverriddenNetworkManager : NetworkManager {

//	public override void OnServerAddPlayer (NetworkConnection conn, short playerControllerId)
//	{
//		GameObject player;
//		//SpawnData spawnData = Tools.gameController.GetSpawnData();
//
//		player = (GameObject)Object.Instantiate(this.playerPrefab, Vector3.zero, Quaternion.identity);
//		NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
//
//	}
//
//
//
//	public override void OnClientSceneChanged(NetworkConnection conn)
//	{
//		ClientScene.AddPlayer(conn, 0);
//	}
//
	public override void OnClientConnect(NetworkConnection conn)
	{
		//ClientScene.Ready(conn);
	}
}
