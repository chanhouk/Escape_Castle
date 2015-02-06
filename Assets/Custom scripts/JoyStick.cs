using UnityEngine;
using System.Collections;

public class JoyStick : TouchLogicV2//NOTE: This script has been updated to V2 after video recording
{
	public enum JoystickType {Movement, LookRotation, SkyColor};
	public JoystickType joystickType;
	public GameObject player = null;
	private float playerSpeed = 1.5f, maxJoyDelta = 0.1f;//, rotateSpeed = 100.0f;
	private Vector3 oJoyPos, joyDelta;
	private Transform joyTrans = null;
//	private float pitch = 0.0f, yaw = 0.0f;
	//cache initial rotation of player so pitch and yaw don't reset to 0 before rotating
//	private Vector3 oRotation;
	private Vector3 eulerAngleVelocity = new Vector3(0, 50, 0);
	public Animator anim;

	void Start ()
	{
		joyTrans = this.transform;
		oJoyPos = joyTrans.position;
		player = GameObject.Find("Cha_Knight 1");
		anim = player.transform.GetComponent<Animator> ();
		//cache original rotation of player so pitch and yaw don't reset to 0 before rotating
//		oRotation = player.eulerAngles;
//		pitch = oRotation.x;
//		yaw = oRotation.y;
	}
	public override void OnTouchBegan()
	{
		//Used so the joystick only pays attention to the touch that began on the joystick
		touch2Watch = TouchLogicV2.currTouch;
	}
	public override void OnTouchMovedAnywhere()
	{
		if(TouchLogicV2.currTouch == touch2Watch)
		{
			//move the joystick
			joyTrans.position = MoveJoyStick();
			ApplyDeltaJoy();
		}
	}
	public override void OnTouchStayedAnywhere()
	{
		if(TouchLogicV2.currTouch == touch2Watch)
		{
			ApplyDeltaJoy();
		}
	}
	public override void OnTouchEndedAnywhere()
	{
		//the || condition is a failsafe so joystick never gets stuck with no fingers on screen
		if(TouchLogicV2.currTouch == touch2Watch || Input.touches.Length <= 0)
		{
			//move the joystick back to its orig position
			joyTrans.position = oJoyPos;
			touch2Watch = 64;
		}
	}
	void ApplyDeltaJoy()
	{
		switch(joystickType)
		{
		case JoystickType.Movement:
			// Rotate left and right
			if(joyDelta.x < -0.4f){
				if(player.transform.GetComponent<CustomCharacterController>().IsGround()){
					Quaternion deltaRotation = Quaternion.Euler(-eulerAngleVelocity * Time.deltaTime);
					player.transform.rigidbody.MoveRotation(player.rigidbody.rotation * deltaRotation);
				}
			}else if(joyDelta.x > 0.4f){
				if(player.transform.GetComponent<CustomCharacterController>().IsGround()){
					Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.deltaTime);
					player.transform.rigidbody.MoveRotation(player.rigidbody.rotation * deltaRotation);
				}
			}
			// Move forward and backward
			if(joyDelta.z > 0.01){
				if(joyDelta.z > 0.9f){
					// Running
					if(player.transform.GetComponent<CustomCharacterController>().IsGround()){
						player.transform.rigidbody.velocity = (playerSpeed*2) * player.transform.forward;
						anim.SetFloat("Speed",0.6f);
					}
				}else{
					// Walking
					if(player.transform.GetComponent<CustomCharacterController>().IsGround()){
						player.transform.rigidbody.velocity = playerSpeed * player.transform.forward;
						anim.SetFloat("Speed",0.2f);
					}
				}
			}else if(joyDelta.z < -0.01){
				if(player.transform.GetComponent<CustomCharacterController>().IsGround()){
					player.transform.rigidbody.velocity = playerSpeed * -player.transform.forward;
					anim.SetFloat("Speed",0.2f);
				}
			}else{
				anim.SetFloat("Speed",0f);
			}
			break;
		case JoystickType.LookRotation:
			// Do nothing at the moment
//			pitch -= Input.GetTouch(touch2Watch).deltaPosition.y * rotateSpeed * Time.deltaTime;
//			yaw += Input.GetTouch(touch2Watch).deltaPosition.x * rotateSpeed * Time.deltaTime;
//			//limit so we dont do backflips
//			pitch = Mathf.Clamp(pitch, -80, 80);
//			//do the rotations of our camera
//			player.eulerAngles += new Vector3 ( pitch, yaw, 0.0f);
			break;
		case JoystickType.SkyColor:
			// Do nothing at the moment
//			Camera.mainCamera.backgroundColor = new Color(joyDelta.x, joyDelta.z, joyDelta.x*joyDelta.z);
			break;
		}
	}
	Vector3 MoveJoyStick()
	{
		//convert the touch position to a % of the screen to move our joystick
		float x = Input.GetTouch (touch2Watch).position.x / Screen.width,
		y = Input.GetTouch (touch2Watch).position.y / Screen.height;
		//combine the floats into a single Vector3 and limit the delta distance
		
		//If you want a rectangularly limited joystick (used in video), use this
//		Vector3 position = new Vector3 (Mathf.Clamp(x, oJoyPos.x - maxJoyDelta, oJoyPos.x + maxJoyDelta),
//		                                Mathf.Clamp(y, oJoyPos.y - maxJoyDelta, oJoyPos.y + maxJoyDelta), 0);

		//use Vector3.ClampMagnitude instead if you want a circular clamp instead of a square
		//If you want a circularly limited joystick, use this (uncomment it)
		Vector3 position = Vector3.ClampMagnitude(new Vector3 (x-oJoyPos.x, y-oJoyPos.y, 0), maxJoyDelta) + oJoyPos;
		
		
		//joyDelta used for moving the player
		joyDelta = new Vector3(position.x - oJoyPos.x, 0, position.y - oJoyPos.y).normalized;
		//position used for moving the joystick
		return position;
	}
	void LateUpdate()
	{
//		if(!troller.isGrounded)
//			troller.Move(Vector3.down * 2);
	}
}