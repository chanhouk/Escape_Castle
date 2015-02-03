using UnityEngine;
using System.Collections;

public class NextLevelTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			int temp = PlayerPrefs.GetInt("playerLifes");
			temp += 1;
			PlayerPrefs.SetInt("playerLifes",temp);
			// This check if there more levels to move on else back to the main menu
			if(Application.loadedLevel < Application.levelCount-1){
				Application.LoadLevel(Application.loadedLevel+1);
			}else{
				Application.LoadLevel("00");
			}
		}
	}
}
