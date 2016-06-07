using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour {

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Cancel")) {
            SceneManager.LoadScene("Enter");
        }
    }
}
