using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System;

public class UIInput : MonoBehaviour, IPointerDownHandler
{
	public List<Action<PointerEventData>> OnMouseDownListeners = new List<Action<PointerEventData>>();
	
	public void OnPointerDown(PointerEventData eventData)
	{
		foreach (var callback in OnMouseDownListeners)
		{
			print ("loop");
			callback(eventData);
		}
	}
	
	public void AddOnMouseDownListener(Action<PointerEventData> action)
	{
		print ("loop2");
		OnMouseDownListeners.Add(action);
	}

	void OnMouseDown() {
		print ("loop3");
	}
}