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
			Debug.Log ("SinglePlayer!!!");

			SceneManager.LoadScene("AircraftJet2Axis");
		}
	}
}
