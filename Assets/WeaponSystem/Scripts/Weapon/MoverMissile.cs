using UnityEngine;
using System.Collections;

public class MoverMissile : WeaponBase
{
	public float Damping = 3;
	public float Speed = 80;
	public float SpeedMax = 80;
	public float SpeedMult = 1;
	public Vector3 Noise = new Vector3 (20, 20, 20);
	public float TargetLockDirection = 0.5f;
	public int DistanceLock = 70;
	public int DurationLock = 40;
	public bool Seeker;
	public float LifeTime = 5.0f;
	private bool locked;
	private int timetorock;
	private float timeCount = 0;

	private void Start ()
	{
        Speed = 80;
		timeCount = Time.time;
		//Destroy (gameObject, LifeTime);
        Speed += GetComponent<Rigidbody>().velocity.magnitude;
        //GetComponent<Rigidbody>().velocity += new Vector3(transform.forward.x * Speed, transform.forward.y * Speed, transform.forward.z * Speed);
        //Debug.Log("Start speed " + Speed);
    }

    private void FixedUpdate ()
	{
        float delta = 5f;        

        if (Target)
        {
            Vector3 targetPosition = Target.transform.position;

            //Debug.Log("has target");     
            float targetdistance = Vector3.Distance(transform.position, targetPosition);
            if (targetdistance < 5)
            {
                targetPosition = targetPosition + Target.GetComponent<Rigidbody>().velocity * Time.deltaTime;
            }

            Quaternion rotation = Quaternion.LookRotation(targetPosition - transform.transform.position);
            //transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.fixedDeltaTime * Damping);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.fixedDeltaTime * delta);

            Vector3 dir = (Target.transform.position - transform.position).normalized;
            float direction = Vector3.Dot(dir, transform.forward);
            if (direction < TargetLockDirection)
            {
                Target = null;
                //Debug.Log("lose target");
            } 
            else
            {
                //Debug.Log("direction is " + direction.ToString());
            }
        }

        GetComponent<Rigidbody>().velocity = Vector3.Lerp(GetComponent<Rigidbody>().velocity, transform.forward * Speed, Time.fixedDeltaTime * delta);
        //GetComponent<Rigidbody>().velocity += new Vector3 (transform.forward.x * Speed * Time.fixedDeltaTime, transform.forward.y * Speed * Time.fixedDeltaTime, transform.forward.z * Speed * Time.fixedDeltaTime);
        //GetComponent<Rigidbody>().velocity += transform.TransformDirection(Vector3.forward * Speed * Time.fixedDeltaTime);
        //GetComponent<Rigidbody>().velocity += new Vector3 (Random.Range (-Noise.x, Noise.x), Random.Range (-Noise.y, Noise.y), Random.Range (-Noise.z, Noise.z));

        if (Speed < SpeedMax) {
            Speed += SpeedMult * Time.fixedDeltaTime;
        }
    }

	private void Update ()
	{
		if (Time.time >= (timeCount + LifeTime) - 0.5f) {
			if (GetComponent<Damage> ()) {
				GetComponent<Damage> ().Active ();
			}
		}
		
        /*
		if (Target) {
			Quaternion rotation = Quaternion.LookRotation (Target.transform.position - transform.transform.position);
			//transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * Damping);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * Damping);
            Vector3 dir = (Target.transform.position - transform.position).normalized;
			float direction = Vector3.Dot (dir, transform.forward);
			if (direction < TargetLockDirection) {
				Target = null;
			}
		}
        */
		
		if (Seeker) {
			if (timetorock > DurationLock) {
				if (!locked && !Target) {
					float distance = int.MaxValue;
					for (int t=0; t<TargetTag.Length; t++) {
						if (GameObject.FindGameObjectsWithTag (TargetTag [t]).Length > 0) {
							GameObject[] objs = GameObject.FindGameObjectsWithTag (TargetTag [t]);

							for (int i = 0; i < objs.Length; i++) {
								if (objs [i]) {
									Vector3 dir = (objs [i].transform.position - transform.position).normalized;
									float direction = Vector3.Dot (dir, transform.forward);
									float dis = Vector3.Distance (objs [i].transform.position, transform.position);
									if (direction >= TargetLockDirection) {
										if (DistanceLock > dis) {
											if (distance > dis) {
												distance = dis;
												Target = objs [i];
											}
											locked = true;
										}
									}
								}
							}
						}
					}
				}
			} else {
				timetorock += 1;
			}

			if (Target) {
				
			} else {
				locked = false;

			}
		}
	}

}
