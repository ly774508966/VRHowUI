using System;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class CameraSwitch : MonoBehaviour
{
    public GameObject[] objects;
    //public Text text;

    private int m_CurrentActiveObject;

	private void Update()
	{
	    if (CrossPlatformInputManager.GetButtonUp ("Switch")) {
            Debug.Log("Switch");
			NextCamera ();
		}
	}

    private void OnEnable()
    {
        if (objects.Length >= 2 && objects[0] != null)
        {
            objects[0].SetActive(true);
            for (int i = 1; i < objects.Length; i++)
            {
                objects[i].SetActive(false);
            }
        }

        m_CurrentActiveObject = 0;
    }


    public void NextCamera()
    {
        int nextactiveobject = m_CurrentActiveObject + 1 >= objects.Length ? 0 : m_CurrentActiveObject + 1;

        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].SetActive(i == nextactiveobject);
        }

        m_CurrentActiveObject = nextactiveobject;
//        text.text = objects[m_CurrentActiveObject].name;
    }
}
