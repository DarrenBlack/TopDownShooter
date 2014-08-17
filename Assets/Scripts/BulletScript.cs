using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

    public float bulletSpeed = 10f;

    Vector3 velocity;

    void Start()
    {    
        
        velocity = this.transform.rotation * Vector3.right * bulletSpeed;
     
        
        gameObject.rigidbody2D.AddForce(velocity);
    }

	void Update () {
       
    }
}
