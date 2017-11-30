using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour {

    bool active;
    Canvas canvas;
	public Button btnMenu;

	// Recupero el valor del canvas para ser mostrado y inicializo el valor actual del canvas en false para que no sea mostrado
	void Start () {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false; 


		btnMenu.onClick.AddListener (Menu);
		
	}
	
    // Verifica si estoy precionando la letra p y cambio el valor que tiene el canvas.enable para hacerlo visible
    // Escalo el vector velocidad para detener el juego y seguirlo cuando cambia el estado
	void Update () {
        if (Input.GetKeyDown("p"))
        {
            active = !active;
            canvas.enabled = active;
            Time.timeScale = (active) ? 0 : 1f;
        }
		
	}

	void Menu(){

		active = !active;
		canvas.enabled = active;
		Time.timeScale = (active) ? 0 : 1f;
		SceneManager.LoadScene("Menu");

	}
}
