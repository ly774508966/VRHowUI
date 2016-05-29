﻿using UnityEngine;
using System.Collections;

public class AILook : MonoBehaviour {

	public string[] TargetTag = new string[1]{"Enemy"};
	
	private int indexWeapon;
	private GameObject target;
	private WeaponController weapon;
	private float timeAIattack;
	
	void Start () {
		weapon = (WeaponController)this.GetComponent<WeaponController>();
	}
	
	
	void Update () {
		
		if(target){
			Quaternion targetlook = Quaternion.LookRotation(target.transform.position - this.transform.position);
			//this.transform.rotation = Quaternion.Lerp(this.transform.rotation,targetlook,Time.deltaTime * 3);
			this.transform.rotation = Quaternion.Lerp(this.transform.rotation,targetlook, 1f);
			
			Vector3 dir = (target.transform.position - transform.position).normalized;
            float direction = Vector3.Dot(dir, transform.forward);
			
			if(direction>0.9f){
				if(weapon){
					weapon.LaunchWeapon(indexWeapon);
				}
			}
			// AI attack the target for a while (3 sec)
			if(Time.time > timeAIattack+3){
				target = null;	
				// AI forget this target and try to looking new target
			}
		}else{
			for(int t=0;t<TargetTag.Length;t++){
			// AI find target only in TargetTag list
            if (GameObject.FindGameObjectsWithTag(TargetTag[t]).Length > 0)
            {
                GameObject[] objs = GameObject.FindGameObjectsWithTag(TargetTag[t]);
                float distance = int.MaxValue;
                for (int i = 0; i < objs.Length; i++)
                {
					float dis = Vector3.Distance(objs[i].transform.position, transform.position);
                       
                    if (distance > dis)
                    {
						// Select closer target
                        distance = dis;
							//Debug.Log ("distane : " + distance);
                        target = objs[i];
						if(weapon){
							indexWeapon = Random.Range(0,weapon.WeaponLists.Length);
								if (distance > 1000) {
									indexWeapon = 0;
								} else {
									indexWeapon = 1;
								}
						}
						timeAIattack = Time.time;
					}
				}
			}
			}	
		}
	}
}
