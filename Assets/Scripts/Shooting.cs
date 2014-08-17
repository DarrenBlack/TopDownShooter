using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {

    public GameObject bullet;
    public GameObject spentBullet;

    public bool isAutomatic;

    public float fireRate = .5f;
    private float nextFire = 0.0f;
    private Vector3 currentPosition;

    public float bulletSpreadMin = 5.0f;
    public float bulletSpreadMax = 5.0f;

    public float spentBulletSpreadMin;
    public float spentBulletSpreadMax;

    public float minSpentBulletDrag;
    public float maxSpentBulletDrag;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        currentPosition = new Vector3(this.rigidbody2D.position.x,this.rigidbody2D.position.y,0);

        if (Input.GetMouseButton(0)) {
            if (isAutomatic && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                ShootBullet();
            }            
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (!isAutomatic)
            {
                ShootBullet();
            }
        }
	}

    void ShootBullet()
    {
        float randZ = Random.Range(bulletSpreadMin, bulletSpreadMax);

        bullet = Instantiate(bullet, currentPosition, transform.rotation) as GameObject;
        bullet.transform.Rotate(0, 0, randZ);
        EjectBullet();
    }

    void EjectBullet()
    {       
        spentBullet = Instantiate(spentBullet, currentPosition, transform.rotation) as GameObject;
        spentBullet.transform.Translate(new Vector3(-3f, 0, 0)); //instantiates spent bullet further back          

        float randDrag = Random.Range(minSpentBulletDrag, maxSpentBulletDrag); //Varies distance spent bullet flies from gun
        float randZ = Random.Range(spentBulletSpreadMin, spentBulletSpreadMax);
        spentBullet.transform.Rotate(0, 0, randZ);
        Vector3 velocity = spentBullet.transform.rotation * Vector3.down * 10000f;


        spentBullet.rigidbody2D.AddForce(velocity);
        spentBullet.rigidbody2D.drag = randDrag;
    }


}
