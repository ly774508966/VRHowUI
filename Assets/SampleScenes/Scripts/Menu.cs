using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("joystick button 0")) {
			SceneManager.LoadScene ("SinglePlayer");
		} else if (Input.GetKeyDown ("a")) {
			SceneManager.LoadScene ("SinglePlayer");
		} else if (Input.GetKeyDown ("joystick button 1")) {
			SceneManager.LoadScene ("Lobby");
		} else if (Input.GetKeyDown ("b")) {
			SceneManager.LoadScene ("Lobby");
		} else if (Input.GetKeyDown ("joystick button 2")) {
			SceneManager.LoadScene ("Settings");
		} else if (Input.GetKeyDown ("x")) {
			SceneManager.LoadScene ("Settings");
		}
	}
}
