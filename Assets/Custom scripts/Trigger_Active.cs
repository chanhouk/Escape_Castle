using UnityEngine;
using System.Collections;

public class Trigger_Active : MonoBehaviour {
	public GameObject player;
	public GameObject speachBubble;
	public int child;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Cha_Knight 1");
		speachBubble = GameObject.Find ("Cha_Knight 1/Canvas_NPC");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player"){
			speachBubble.transform.GetChild(child).gameObject.SetActive(true);
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.tag == "Player"){
			speachBubble.transform.GetChild(child).gameObject.SetActive(false);
		}
	}
}
