using UnityEngine;
using System.Collections;
using System.Threading;

public class CustomCharacterController : MonoBehaviour {

	Animator anim;
	Transform cameraTransform;
	Vector3 forward;

	public bool isGround = false;
	public bool canJump = false;
	public bool running = false;
	public bool hasWeapon = true;

	public float v;
	public float h;

	private float moveSpeed, rotateSpeed, jumpVelocity;
	private Transform myTrans;
	public Rigidbody myBody;

	private Vector3 eulerAngleVelocity = new Vector3(0, 100, 0);
	private Vector3 currectVelocity;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();

//		myBody = GameObject.Find ("Cha_Knight 1/Group Locator/Root/Skeleton_Root").transform.rigidbody;
		myBody = this.rigidbody;
		myTrans = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
//		cameraTransform= Camera.main.transform;
//		
//		// Forward vector relative to the camera along the x-z plane	
//		forward= cameraTransform.TransformDirection(Vector3.forward);
//		forward.y = 0;
//		forward = forward.normalized;
		currectVelocity = myBody.velocity;
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.transform.tag == "Ground") {
			isGround = true;
			anim.SetBool("isGrounded",true);
		}
	}
	void OnCollisionExit(Collision collision) {
		if (collision.transform.tag == "Ground") {
			isGround = false;
			anim.SetBool("isGrounded",false);
		}
	}

//	void OnCollisionStay(Collision collision){
//		if (collision.transform.tag == "Ground") {
//			isGround = true;
//			anim.SetBool("isGrounded",true);
//		}
//	}

	void FixedUpdate(){
		move ();
		if(Input.GetButtonDown("Jump"))
		   jump ();
	}

	public void move(){

//		#if !UNITY_ANDROID && !UNITY_IPHONE && !UNITY_BLACKBERRY && !UNITY_WINRT || UNITY_EDITOR
//		// PC KeyBoard
		v = Input.GetAxisRaw("Vertical");
		h = Input.GetAxisRaw("Horizontal");
//		#else
//
//		#endif

		// Running or not, added only possible if move forward direction
		// Run animation have build in average Velocity So it will move as the animation played with apply root motion in animator
//		if ((Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.RightShift)) && v > 0.4)
//		{
//			if(isGround){
//	//			jumpVelocity = 5;
//				anim.SetBool("Run",true);
////				moveSpeed = 0.2f;
//				moveSpeed = 3.0f;
//				rotateSpeed = 0.2f;
//			}
//		}else{
////			jumpVelocity = 3.5f;
//			anim.SetBool("Run",false);
////			moveSpeed =  0.05f;
//			moveSpeed = 1.5f;
//			rotateSpeed = 0.05f;
//		}

//		if(running && v > 0.4f){
//			print ("running && v > 0.4f");
//			if(isGround){
//				print ("isGround");
////				jumpVelocity = 5;
//				anim.SetBool("Run",true);
////				moveSpeed = 0.2f;
//				moveSpeed = 3.0f;
//				rotateSpeed = 0.2f;
//			}
//		}else{
//			print ("else");
////			jumpVelocity = 3.5f;
//			anim.SetBool("Run",false);
////			moveSpeed =  0.05f;
//			moveSpeed = 1.5f;
//			rotateSpeed = 0.05f;
//		}

		moveSpeed = 3.0f;
		rotateSpeed = 0.2f;
		jumpVelocity = 5;
		
		if(v > 0.4){
			canJump = true;
			if(isGround){
				// Walk animation don't have a build in velocity, I have to add velocity to the body for it to mvoe forward
				myBody.velocity = moveSpeed * transform.forward;
//				transform.position += transform.TransformDirection(Vector3.forward) * 0.1f;
				anim.SetFloat("Speed",v);
				anim.SetBool("Run",true);
			}
		}else if(v < -0.4){
			canJump = false;
			if(isGround){
				myBody.velocity = moveSpeed * -transform.forward;
//				transform.position += transform.TransformDirection(Vector3.back) * 0.02f;
				anim.SetFloat("Speed",-v);
				anim.SetBool("Run",false);
			}
		}else{
			canJump = true;
			anim.SetFloat("Speed",0);
			anim.SetBool("Run",false);
		}
		if(isGround){
			if(h > 0.2){
//				transform.Rotate( Vector3.up * rotateSpeed * 20);
//				myBody.AddRelativeTorque(Vector3.up * 10);
				Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.deltaTime);
				rigidbody.MoveRotation(rigidbody.rotation * deltaRotation);
			}else if(h < -0.2){
//				transform.Rotate( Vector3.down * rotateSpeed * 20);
//				myBody.AddRelativeTorque(Vector3.down * 10);
				Quaternion deltaRotation = Quaternion.Euler(-eulerAngleVelocity * Time.deltaTime);
				rigidbody.MoveRotation(rigidbody.rotation * deltaRotation);
			}
		}
	}

	public void jump(){
//		print ("In jump script");
		// isGround to make sure player is touch ground
		// canJump to make sure player only can jump while not moving backward
		if (isGround && canJump){
//			if(v > 0){
//				print ("jump run");
////				float tempX = myBody.velocity.x;
////				float tempZ = myBody.velocity.z;
////				myBody.velocity = new Vector3(tempX,5,tempZ);
//				print (myBody.velocity);
//				myBody.velocity = myBody.velocity + new Vector3(0, 5f, 0);
//				print (myBody.velocity);
//			}else{
//				print ("stay jump");
//				myBody.velocity = jumpVelocity * Vector3.up;
//			}
			print (myBody.velocity);
			anim.SetTrigger ("Jump");
			myBody.velocity = myBody.velocity + new Vector3(0, 2f, 0);
			print (myBody.velocity);

//			anim.SetTrigger ("Jump");
//			myBody.velocity.y = jumpVelocity * Vector3.up;
//			myBody.velocity = jumpVelocity * Vector3.up;
		}
	}

	// With this on gravity with right
	void OnAnimatorMove() {
//		Animator animator = GetComponent<Animator>();
//		if (animator) {
//			Vector3 newPosition = transform.position;
//			newPosition.z += animator.GetFloat("Runspeed") * Time.deltaTime;
//			transform.position = newPosition;
//		}
	}

	public void moveH(float inputH){
		h = inputH;
	}
	
	public void moveV(float inputV){
		v = inputV;
	}
	public void run(){
		running = true;
	}
	public void walk(){
		running = false;
	}

	public void Attack(){
		if(hasWeapon)
			anim.SetTrigger ("Attack");
	}

	public void Dead(){
		anim.SetTrigger ("Dead");
		if (anim.GetCurrentAnimatorStateInfo(0).IsName("Dead"))
		{
			// Avoid any reload.
			print ("Dead");
			try{
				Thread.Sleep(2000);
			}catch{
				
			}
			Application.LoadLevel(Application.loadedLevel);
		}
	}
	public bool IsGround(){
		return isGround;
	}
}
