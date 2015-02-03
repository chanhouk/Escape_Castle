using UnityEngine;
using System.Collections;

public class Trigger_Hit : MonoBehaviour {
	public GameObject GameManager;
	public float hitPoint = 0f;
	// Use this for initialization
	void Start () {
		GameManager = GameObject.Find ("Manager_Universal");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider other) {
		if (other.tag == "Player"){
			GameManager.GetComponent<GameManager>().healthRemove(hitPoint);
		}
	}
}
