using UnityEngine;
using System.Collections;

public class TankMover : MonoBehaviour {

	public float Speed = 20;
	public float TurnSpeed = 100;
	
	void Start () {
	
	}

	void Update () {
		this.transform.Rotate(new Vector3(0, Random.Range(-10.0F,10.0F) * TurnSpeed * Time.deltaTime,0));
		this.transform.position += this.transform.forward * Random.Range(-1.0F, 1.0F) * Speed* Time.deltaTime;
	}
}
