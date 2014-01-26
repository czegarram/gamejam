using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
	public bool grounded, interact,leftToBlock,interacted,ontoBlock; //bool for checking if player is grounded so they can jump, and bool for interact, so that player can only interact when in range of thing to interact with
	public Transform jumpCheck, interactCheck; //transform variable for the end points of the linecasts
	
	public float speed = .3f;
	private static PlayerControl instance;

	float jumpTime, jumpDelay = .3f;
	bool jumped;
	bool left;
	
	Vector2 boxColliderSizeLand;
	Vector2 boxColliderSizeRun;
	Vector2 boxColliderSizeJump;
	Animator anim;

	public static PlayerControl Instance
	{
		get
		{
			return instance;
		}
	}
	
	
	void Awake(){
		instance = this;
	}


	void Start()
	{
		boxColliderSizeLand = new Vector2(GetComponent<BoxCollider2D>().size.x,GetComponent<BoxCollider2D>().size.y);
		boxColliderSizeRun = new Vector2(1.4f, 1.8f);
		boxColliderSizeJump = new Vector2 (1.4f, 1.8f);
		anim = GetComponent<Animator>();
		jumped = false;
	}
	
	void changeBoxCollider2D(Vector2 v){
		
		GetComponent<BoxCollider2D> ().size = v;
	}
	
	void Update()
	{
		Movement(); //call the function every frame
		RaycastStuff(); //call the function every frame
	}
	
	void RaycastStuff()
	{
		//Just a debug visual representation of the Linecast, can only see this in scene view! Doesn't actually do anything!
		Debug.DrawLine(transform.position, jumpCheck.position, Color.magenta);
		Debug.DrawLine(transform.position, new Vector2( jumpCheck.position.x+0.11f,jumpCheck.position.y), Color.green);
		Debug.DrawLine(transform.position, new Vector2( jumpCheck.position.x-0.11f,jumpCheck.position.y), Color.red);
		Debug.DrawLine(transform.position, interactCheck.position, Color.magenta);
		Debug.DrawLine(transform.position, new Vector2( interactCheck.position.x,interactCheck.position.y+0.18f), Color.white);
		Debug.DrawLine(transform.position, new Vector2( interactCheck.position.x,interactCheck.position.y+0.36f), Color.white);
		//we assign the bool 'ground' with a linecast, that returns true or false when the end of line 'jumpCheck' touches the ground
		ontoBlock = Physics2D.Linecast (transform.position, jumpCheck.position, 1 << LayerMask.NameToLayer ("Block")) ||
			Physics2D.Linecast (transform.position, new Vector2 (jumpCheck.position.x + 0.11f, jumpCheck.position.y), 1 << LayerMask.NameToLayer ("Block")) ||
				Physics2D.Linecast (transform.position, new Vector2 (jumpCheck.position.x - 0.11f, jumpCheck.position.y), 1 << LayerMask.NameToLayer ("Block"));
		
		grounded = Physics2D.Linecast(transform.position, jumpCheck.position, 1 << LayerMask.NameToLayer("Ground")) ||
			Physics2D.Linecast(transform.position, new Vector2( jumpCheck.position.x+0.11f,jumpCheck.position.y), 1 << LayerMask.NameToLayer("Ground")) ||
				Physics2D.Linecast(transform.position, new Vector2( jumpCheck.position.x-0.11f,jumpCheck.position.y), 1 << LayerMask.NameToLayer("Ground"))	|| ontoBlock;
		
		
		leftToBlock = Physics2D.Linecast (transform.position, interactCheck.position, 1 << LayerMask.NameToLayer ("Block"))
			|| Physics2D.Linecast (transform.position, new Vector2( interactCheck.position.x,interactCheck.position.y+0.24f), 1 << LayerMask.NameToLayer ("Block")) 
				|| Physics2D.Linecast (transform.position, new Vector2( interactCheck.position.x,interactCheck.position.y+0.36f), 1 << LayerMask.NameToLayer ("Block")) || 
				Physics2D.Linecast (transform.position, new Vector2( interactCheck.position.x,interactCheck.position.y+0.54f), 1 << LayerMask.NameToLayer ("Block"));
		if(leftToBlock ){
			interact = true;
			interacted =true;
		}else{
			interact = false;
		}
		
		//Using linecast which takes (start point, end point, layermask) so we can make it only detect objects with specified layers
		//its wrapped in an if statement, so that while the tip of the Linecast (interactCheck.position) is touching an object with layer 'Guard', the code inside executes
		/*
		if(Physics2D.Linecast(transform.position, interactCheck.position, 1 << LayerMask.NameToLayer("Guard")))
		{
			//we store the collider object the Linecast hit so that we can do something with that specific object, ie. the guard
			//each time the linecast touches a new object with layer "guard", it updates 'interacted' with that specific object instance
			interacted = Physics2D.Linecast(transform.position, interactCheck.position, 1 << LayerMask.NameToLayer("Guard")); 
			interact = true; //since the linecase is touching the guard and we are in range, we can now interact!
		}
		else
		{
			interact = false; //if the linecast is not touching a guard, we cannot interact
		}

		Physics2D.IgnoreLayerCollision(8, 10); //if we want certain layers to ignore each others collision, we use this! the number is the layer number in the layers list
	*/}

	public void listenSaltar ()
	{
		if (Input.GetButtonDown ("Jump2") && (grounded || leftToBlock) && !jumped)// If the jump button is pressed and the player is grounded then the player jumps 
		{
			if (Input.GetAxis ("Jump2") > 0) {
				rigidbody2D.AddForce (transform.up * 350f);
				jumpTime = jumpDelay;
				anim.SetTrigger ("Jump");
				changeBoxCollider2D (boxColliderSizeJump);
				jumped = true;
			}
		}
	}	

	void Movement() //function that stores all the movement
	{
		anim.SetFloat("speed", Mathf.Abs(Input.GetAxis ("Horizontal")));
		
		if (Input.GetAxisRaw ("Horizontal") > 0) {
			//rigidbody2D.velocity = new Vector2(4,rigidbody2D.velocity.y);
			//transform.Translate (Vector3.right * speed * Time.deltaTime);
			if(!interacted || (!interact && interacted) ){
				changeBoxCollider2D(boxColliderSizeRun);
				rigidbody2D.velocity = new Vector2 (2, rigidbody2D.velocity.y);
				transform.eulerAngles = new Vector2 (0, 0); //this sets the rotation of the gameobject
				left = false;
			}
			
		} else if (Input.GetAxisRaw ("Horizontal") < 0 ) {
			rigidbody2D.velocity = new Vector2 (-4, rigidbody2D.velocity.y);
			transform.eulerAngles = new Vector2 (0, 180);
			changeBoxCollider2D(boxColliderSizeRun);
			//transform.Translate (Vector3.right * speed * Time.deltaTime);
			left = true;
		} else {
			anim.SetFloat ("speed", 0.0f);
			if(grounded && !ontoBlock ){
				//rigidbody2D.velocity = new Vector2(-3,rigidbody2D.velocity.y);
				//transform.Translate (Vector3.right * speed/4 * Time.deltaTime);
				//transform.Translate (Vector3.left * speed/4 * Time.deltaTime);
			}
		}
		
		
		if (Input.GetButtonUp("Horizontal") ){
			rigidbody2D.velocity = new Vector2(0,0);
			anim.SetFloat ("speed", 0.0f);
			//transform.eulerAngles = new Vector2 (0, 180); //this sets the rotation of the gameobject
			//rigidbody2D.velocity = new Vector2(0,0);
			//anim.SetFloat ("speed", 0.0f);
		}
		
		if(PlayerControl2.Instance!=null)
			PlayerControl2.Instance.listenSaltar ();

		jumpTime -= Time.deltaTime;
		if(jumpTime <= 0 && (grounded || leftToBlock) && jumped)
		{
			anim.SetTrigger("Land");
			changeBoxCollider2D(boxColliderSizeLand);
			jumped = false;
			interacted=false;
		}
		
		
	}
}
