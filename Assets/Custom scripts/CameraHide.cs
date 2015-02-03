using UnityEngine;
using System.Collections;

public class CameraHide : MonoBehaviour {
	RaycastHit oldHit;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void FixedUpdate() {
		XRay ();
	}
	
	// Hacer a los objetos que interfieran con la vision transparentes
	private void XRay() {

		print ("In Xray");
		float characterDistance = Vector3.Distance(transform.position, GameObject.Find("Knight").transform.position);
		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		
		RaycastHit hit;
		if (Physics.Raycast(transform.position, fwd, out hit, characterDistance)) {
			if(oldHit.transform) {
				print ("In hit");
				// Add transparence
				Color colorA = oldHit.transform.gameObject.renderer.material.color;
				colorA.a = 1f;
				oldHit.transform.gameObject.renderer.material.SetColor("_Color", colorA);
			}
			
			// Add transparence
			Color colorB = hit.transform.gameObject.renderer.material.color;
			colorB.a = 0.5f;
			hit.transform.gameObject.renderer.material.SetColor("_Color", colorB);
			
			// Save hit
			oldHit = hit;
		}
	}
}