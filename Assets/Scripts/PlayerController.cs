using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	private Rigidbody2D myRigidBody;
	
	private Vector3 moveInput;
	private Vector3 moveVelocity;

	private WeaponController weapon;

	private Animator anim;

	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody2D>();	
		anim = GetComponent<Animator>();
		weapon = FindObjectOfType<WeaponController>() as WeaponController;
	}
	
	// Update is called once per frame
	void Update () {
		moveInput = new Vector3(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"),0f);
		moveVelocity = moveInput * moveSpeed;	

		anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
		anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));

		if(Input.GetMouseButtonDown(0))
		{
			weapon.Fire();
		}
		if(Input.GetMouseButtonUp(0))
		{
			weapon.isFiring = false;
		}
	}

	void FixedUpdate(){
		myRigidBody.velocity = moveVelocity;
	}
}