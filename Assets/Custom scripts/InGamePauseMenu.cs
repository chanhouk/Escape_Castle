using UnityEngine;
using System.Collections;

public class InGamePauseMenu : MonoBehaviour {
	public GameObject inGameMenu;
	// Use this for initialization
	void Start () {

	}

	void Awake() {

	}
	
	// Update is called once per frame
	void Update () {
		// This does work but The UI button OnClick event can not load the method from here if not in scene form start to set up
		try{
			if (inGameMenu == null) {
				try {
					inGameMenu = GameObject.Find ("Canvas_PauseMenu");
				} catch {
					Debug.Log ("Cannot find Canvas_PauseMenu game object");
				}
			}
		}catch{
			Debug.Log ("Cannot find Canvas_PauseMenu game object");
		}
	}

	public void DisplayInGameMenu(){
		Time.timeScale = 0;
//		inGameMenu.
		inGameMenu.SetActive (true);
	}

	public void BackToMainMenu(){
		Time.timeScale = 1;
		Application.LoadLevel ("MainMenu");
//		Application.LoadLevel ("00");
	}

	public void ResumeGame(){
		inGameMenu.SetActive (false);
		Time.timeScale = 1;
	}

	public void RestartGame(){
		Application.LoadLevel (Application.loadedLevel);
		Time.timeScale = 1;
	}
}
