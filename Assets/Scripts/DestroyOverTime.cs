using UnityEngine;
using System.Collections;

public class DestroyOverTime : MonoBehaviour {

    public float objectLifeTime;
	
	// Update is called once per frame
	private void Update () {
        objectLifeTime = objectLifeTime - Time.deltaTime;

        if (objectLifeTime <= 0f) 
        {
            // Destroy the object which this script is attached to
            Destroy(gameObject);
        }
	}
}
