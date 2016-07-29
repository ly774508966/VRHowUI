using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using UnityStandardAssets.CrossPlatformInput;

public class GameControlNetwork : MonoBehaviour {

    public NetworkDiscovery discovery;
    
	// Use this for initialization
	void Start () {
		discovery.Initialize();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonUp("Cancel"))
		{
			//SceneManager.LoadScene(SceneManager.GetSceneAt(0).path);
			Scene scene = SceneManager.GetActiveScene();
			SceneManager.LoadScene(scene.name);
		}

		if (Input.GetKeyDown ("joystick button 0")) {
			Debug.Log ("AAAAA");
			NetworkManager.singleton.StartHost();
			discovery.StartAsServer ();
		} else if (CrossPlatformInputManager.GetButton ("a")) {
			Debug.Log ("AAAAA");
			NetworkManager.singleton.StartHost();
			discovery.StartAsServer ();
		} else if (Input.GetKeyDown ("joystick button 1")) {
			Debug.Log ("BBBBB");
			discovery.StartAsClient ();
		} else if (CrossPlatformInputManager.GetButton ("b")) {
			Debug.Log ("BBBBB");
			discovery.StartAsClient ();
		}
	}
}
