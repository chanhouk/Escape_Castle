using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public int playerLife;
	public int hasWeapon;
	public float health;
	public Image LifeBar;
	public GameObject player;
	public Image myImage;
	// Use this for initialization
	void Start () {
		if(Application.loadedLevel != 0){
			player = GameObject.Find("Cha_Knight 1");
			myImage = LifeBar.GetComponent<Image>();
		}
		playerLife = PlayerPrefs.GetInt ("playerLifes");
		hasWeapon = PlayerPrefs.GetInt ("hasWeapon");
		health = 1f;
	}

	void Awake() {
//		print ("Awake");
//		PlayerPrefs.SetInt ("playerLifes", 3);
//		playerLife = PlayerPrefs.GetInt ("playerLifes");
	}
	
	// Update is called once per frame
	void Update () {
		if(PlayerPrefs.GetInt("playerLifes") < 0){
			Application.LoadLevel("00");
		}
		if(Application.loadedLevel != 0){
			myImage.fillAmount = health;
		}
		if(health < 0.01){
			int temp = PlayerPrefs.GetInt("playerLifes");
			temp -= 1;
			PlayerPrefs.SetInt("playerLifes",temp);
			player.GetComponent<CustomCharacterController>().Dead();
			// For text health bar
//			health = 100f;
			Application.LoadLevel(Application.loadedLevel);
		}
	}

	public void NewGame(){
		Application.LoadLevel ("01");
	}

	public void Level(){
		Application.LoadLevel ("99");
	}

	public void Quit(){
		Application.Quit ();
	}

	// button test
	public void PlusLife(){
		playerLife += 1;
		PlayerPrefs.SetInt ("playerLifes", playerLife);
	}
	// button test
	public void SubtractLife(){
		playerLife -= 1;
		PlayerPrefs.SetInt ("playerLifes", playerLife);
	}
	public void healthRemove(float hit){
		health -= hit;
	}
}
