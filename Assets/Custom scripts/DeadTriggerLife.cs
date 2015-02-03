using UnityEngine;
using System.Collections;

public class DeadTriggerLife : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			int temp = PlayerPrefs.GetInt("playerLifes");
			temp -= 1;
			PlayerPrefs.SetInt("playerLifes",temp);
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}
