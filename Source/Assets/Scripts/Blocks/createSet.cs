using UnityEngine;
using System.Collections;
//[ExecuteInEditMode]
public class createSet : MonoBehaviour {

	

	int v = 0;
	// Use this for initialization
	public void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{	if (v < 8) 
		{
			//createColumn(50);
			//createPlane ();
			v++;
		}
		
	}
	
	public void createPlane(int tamanho) 
	{
		for (int i=0; i<tamanho; i++) 
		{
			for (int j=0;j<tamanho;j++)
			{
				GameObject cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
				cube.transform.position = new Vector3 (i, 0, j);
				cube.name = i.ToString() +"x"+ j.ToString()+"_floor";
			}
		}
	}

	public void createColumn(int tamanho) 
	{
		for (int i=0; i<tamanho; i++) 
		{
			for (int j=0;j<10;j++)
			{
				GameObject cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
				cube.transform.position = new Vector3 (i, j, 0);
				cube.name = i.ToString() +"x"+ j.ToString()+"_wall04";
			}
		}
	}
}
