using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour{
	
	public static bool monkey =false;
	public static bool fish =false;
	public static bool turtle=false;
	public static bool worker=false;

	public AudioSource jumpSound;
	public AudioSource runSound;
	public AudioSource climbSound;

	public bool grounded=false;
	public Transform groundEnd;
	public Transform ladder;
	public Transform sight;
	public float jumpTime =0;
	public float  delay =0.5f;
	Animator anim;
	bool jumped;
	bool ladderOn =false;
	bool onLadder = false;
	bool grounded2 =false;
	bool moving=false;
	GameObject platform;
	
	
	GameObject [] ladderGrounds ;
	
	void Start (){
		platform = GameObject.Find ("MovingPlatform");
		anim=gameObject.GetComponent<Animator> ();
		ladderGrounds = GameObject.FindGameObjectsWithTag ("LadderGround");
	}
	
	void Update(){
		Movement ();
		Raycasting ();
		Jump ();
		Climb ();
		Moving ();
		
	}

	void Moving(){
			if (moving) {
						transform.parent = platform.transform;
				} else {
					transform.parent=null;
				}
	
	
	}
	
	void Movement(){
		anim.SetFloat ("speed", 0);
		if (DialogOnScreen.move) {
			anim.SetFloat ("speed", Mathf.Abs (Input.GetAxis ("Horizontal")));
			if (Input.GetAxisRaw ("Horizontal") > 0) {
				if (!runSound.isPlaying){
						runSound.Play ();
				}
				transform.Translate (Vector2.right * 4f * Time.deltaTime);
				transform.eulerAngles = new Vector2 (0, 0);
			}
			
			if (Input.GetAxisRaw ("Horizontal") < 0) {
				transform.Translate (Vector2.right * 4f * Time.deltaTime);
				transform.eulerAngles = new Vector2 (0, 180);
				if (!runSound.isPlaying) {
					runSound.Play ();
				}
			}
			if ((Mathf.Abs (Input.GetAxis ("Horizontal"))==0) || (jumped)){
				runSound.Stop ();
			}

		}
	}
	
	void Raycasting(){
		Debug.DrawLine (this.transform.position, groundEnd.position, Color.red); 
		grounded = Physics2D.Linecast (this.transform.position, groundEnd.position, 1 <<  LayerMask.NameToLayer("Ground")); 
		
		Debug.DrawLine (this.transform.position, ladder.position, Color.red); 
		ladderOn = Physics2D.Linecast (this.transform.position, ladder.position, 1 <<  LayerMask.NameToLayer("Ladder")); 
		
		grounded2 = Physics2D.Linecast (this.transform.position, groundEnd.position, 1 <<  LayerMask.NameToLayer("LadderGround"));

		moving = Physics2D.Linecast (this.transform.position, groundEnd.position, 1 <<  LayerMask.NameToLayer("MovingPlatform"));
		
		monkey = Physics2D.Linecast (this.transform.position, sight.position, 1 <<  LayerMask.NameToLayer("Monkey"));
		Debug.DrawLine (this.transform.position, sight.position, Color.blue); 
		turtle = Physics2D.Linecast (this.transform.position, sight.position, 1 <<  LayerMask.NameToLayer("Turtle"));
		
		fish = Physics2D.Linecast (this.transform.position, sight.position, 1 <<  LayerMask.NameToLayer("Fish"));

		worker = Physics2D.Linecast (this.transform.position, sight.position, 1 <<  LayerMask.NameToLayer("Worker"));
	}
	
	void Jump(){
		if (Input.GetKeyDown (KeyCode.Space) && (grounded || grounded2 || moving)) {
			Debug.Log ("jummmpppp");
			if (!jumpSound.isPlaying){
				jumpSound.Play();
			}
			rigidbody2D.AddForce(Vector2.up *500f);	
			jumpTime=delay;
			jumped=true;
			anim.SetTrigger("jump");
		}
		jumpTime -= Time.deltaTime;
		if (jumpTime <= 0 &&jumped  && (grounded || grounded2 || moving)) {
			anim.SetTrigger("land");	
			jumped=false;
		}
	}
	
	void Climb(){
		// Player is over a ladder, he's not jumping and he's pushing the up arrow
		if ((Input.GetAxisRaw ("Vertical") > 0) && (ladderOn) && (!jumped)) {
			if (!climbSound.isPlaying){
				climbSound.Play();
			}

			GroundCollision (ladderGrounds,true);
			anim.enabled=true;
			onLadder = true;
			anim.SetTrigger ("climb");
			transform.Translate (Vector2.up * 4f * Time.deltaTime);
			rigidbody2D.gravityScale = 0;
			// Player is on the ladder and he's not pushing the up arrow and he's not grounded	
		} 
		else if ((Input.GetAxisRaw ("Vertical") < 0) && (ladderOn) &&(!grounded)) {// player pushing the down arrow
			if (!climbSound.isPlaying){
				climbSound.Play();
			}
			anim.enabled=true;
			rigidbody2D.gravityScale = 0;
			anim.SetTrigger ("climb");
			onLadder = true;
			GroundCollision (ladderGrounds,true);
			transform.Translate (-Vector2.up * 4f * Time.deltaTime);
			
			
		}
		else if ((onLadder) &&(!grounded) &&(ladderOn) ) {
			climbSound.Stop();
			rigidbody2D.gravityScale = 0;
			anim.enabled=false;
			
		}
		
		else{
			climbSound.Stop();
			anim.enabled=true;
			GroundCollision (ladderGrounds,false);
			onLadder = false;
			anim.SetTrigger("idle");
			rigidbody2D.gravityScale=1;
			
		}
		
	}
	
	
	void GroundCollision(GameObject [] grounds, bool trig){
		foreach (GameObject ground in grounds){
			ground.GetComponent<BoxCollider2D>().isTrigger=trig;
		}
	}
}

