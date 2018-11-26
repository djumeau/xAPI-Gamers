using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeUIManager : MonoBehaviour {

    public void StartGame()
    {
        SceneManager.LoadScene("EveryLightInTheMansion");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ByeNow()
    {
        SceneManager.LoadScene("OpeningScene");
    }
	
}
