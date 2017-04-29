using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DialogueHolder : MonoBehaviour {

    public string dialogue;
    public Sprite icon;
    public TextAsset textFile;
    private DialogueManager dMan;

	// Use this for initialization
	void Start () {
        dMan = FindObjectOfType<DialogueManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("LOL");
            if(Input.GetKeyUp(KeyCode.G))
            {
                Debug.Log("Enter");
                string texts = textFile.text;
                dMan.ShowBox(texts, icon);
            }
        }
    }
}

