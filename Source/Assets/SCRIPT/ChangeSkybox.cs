using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ChangeSkybox : MonoBehaviour {

	public List<Material> skyboxList = new List<Material>();

	//public Material currentSkybox; 
	public int pontos;
	// Use this for initialization
	void Start () {
	
	changeSkybox (skyboxList [0]);
		//pontos = 0;
		//PlayerPrefs.SetInt ("PlayerScore", 0);
	}
	
	// Update is called once per frame
	void Update () 
	{
		SkyboxUpdate ();
	
	}


	public void changeSkybox(Material otherSkybox)
	{

			RenderSettings.skybox = otherSkybox;
	
	}

	public void changeSkybox(int index)
	{

			RenderSettings.skybox = skyboxList [index];
	

	}

	void SkyboxUpdate()
	{
		pontos = PlayerPrefs.GetInt("PlayerScore");
		//print (pontos.ToString ());
		//int pontos = System.Convert.ToInt32 (p);

		if (pontos < 500) 
		{
			changeSkybox(0);
		}
		if (pontos > 500 && pontos < 1000) 
		{
			changeSkybox(1);
		}
		if (pontos > 1000 && pontos < 1500) 
		{
			changeSkybox(2);
		}
		if (pontos > 1500 && pontos < 2000) 
		{
			changeSkybox(2);
		}
		if (pontos > 2000 && pontos < 3000) 
		{
			changeSkybox(2);
		}
		if (pontos > 3000 && pontos < 4000) 
		{
			changeSkybox(3);
		}
		if (pontos > 4000 && pontos < 5000) 
		{
			changeSkybox(4);
		}
		if (pontos > 4000 && pontos < 5000) 
		{
			changeSkybox(5);
		}
		
	}
}
