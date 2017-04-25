using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginScreen : MonoBehaviour {

	public void loadFirstLevel()
    {
        SceneManager.LoadScene("Introduction");
    }

    public void quit()
    {
        Application.Quit();
    }

    public void loadBonus()
    {
        
    }
}
