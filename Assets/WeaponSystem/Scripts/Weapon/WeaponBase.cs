﻿using UnityEngine;
using System.Collections;

public class DamageBase : MonoBehaviour {

	public GameObject Effect;
	[HideInInspector]
    public GameObject Owner;
    public int Damage = 20;
	public string[] TargetTag = new string[1]{"Enemy"};

	public int Radio = 1;
}

public class WeaponBase : MonoBehaviour {
	[HideInInspector]
    public GameObject Owner;
	[HideInInspector]
	public GameObject Target;
    public string[] TargetTag = new string[1]{"Enemy"};
	public bool RigidbodyProjectile;
	public Vector3 TorqueSpeedAxis;
	public GameObject TorqueObject;
}

