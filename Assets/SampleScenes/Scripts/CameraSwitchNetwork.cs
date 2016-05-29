using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class CameraSwitchNetwork : NetworkBehaviour
{
    public GameObject[] objects;
    public Text text;

    private int m_CurrentActiveObject;

	private void Update()
	{
		if (!isLocalPlayer)
			return;
		
	    if (Input.GetButtonUp ("Switch")) {
			NextCamera ();
		}
	}

//    private void OnEnable()
//    {
//        text.text = objects[m_CurrentActiveObject].name;
//    }
//

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
