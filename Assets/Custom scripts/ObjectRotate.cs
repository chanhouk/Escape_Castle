using UnityEngine;
using System.Collections;

public class ObjectRotate : MonoBehaviour {
	public bool turn = false;
	private Vector3 eulerAngleVelocity = new Vector3(0, 100, 0);
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(turn){
//			transform.Rotate(Vector3.down * Time.deltaTime *45);
			Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.deltaTime);
			rigidbody.MoveRotation(rigidbody.rotation * deltaRotation);
		}else{
//			transform.Rotate(Vector3.up * Time.deltaTime *45);
			Quaternion deltaRotation = Quaternion.Euler(-eulerAngleVelocity * Time.deltaTime);
			rigidbody.MoveRotation(rigidbody.rotation * deltaRotation);
		}
	}
}
