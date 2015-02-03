using UnityEngine;
using System.Collections;

public class LifeManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		// This script only run at start menu on start
		PlayerPrefs.SetInt ("playerLifes", 3);
		if(PlayerPrefs.GetInt("hasWeapon") == null){
			PlayerPrefs.SetInt("hasWeapon",0);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
