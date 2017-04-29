using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DialogueManager : MonoBehaviour {

    public GameObject dBox;
    public Text dText;
    private string[] listSentences;
    private int length;
    private int current;

    public bool dialogActive;

	// Use this for initialization
	void Start () {
        dialogActive = false;
        dBox.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(dialogActive && Input.GetKeyDown(KeyCode.E))
        {
            //Il faut d'abord voir s'il reste du texte
            if(current < length - 1)
            {
                current++;
                SetText();
            }else
            {
                //Sinon on enlève la box.
                dBox.SetActive(false);
                dialogActive = false;
            }
        }
	}

    public void ShowBox(string dialogue, Sprite icon)
    {
        
        dialogActive = true;
        dBox.SetActive(true);

        GameObject imageObject = GameObject.FindGameObjectWithTag("IconDialogBox");

        if (imageObject != null)
        {
            Image iconImage = imageObject.GetComponent<Image>();
            iconImage.sprite = icon;
        }

        listSentences = dialogue.Split('\n');
        length = listSentences.Length;
        current = 0;
        SetText();
    } 

    public void SetText()
    {
        dText.text = listSentences[current];
    }
}
