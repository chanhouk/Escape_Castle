using UnityEngine;
using System.Collections;

public class LifeManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		// This script only run at start menu on start
		PlayerPrefs.SetInt ("playerLifes", 3);
		// boolean to check if the player character has weapon or check if Prefs is game
		if(PlayerPrefs.GetInt("hasWeapon") == null){
			PlayerPrefs.SetInt("hasWeapon",0);
		}
		// boolean to check if player has complete the tutorial for the first time or check if Prefs is game
		if(PlayerPrefs.GetInt ("tutorialComplete") == null){
			PlayerPrefs.SetInt ("tutorialComplete",0);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
