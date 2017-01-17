using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
public class multiplesRays : MonoBehaviour {


	Ray ray = new Ray(GameObject.Find("CenterEyeAnchor").transform.position, GameObject.Find("CenterEyeAnchor").transform.forward);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{

		RaycastHit hit;

		if (Physics.Raycast (ray, out hit, 10000)) 
		{
			Debug.DrawLine (ray.origin, new Vector3(hit.point.x - 1,hit.point.y,hit.point.z));
			//Debug.DrawLine (ray.origin, hit.point * 0.25);
			print ("HIT2: " + hit.collider.gameObject.name);
		}
	
	}
}
