using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Door : MonoBehaviour {

    public int levelToLoad;
    private GameMaster gm;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            gm.doorText.text = "[E] to enter";
            if (Input.GetKeyDown("e"))
            {
                SaveScore();
                Application.LoadLevel(levelToLoad);
            }
        }

    }

    void OnTriggerStay2D(Collider2D col)
    {

        if (col.CompareTag("Player"))
        {
            if (Input.GetKeyDown("e"))
            {
                SaveScore();
                Application.LoadLevel(levelToLoad);
            }
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            gm.doorText.text = "";
        }


    }


    void SaveScore()
    {
        PlayerPrefs.SetInt("score", gm.points);
    }
}
