using UnityEngine;
using System.Collections;

public class DamageManager : MonoBehaviour
{
    public AudioClip[] HitSound;
    public GameObject Effect;
    public int HP = 100;
    public int Score = 100;

    private void Start()
    {

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
        if (HP <= 0)
        {
            Dead();
            GameObject scoreBoardObj = GameObject.Find("ScoreBoard");
            ScoreBoard scoreBoard = (ScoreBoard)scoreBoardObj.GetComponent(typeof(ScoreBoard));
			scoreBoard.addScore(tag, Score * radio);
        }
    }

    private void Dead()
    {
        if (Effect){
            Instantiate(Effect, transform.position, transform.rotation);
		}
        Destroy(this.gameObject);
    }

}
