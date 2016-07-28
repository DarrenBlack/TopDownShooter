using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	private Rigidbody2D myRB;
	public float movementSpeed;

	public PlayerController thePlayer;

	// Use this for initialization
	void Start () {
		myRB = GetComponent<Rigidbody2D>();
		thePlayer = FindObjectOfType<PlayerController>();
	}

	void FixedUpdate(){
		//Move towards the player
		transform.position = Vector2.MoveTowards(transform.position, thePlayer.transform.position, movementSpeed * Time.deltaTime);
	}
	
	// Update is called once per frame
	void Update () {
		//rotate to face the player
		Vector3 target = thePlayer.transform.position;
		float angleRad = Mathf.Atan2(target.y - transform.position.y, target.x - transform.position.x);
		float angle = (180 / Mathf.PI) * angleRad;

		myRB.rotation = angle;

	}
}