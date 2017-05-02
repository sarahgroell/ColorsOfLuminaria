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
            gm.doorText.text = "[E] pour continuer";
            if (Input.GetKeyDown("e"))
            {
                HandelLevelAchieved();                
            }
        }
    }

    void HandelLevelAchieved()
    {
        if (gm.points >= gm.requiredPoints)
        {
            Application.LoadLevel(levelToLoad);
        }
        else
        {
            int missingRubis = gm.requiredPoints - gm.points;
            gm.warningText.text = "Attention princesse ! Il te manque " + missingRubis + " rubis !";
        }    
           
    }

    void OnTriggerStay2D(Collider2D col)
    {

        if (col.CompareTag("Player"))
        {
            if (Input.GetKeyDown("e"))
            {
                HandelLevelAchieved(); 
            }
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            gm.doorText.text = "";
            gm.warningText.text = "";
        }
    }

}
