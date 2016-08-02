﻿using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

	private Bullet theBullet;
	private bool fired;
	private Rigidbody2D rb;
	private SpriteRenderer rend;

	
	// Update is called once per frame
	void Update () {
		if(fired){
			rb.velocity = transform.right * theBullet.BulletSpeed * Time.deltaTime;
		}
	}

	void FireBullet(Bullet a){
		rb = GetComponent<Rigidbody2D>();
		rend = GetComponent<SpriteRenderer>();

		theBullet = a;
		rend.sprite = theBullet.BulletSprite;
		fired = true;
	}

	public void SetBullet(Bullet newBullet){
		theBullet = newBullet;
	}
}