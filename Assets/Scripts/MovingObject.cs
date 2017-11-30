using UnityEngine;
using System.Collections;

public class MovingObject : MonoBehaviour {

    public GameObject objectToMove;
    public Transform startPoint;
    public Transform endPoint;
    public float moveSpeed;

    private Vector3 currentTarget;

	// Use this for initialization
	void Start () {
        currentTarget = endPoint.position;
	}
	
	// Update is called once per frame
	void Update () {
		
		objectToMove.transform.position = Vector3.MoveTowards (objectToMove.transform.position, currentTarget, moveSpeed * Time.deltaTime);

		if (objectToMove.transform.position == endPoint.position) {
			currentTarget = startPoint.position;
		}
		if (objectToMove.transform.position == startPoint.position) {
			currentTarget = endPoint.position;
		}
        
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player"){
			float yOffset = 0.3f;
			if (transform.position.y + yOffset < col.transform.position.y){
				col.SendMessage("EnemyJump");
				Destroy(gameObject);
			} else {
				col.SendMessage("EnemyKnockBack", transform.position.x);
			}
		}
	}

}
