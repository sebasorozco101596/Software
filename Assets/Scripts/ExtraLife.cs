using UnityEngine;
using System.Collections;

public class ExtraLife : MonoBehaviour {

    public int livesToGive;
    private LevelManager theLevelManager;

	// Use this for initialization
	private void Start () {
        theLevelManager = FindObjectOfType<LevelManager>();
	}
		
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            theLevelManager.AddLives(livesToGive);
            gameObject.SetActive(false);
        }
    }
}
