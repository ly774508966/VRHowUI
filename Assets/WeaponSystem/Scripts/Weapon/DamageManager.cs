using UnityEngine;
using System.Collections;

public class DamageManager : MonoBehaviour
{
    public AudioClip[] HitSound;
    public GameObject Effect;
    public int HP = 100;
    public int Score = 100;

	private Hud hud;

    private void Start()
    {
		GameObject hudObj = GameObject.Find("Hud");
		if (hudObj) {
			hud = (Hud)hudObj.GetComponent (typeof(Hud));
		} else {
			Debug.Log ("not find hud");
		}
    }

	public void ApplyDamage(int damage, string tag, int radio)
    {
		if(HP<0)
		return;
	
        if (HitSound.Length > 0)
        {
            AudioSource.PlayClipAtPoint(HitSound[Random.Range(0, HitSound.Length)], transform.position);
        }
        HP -= damage;

		if (gameObject.tag.Equals ("Player")) {
			if (hud) {
				hud.displayHealth (HP);
			}
		}

		if (HP <= 0) {
			Dead ();

			if (hud) {
				hud.addScore (tag, Score * radio);
			}
		}
    }

    private void Dead()
    {
        if (Effect){
            Instantiate(Effect, transform.position, transform.rotation);
		}
        //Destroy(this.gameObject);

        if (this.gameObject.CompareTag ("Enemy"))
        {
            this.gameObject.transform.position = new Vector3(Random.Range(-1000, 1000), Random.Range(-1000, 1000) + 1250, Random.Range(-1000, 1000));
        }
        else if (this.gameObject.CompareTag("AI"))
        {
            this.gameObject.transform.position = new Vector3(Random.Range(-50, 50), Random.Range(-50, 50) + 50, Random.Range(-50, 50));
        }
        else if (this.gameObject.CompareTag("AI2"))
        {
            this.gameObject.transform.position = new Vector3(0, 0, 0);
        }
    }

}
