using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

	private Rigidbody2D myRigidBody;

	public float speed;
	public float rotation;

	public int damageToGive;

	public float lifeTime;

	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody2D>();
		myRigidBody.transform.Rotate(0,0,rotation);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += transform.right * speed * Time.deltaTime;

		lifeTime -= Time.deltaTime;
		if(lifeTime <= 0){
			Destroy(gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.tag == "Enemy"){
			other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damageToGive);
			Destroy(gameObject);
		}
	}
}
