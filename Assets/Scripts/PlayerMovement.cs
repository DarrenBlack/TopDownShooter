using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float speed = 10f;

    void Update()
    {
        transform.position += Vector3.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.position += Vector3.up * Input.GetAxis("Vertical") * speed * Time.deltaTime;
    }

}
