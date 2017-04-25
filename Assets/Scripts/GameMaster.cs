using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {

    public int points;
    public int highScore = 0;
    public Text pointsText;
    public Text doorText;

    void Start()
    {
        if (PlayerPrefs.HasKey("score"))
        {
            if(Application.loadedLevel == 0)
            {
                PlayerPrefs.DeleteKey("score");
                points = 0;
            }
            else
            {
                points = PlayerPrefs.GetInt("score");
            }
           
        }
        if (PlayerPrefs.HasKey("highscore"))
        {
            highScore = PlayerPrefs.GetInt("highscore");
        }
    }
    void Update()
    {
        pointsText.text  = ("Points : " + points);
    }

}
