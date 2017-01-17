using UnityEngine;
using System.Collections;

public class Nave : MonoBehaviour {


	public int LifePoints;

	int maxTextures = 10;
	int arrayPos = 0;
	public Texture[] myTextures = new Texture[10];
	// Use this for initialization
	void Start () 
	{
	
		GameObject.FindGameObjectWithTag("LIFEBAR").renderer.material.mainTexture = myTextures[arrayPos];

	}
	
	void Update() {

	}

	void OnTriggerEnter  (Collider other) 
	{

		

				if (other.transform.gameObject.tag == "METEORO") 
				{
					LifePoints = LifePoints - 10;
					//if (LifePoints <= 0)
					//{
						//Application.LoadLevel(1);
					//}
		//GameObject.Find ("First Person Controller - DOF").GetComponent<CameraShake>().Shake (2000f,0.7f,1.0f);
	
				
			try
			{
				if(arrayPos >= maxTextures)
				{

					arrayPos = maxTextures;
					Application.LoadLevel(2);
				}
				else
				{
					arrayPos++;
					GameObject.FindGameObjectWithTag("LIFEBAR").renderer.material.mainTexture = myTextures[arrayPos];
				}
			}
			catch
			{
			}
				
		}
	
	
	}


}
