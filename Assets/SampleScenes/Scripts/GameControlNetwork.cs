using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class GameControlNetwork : NetworkBehaviour {

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
			discovery.StartAsServer ();
		} else if (Input.GetKeyDown ("a")) {
			discovery.StartAsServer ();
		} else if (Input.GetKeyDown ("joystick button 1")) {
			discovery.StartAsClient ();
		} else if (Input.GetKeyDown ("b")) {
			discovery.StartAsClient ();
		}
	}
}
