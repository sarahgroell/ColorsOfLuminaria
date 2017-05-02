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
    private GameMaster gm;

    public bool dialogActive;
    private bool paused;

	// Use this for initialization
	void Start () {
        dialogActive = false;
        dBox.SetActive(false);
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();

    }

    // Update is called once per frame
    void Update () {
        if (paused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }

		if(dialogActive && Input.GetKeyDown(KeyCode.G))
        {
            //Il faut d'abord voir s'il reste du texte
            if(current < length - 1)
            {
                current++;
                SetText();
            }else
            {
                //Sinon on enlève la box.
                paused = false;
                dBox.SetActive(false);
                dialogActive = false;
                gm.doorText.text = "[E] pour parler";
            }
        }
	}

    public void ShowBox(string dialogue, Sprite icon)
    {
        paused = true;
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
