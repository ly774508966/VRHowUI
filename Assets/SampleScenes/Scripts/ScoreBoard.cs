using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ScoreBoard : MonoBehaviour {
    //List<KeyValuePair<string, int>> scoreList = new List<KeyValuePair<string, int>>();
    Dictionary<string, int> scoreList = new Dictionary<string, int> ();

	[SerializeField] private GameObject scoreBoard;
	private Text scoreBoardText;

    // Use this for initialization
    void Start () {
        //KeyValuePair<string, int> playerScore = new KeyValuePair<string, int>("PlayerWeapon", 0);
        //KeyValuePair<string, int> AIScore = new KeyValuePair<string, int>("AIWeapon", 0);

        //scoreList.Add(playerScore);
        //scoreList.Add(AIScore);

        scoreList.Add("PlayerWeapon", 0);
        scoreList.Add("AIWeapon", 0);

		scoreBoardText = scoreBoard.GetComponent<Text> ();
    }
	
	// Update is called once per frame
	void Update () {
//        foreach (string key in scoreList.Keys)
//        {
//            Debug.Log(key + " : " + scoreList[key]);
//        }
    }

    public void addScore (string tag, int score){
        foreach (string key in scoreList.Keys)
        {
            if (key.Equals(tag)) {
                scoreList[key] += score;
				scoreBoardText.text = "Score : " + scoreList [key];
                break;
            }
        }
    }
}
