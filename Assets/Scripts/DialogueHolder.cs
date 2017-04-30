using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DialogueHolder : MonoBehaviour {

    public string dialogue;
    public Sprite icon;
    public TextAsset textFile;
    private DialogueManager dMan;

    private GameMaster gm;


    // Use this for initialization
    void Start () {
        dMan = FindObjectOfType<DialogueManager>();
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(Input.GetKeyUp(KeyCode.E))
            {
                string texts = textFile.text;
                gm.doorText.text = "";
                dMan.ShowBox(texts, icon);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            gm.doorText.text = "[E] to talk";
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            gm.doorText.text = "";
        }
    }

}

