using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	private Rigidbody2D myRigidBody;

	private Vector3 moveInput;
	private Vector3 moveVelocity;

	public GunController theGun;

	public bool useController;

	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody2D>();
		FitColliderToChildren(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		moveInput = new Vector3(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"),0f);
		moveVelocity = moveInput * moveSpeed;


		//Rotate with mouse
		if(!useController){
			Vector3 mousePos = Input.mousePosition;
			mousePos.z = 5.23f;
			
			Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
			mousePos.x = mousePos.x - objectPos.x;
			mousePos.y = mousePos.y - objectPos.y;
			
			float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
		

		//Shoot
			if(Input.GetMouseButtonDown(0))
			{
				theGun.isFiring = true;
			}
			if(Input.GetMouseButtonUp(0))
			{
				theGun.isFiring = false;
			}
		}

		//Rotate with controller
		if(useController){
			Vector3 playerDirection = Vector3.right * Input.GetAxisRaw("Right Horizontal") + Vector3.up * -Input.GetAxisRaw("Right Vertical");
			float heading = Mathf.Atan2(playerDirection.y,playerDirection.x);

			if(playerDirection.sqrMagnitude > 0.0f)
			{
				transform.rotation=Quaternion.Euler(0f,0f,heading*Mathf.Rad2Deg);	
			}

			if(Input.GetAxis("Right Trigger") > 0){
				theGun.isFiring = true;
			}
			else{
				theGun.isFiring = false;
			}
				
		}
	}


void FixedUpdate(){
	myRigidBody.velocity = moveVelocity;
	}


	//Resize boxcollider2d to fit all sprites that are children of the gameobject
	private void FitColliderToChildren (GameObject parentObject)
	{
		BoxCollider2D bc = parentObject.GetComponent<BoxCollider2D>();
		if(bc==null){bc = parentObject.AddComponent<BoxCollider2D>();
		Bounds bounds = new Bounds (Vector3.zero, Vector3.zero);
		bool hasBounds = false;
		Renderer[] renderers =  parentObject.GetComponentsInChildren<Renderer>();
		foreach (Renderer render in renderers) {
				//excludes gun
				GunController script = render.GetComponentInParent<GunController>();
					if(script == null){
						if (hasBounds) {
							bounds.Encapsulate(render.bounds);
						} else {
							bounds = render.bounds;
							hasBounds = true;
						}
					}

		}
			if (hasBounds) {
				bc.offset = bounds.center - parentObject.transform.position;
				bc.size = bounds.size;
			} else {
				bc.size = bc.offset = Vector3.zero;
				bc.size = Vector3.zero;
			}
		}
	}
}

