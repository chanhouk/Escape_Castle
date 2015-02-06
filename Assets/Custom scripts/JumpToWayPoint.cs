using UnityEngine;
using System.Collections;

public class JumpToWayPoint : MonoBehaviour {
	public GameObject JumpWayPoint;
	private GameObject player;
	void Start ()
	{
		player = GameObject.Find ("Cha_Knight 1");
	}
	void OnTriggerEnter(Collider other)
	{
		if(other.name == "Skeleton_Root")
		{
			player.transform.position = JumpWayPoint.transform.position;
		}
	}
}
