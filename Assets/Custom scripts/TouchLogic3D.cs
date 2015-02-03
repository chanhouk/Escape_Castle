using UnityEngine;
using System.Collections;

public class TouchLogic3D : MonoBehaviour 
{
	public static int currTouch = 0;//so other scripts can know what touch is currently on screen
	private int touch2Watch = 64;
	private Ray ray;//this will be the ray that we cast from our touch into the scene
	private RaycastHit rayHitInfo = new RaycastHit();//return the info of the object that was hit by the ray
	private ITouchable3D touchedObject = null;
	
	void Update () 
	{
		for(int i = 0; i < Input.touchCount; i++)
		{
			currTouch = i;
			ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);//creates ray from screen point position
			//if the ray hit something, only if it hit something
			if(Physics.Raycast(ray, out rayHitInfo))
			{
				//if the thing that was hit implements ITouchable3D
				touchedObject = rayHitInfo.transform.GetComponent(typeof(ITouchable3D)) as ITouchable3D;
				//Debug.Log (touchedObject);
				//If the ray hit something and it implements ITouchable3D
				if (touchedObject != null)
				{
					switch(Input.GetTouch(i).phase)
					{
					case TouchPhase.Began:
						touchedObject.OnTouchBegan();
						touch2Watch = currTouch;
						break;
					case TouchPhase.Ended:
						touchedObject.OnTouchEnded();
						break;
					case TouchPhase.Moved:
						touchedObject.OnTouchMoved();
						break;
					case TouchPhase.Stationary:
						touchedObject.OnTouchStayed();
						break;
					}
				}
			}
			//On Anywhere
			else if (touchedObject != null && touch2Watch == currTouch)
			{
				switch(Input.GetTouch(i).phase)
				{
				case TouchPhase.Ended:
					touchedObject.OnTouchEndedAnywhere();
					touchedObject = null;
					break;
				case TouchPhase.Moved:
					touchedObject.OnTouchMovedAnywhere();
					break;
				case TouchPhase.Stationary:
					touchedObject.OnTouchStayedAnywhere();
					break;
				}
			}
		}
	}
}