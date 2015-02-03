using UnityEngine;
using System.Collections;

public class RayBetweenMainCameraAndPlayer : MonoBehaviour {
//	private Transform prevTransObject;
//	public Color alphaValue = 0.5f; // our alpha value
//	public List<int> transparentLayers = new List<int>();   // transparency layers.
//	public float maxDistance = 20f; // Max distance from target to camera object.
//	// Use this for initialization
//	void Start () {
//	
//	}
//
//	// Update is called once per frame
//	void Update () {
//		Ray ray = new Ray(Camera.main.transform.position, (target.transform.position - Camera.main.transform.position).normalized);
//		RaycastHit transHit;
//		if (Physics.Raycast(ray, out transHit, maxDistance))
//		{
//			Transform objectHit = transHit.transform;
//			if(transparentLayers .Contains(objectHit.gameObject.layer))
//			{
//				if(prevTransObject != null)
//				{
//					prevTransObject.renderer.material.color = new Color(1,1,1,1);
//				}
//				
//				if(objectHit.renderer != null)
//				{
//					prevTransObject = objectHit;
//					
//					// Can only apply alpha if this material shader is transparent.
//					prevTransObject.renderer.material.color = new Color(1,1,1, alphaValue);
//				}
//			}
//			else if(prevTransObject != null)
//			{
//				prevTransObject.renderer.material.color = new Color(1,1,1,1);
//				prevTransObject = null;
//			}
//		}
//	}
}
