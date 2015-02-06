using UnityEngine;
using System.Collections;

public class testController : MonoBehaviour {

	public Animator anim;
	public Transform cameraTransform;
	public ConstantForce myBodyConForce;

	public Transform myTrans;
	public Rigidbody myBody;

	public float v,h;
	private Vector3 eulerAngleVelocity = new Vector3(0, 100, 0);

	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator> ();
		
//		myBody = GameObject.Find ("Cha_Knight 1/Group Locator/Root/Skeleton_Root").transform.rigidbody;
		myBody = this.rigidbody;
		myTrans = this.transform;
		myBodyConForce = this.GetComponent<ConstantForce>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		move ();
		if(Input.GetButtonDown("Jump"))
		{
			jump ();
		}
		if(anim.GetBool("jumping"))
		{
//			print ("set 0");
			myBodyConForce.relativeForce = new Vector3(0,0,0);
		}else{
//			print ("set -100");
			myBodyConForce.relativeForce = new Vector3(0,-100,0);
		}
	}
	void OnCollisionEnter(Collision collision) {
		if (collision.transform.tag == "Ground") {
			anim.SetBool("isGrounded",true);
			anim.SetBool("jumping",false);
		}
	}
	void OnCollisionStay(Collision collision) {
		if (collision.transform.tag == "Ground") {
			anim.SetBool("isGrounded",true);
		}
	}
	void OnCollisionExit(Collision collision) {
		if (collision.transform.tag == "Ground") {
			anim.SetBool("isGrounded",false);
		}
	}
	public void move()
	{
		#if !UNITY_ANDROID && !UNITY_IPHONE && !UNITY_BLACKBERRY && !UNITY_WINRT || UNITY_EDITOR
			v = Input.GetAxisRaw("Vertical");
			h = Input.GetAxisRaw("Horizontal");
		#endif

		if(!anim.GetBool ("isGrounded"))
		{
			if(!anim.GetBool ("jumping"))
			{
				v = 0f;
				h = 0f;
			}
		}

		// detect forward or backward or idle
		if(v > 0.4){	// forward
			anim.SetBool("Run",true);
			if(anim.GetBool("isGrounded")){
				// Walk animation don't have a build in velocity, I have to add velocity to the body for it to mvoe forward
//				myBody.velocity = 3.0f * transform.forward;
//				transform.position += transform.TransformDirection(Vector3.forward) * 0.1f;
				anim.SetFloat("Speed",v);
			}else if(anim.GetBool("jumping")){
				// this will make character able to make forward while jumped in air
				print ("Jumping add force");
				myBody.velocity = 3.0f *transform.forward;
			}
		}else if(v < -0.4){	// backward
			anim.SetBool("Run",false);
			anim.SetBool ("backward",true);
			if(anim.GetBool("isGrounded")){
				myBody.velocity = 1.5f * -transform.forward;
//				transform.position += transform.TransformDirection(Vector3.back) * 0.02f;
				anim.SetFloat("Speed",v);
			}
		}else{	// idle
			anim.SetFloat("Speed",0);
			anim.SetBool("Run",false);
			anim.SetBool ("backward",false);
		}

		// rotate left or right
		if(h > 0.2){	// Left
			if(anim.GetBool("isGrounded")){
//				transform.Rotate( Vector3.up * rotateSpeed * 20);
//				myBody.AddRelativeTorque(Vector3.up * 10);
				Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.deltaTime);
				rigidbody.MoveRotation(rigidbody.rotation * deltaRotation);
			}
		}else if(h < -0.2){	// Right
			if(anim.GetBool("isGrounded")){
//				transform.Rotate( Vector3.down * rotateSpeed * 20);
//				myBody.AddRelativeTorque(Vector3.down * 10);
				Quaternion deltaRotation = Quaternion.Euler(-eulerAngleVelocity * Time.deltaTime);
				rigidbody.MoveRotation(rigidbody.rotation * deltaRotation);
			}
		}
	}
	public void jump()
	{	
//		anim.SetTrigger ("Jump");
		if(anim.GetBool ("isGrounded") && anim.GetFloat ("Speed") > -0.1f)
		{
			anim.SetBool ("jumping", true);
		}
	}
	public void moveH(float inputH){
		h = inputH;
	}
	
	public void moveV(float inputV){
		v = inputV;
	}
}
