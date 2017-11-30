using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollParallax : MonoBehaviour {

	[Range(0f,0.20f)]
	public float parallaxSpeed= 0.02f;
	public RawImage background;
	private bool isMovenment;
	private PlayerController thePlayer;

	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {

		if(thePlayer.inMovenment()){
			PlayerIsRunning ();
		}
		parallax (); 
	}

	void PlayerIsRunning(){

		isMovenment = true;

	}

	void parallax(){
		if(isMovenment){
			float finalSpeed = parallaxSpeed * Time.deltaTime;
			background.uvRect = new Rect (background.uvRect.x + finalSpeed, 0f, 1f, 1f);
		}

	}
}
