using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {

    public int points;
    public int requiredPoints;
    public Text pointsText;
    public Text doorText;
    public Text warningText;

    void Start()
    {
        if (PlayerPrefs.HasKey("score"))
        {
            PlayerPrefs.DeleteKey("score");
            points = 0;                      
        }
    }


    void Update()
    {
        pointsText.text  = ("Rubis : " + points);
    }

}
