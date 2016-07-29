using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class WeaponController : MonoBehaviour
{
    public GameObject[] WeaponLists;
    public int CurrentWeapon = 0;

    private void Start()
    {
    }

    private void Update()
    {
        if (CrossPlatformInputManager.GetButton("Fire1"))
        {
            //LaunchWeapon();
        }
        else if (CrossPlatformInputManager.GetButtonUp("Switch"))
        {
            SwitchWeapon();
        }
        else if (CrossPlatformInputManager.GetButton("FireGun"))
        {
            LaunchWeapon(0);
        }
        else if (CrossPlatformInputManager.GetButtonUp("FireLeft"))
        {
            LaunchWeapon(1);
        }
        else if (CrossPlatformInputManager.GetButtonUp("FireRight"))
        {
            LaunchWeapon(2);
        }
//        else if (Input.GetButtonUp("Cancel"))
//        {
//            //SceneManager.LoadScene(SceneManager.GetSceneAt(0).path);
//            Scene scene = SceneManager.GetActiveScene();
//            SceneManager.LoadScene(scene.name);
//        }

        //float h = Input.GetAxis("Horizontal");
        //float v = Input.GetAxis("Vertical");
        //if (h >= float.Epsilon || h <= -float.Epsilon){
        //    Debug.Log("X: " + h.ToString());
        //}
        //if (v >= float.Epsilon || v <= -float.Epsilon)
        //{
        //    Debug.Log("Y: " + v.ToString());
        //}
    }

    public void SwitchWeapon (){
        if (WeaponLists.Length > 0){
            CurrentWeapon = (CurrentWeapon + 1) % WeaponLists.Length;
        }       
    }
	
	public void LaunchWeapon(int index){
		CurrentWeapon = index;
		if(CurrentWeapon < WeaponLists.Length && WeaponLists[index] != null){
			WeaponLists[index].gameObject.GetComponent<WeaponLauncher>().Shoot();
		}
	}

	public void LaunchWeapon(){
		if(CurrentWeapon < WeaponLists.Length && WeaponLists[CurrentWeapon] != null){
			WeaponLists[CurrentWeapon].gameObject.GetComponent<WeaponLauncher>().Shoot();
		}
	}
}
