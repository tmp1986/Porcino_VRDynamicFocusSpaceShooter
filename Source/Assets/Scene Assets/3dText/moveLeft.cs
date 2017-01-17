using UnityEngine;
using System.Collections;

public class moveLeft : MonoBehaviour {


	public int speedText = 1;

	Vector3 p;

	bool status = false;
	// Use this for initialization
	void Start () {
	
		p = this.gameObject.transform.position;

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.T)) 
		{	
			status = !status;
		}
	
		if (status) 
		{
			this.gameObject.transform.position = new Vector3 (this.gameObject.transform.position.x + speedText * -Time.deltaTime, p.y, p.z);
		}
	}
}
