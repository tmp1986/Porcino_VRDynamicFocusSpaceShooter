using UnityEngine;
using System.Collections;

//[ExecuteInEditMode]
public class setMaterial : MonoBehaviour {


	public Material mat;

	int v = 0;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(v < 2)
		{
		//	Setmaterial();

		}
	
	}



	void Setmaterial()
	{

		//for (int i = 1; i<5; i++) {
		foreach (Transform t in GameObject.Find("Plane").GetComponentsInChildren<Transform>()) 
		{

				t.gameObject.renderer.material = mat;

		}
		//		}


	}
}
