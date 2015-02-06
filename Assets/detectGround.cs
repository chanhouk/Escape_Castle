using UnityEngine;
using System.Collections;

public class detectGround : MonoBehaviour {
	public Animator anim;
	public CapsuleCollider SRoot;

	void Start()
	{
		SRoot = this.GetComponent<CapsuleCollider>();
	}
	void OnCollisionEnter(Collision collision) {
		print ("Enter");
		if (collision.transform.tag == "Ground") {
			anim.SetBool("isGrounded",true);
		}
	}
	void OnCollisionExit(Collision collision) {
		print ("Exit");
		if (collision.transform.tag == "Ground") {
			anim.SetBool("isGrounded",false);
		}
	}

	void Update()
	{
	}
}
