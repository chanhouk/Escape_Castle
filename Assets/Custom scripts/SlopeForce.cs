using UnityEngine;
using System.Collections;

public class SlopeForce : MonoBehaviour {
	public float Y = -1f;
	public float Z = -1f;
	void OnTriggerStay(Collider other) {
		if(other.name == "Cha_Knight 1"){
			other.transform.rigidbody.velocity += 1f * new Vector3(0, Y, Z);
		}
	}
}
