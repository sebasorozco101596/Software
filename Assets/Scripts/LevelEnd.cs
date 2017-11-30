using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelEnd : MonoBehaviour {

    public string levelToLoad;

    private PlayerController thePlayer;
    private LevelManager theLevelManager;

    public float waitToMove;
    public float waitToLoad;

    private bool movePlayer;

	// Use this for initialization
	void Start () {
        thePlayer = FindObjectOfType<PlayerController>();
        theLevelManager = FindObjectOfType<LevelManager>();
        
    }
    // Update is called once per frame
    void Update () {
        if (movePlayer)
        {
			//thePlayer.myRigidbody.velocity = new Vector3(thePlayer.speed, thePlayer.myRigidbody.velocity.y, 0f);
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine("LevelEndCo");
        }
    }

    public IEnumerator LevelEndCo()
    {
        thePlayer.canMove = false;
        theLevelManager.invincible = true;
		//thePlayer.myRigidbody.velocity = Vector3.zero;
        yield return new WaitForSeconds(waitToMove);
        movePlayer = true;
        yield return new WaitForSeconds(waitToLoad);
		PlayerPrefs.SetString ("Level", levelToLoad);
        SceneManager.LoadScene(levelToLoad);
    }
}