using UnityEngine;
using System.Collections;

public class EnemyHealthManager : MonoBehaviour {

	public int health;
	public int flashTime;

	private int currentHealth;
	private int currentFlashTime;

	private SpriteRenderer rend;

	// Use this for initialization
	void Start () {
		currentHealth = health;	
		rend = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if(currentHealth <= 0){
			Destroy(gameObject);
		}
	}

	void FixedUpdate(){
		currentFlashTime --;
		if(currentFlashTime <= 0){
			rend.material.SetFloat("_FlashAmount",0);
		}
	}

	public void HurtEnemy(int damage){
		currentHealth -= damage;
		rend.material.SetFloat("_FlashAmount",1);
		currentFlashTime = flashTime;
	}
}