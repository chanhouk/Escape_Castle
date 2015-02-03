using UnityEngine;
using System.Collections;

public class FireLightEffect : MonoBehaviour {

	private Light fireLight;
	public float minIntensity = 1.0f;
	public float maxIntensity = 2.0f;
	private float random;
	// Use this for initialization
	void Start () {
		random = Random.Range(0.0f, 65535.0f);
		fireLight = transform.light;
	}
	
	// Update is called once per frame
	void Update () {
		float noise = Mathf.PerlinNoise(random, Time.time);
		fireLight.intensity = Mathf.Lerp(minIntensity, maxIntensity, noise);
	}
}