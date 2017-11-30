using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public void LoadScene(string sceneName)
    {
		//PlayerPrefs.GetString("Level")
		SceneManager.LoadScene(PlayerPrefs.GetString("Level"));

    }
    public void Salir()
    {
        Application.Quit();
    }


}
