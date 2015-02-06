using UnityEngine;
using System.Collections;

public class CompleteTut : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			PlayerPrefs.SetInt("tutorialComplete",1);
		}
	}
}
