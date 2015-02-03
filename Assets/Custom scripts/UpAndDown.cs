using UnityEngine;
using System.Collections;

public class UpAndDown : MonoBehaviour {
	public bool delayed;
	float startY;
	// Use this for initialization
	void Start() {
		startY = transform.position.y;
	}
	
	// Update is called once per frame
	void Update() {
		if (!delayed) {
			transform.position = new Vector3(transform.position.x, startY - Mathf.PingPong(Time.time * 0.3f, 3), transform.position.z);
		}
		else {
			transform.position = new Vector3(transform.position.x, startY + Mathf.PingPong(Time.time * 0.3f, 3), transform.position.z);
		}
	}
}
