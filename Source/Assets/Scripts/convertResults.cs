using UnityEngine;
using System.Collections;

public class convertResults : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		//print(FormalizeToPercent (10, 100).ToString() + "%");
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public float FormalizeToPercent(float value, float total)
	{
		float r = (value * total) / 100;
		return r;
	}
}
