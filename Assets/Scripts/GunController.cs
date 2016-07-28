using UnityEngine;
using System.Collections;

public class GunController : MonoBehaviour {

	public bool isFiring;

	public BulletController bullet;
	public GameObject spentBullet;

	public float bulletSpeed;
	public float bulletSpreadMin;
	public float bulletSpreadMax;

	public float spentBulletSpeed;
	public float spentBulletSpreadMin;
	public float spentBulletSpreadMax;
	public float spentBulletDragMin;
	public float spentBulletDragMax;
	

	public float timeBetweenShots;
	private float shotCounter;

	public Transform firePoint;
	public Transform ejectPoint;




	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(isFiring)
		{
			shotCounter -= Time.deltaTime;
			if(shotCounter <= 0)
			{
				shotCounter = timeBetweenShots;

				float randZ = Random.Range(bulletSpreadMin, bulletSpreadMax);

				BulletController newBullet = Instantiate(bullet, firePoint.position,firePoint.rotation) as BulletController;
				newBullet.speed = bulletSpeed;
				newBullet.rotation = randZ;


				//SPENT BULLETS
				GameObject newSpentBullet = Instantiate(spentBullet, ejectPoint.position, ejectPoint.rotation)as GameObject;

				randZ = Random.Range(spentBulletSpreadMin, spentBulletSpreadMax);
				newSpentBullet.transform.Rotate(0, 0, randZ);
				Vector3 velocity = newSpentBullet.transform.rotation * Vector3.down * spentBulletSpeed;

				
				newSpentBullet.GetComponent<Rigidbody2D>().AddForce(velocity);
				randZ = Random.Range(spentBulletDragMin,spentBulletDragMax);
				newSpentBullet.GetComponent<Rigidbody2D>().drag = randZ;
			}
		}else{
			shotCounter = 0;
		}	
	}
}
