using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using System;

public class Heuristicas : MonoBehaviour {
	
	public GameObject Campo;
	

	public GameObject Focus;
	// Use this for initialization

	public string nomeDoGrupo = "OBJECTS";
	public float interpolation_Speed = 2.4f;
	public Vector3 lastPos;


	public List<float> P = new List<float>();

	public List<string> ResultadosFinais  = new List<string>();
	
//-------------------------------------------DADOS DE OUTROS SCRIPTS
	public GameObject sourceGameObjectScripts;
	public List<string> raycasterResult = new List<string> ();
 

//------------------------------------------------------------------
	public float raycasterMaxDistance = 0.0f;
	public float raycasterFullPoints = 0.0f;

	public GameObject rayCastSource;

	public float farClipPlane = 0;

	RaycastHit hit;
	private Collider[] c ;
	void Start () 
	{

		P.Add (0.3f);
		P.Add (0.5f);
		P.Add (0.2f);
		farClipPlane = GameObject.Find("LeftEyeAnchor").GetComponent<Camera>().farClipPlane;
		//for(int i=0; i<3; i++)
		//{
	//		P.Add (0.25f);
	//	}

		sourceGameObjectScripts = new GameObject ();
		sourceGameObjectScripts = GameObject.Find("First Person Controller - DOF");

		Focus = GameObject.Find ("Focus");
		lastPos = new Vector3 (0,0,0);


		LayeredRayCaster lrc = sourceGameObjectScripts.GetComponent<LayeredRayCaster>();


		for (int i =1 ; i<lrc.layerCount + 1; i++)
		{
			raycasterFullPoints += lrc.raysCountPerLayer * i;
		
		}

	}


	void Update()
	{
	//	ResultadosFinais.OrderByDescending (p => p.Split (',') [3]);
		LayeredRayCaster lrc = sourceGameObjectScripts.GetComponent<LayeredRayCaster>();
		raycasterResult = lrc.listOfResults;
		raycasterMaxDistance = lrc.maxDistanceHitedObject;
		string _n = "";
		float _tmp = 0.0f;
		foreach (var str in ResultadosFinais) 
		{
			if (_tmp < float.Parse(str.Split(',').Last()))
			{
				_tmp = float.Parse(str.Split(',').Last());
				_n = str.Split(',')[0];
			}

		}

		GameObject.Find ("LeftEyeAnchor").GetComponent<Camera> ().fieldOfView = 80;
		GameObject.Find ("RightEyeAnchor").GetComponent<Camera> ().fieldOfView = 80;
						
		if (Physics.Raycast (rayCastSource.transform.position, rayCastSource.transform.forward, out hit, farClipPlane)) 
		{
						Debug.DrawLine (rayCastSource.transform.position, hit.point, Color.blue);

						this.gameObject.SendMessage ("posSphere", hit.point);

						calculaHeuristica();

						GameObject _go = GameObject.Find(_n);

			try
			{
						Focus.transform.position = new Vector3 (_go.transform.position.x,hit.point.y, _go.transform.position.z);
						Focus.transform.position = new Vector3 (Mathf.Lerp (lastPos.x, _go.transform.position.x, Time.deltaTime * interpolation_Speed), Mathf.Lerp (lastPos.y, hit.point.y, Time.deltaTime * interpolation_Speed), Mathf.Lerp (lastPos.z, _go.transform.position.z, Time.deltaTime * interpolation_Speed));	
						lastPos = Focus.transform.position; 
			}
			catch
			{

			}

		} 
	} 

	public float FormalizeToPercent(float value, float total, string tipo)
	{
		float r = (value / total) * 100;
		r = Mathf.Round(r);
		//DebugConsole.print (tipo + " (" + value.ToString () + " / " + total.ToString () + ")* 100" +  " = " + r.ToString() + "%");

		return r;
	}

	public List<string> calculaHeuristica()
	{
		ResultadosFinais.Clear ();
		//gameobject,weight,distance3d,distancescreen,imp
		List<string> sfinal = new List<string> ();

		foreach (string s in raycasterResult) 
		{

			GameObject go = GameObject.Find(s.Split(',')[0]);



			//DebugConsole.print ("-----------------------------------------------------------------");
			//DebugConsole.print (go.name);

			float value = FormalizeToPercent(System.Convert.ToInt16(s.Split(',')[1]),raycasterFullPoints,go.name +  " raycast");

			//X,Y,Z da Camera
			float CampoX = Campo.transform.position.x;
			float CampoY = Campo.transform.position.y;
			float CampoZ = Campo.transform.position.z;
			
			//X,Y,Z do objeto alvo
			float TargetX = go.transform.position.x;
			float TargetY = go.transform.position.y;
			float TargetZ = go.transform.position.z;

			//distancia entre o object alvo e a camera
			float distance = Mathf.Sqrt (Mathf.Pow(CampoX - TargetX, 2) + Mathf.Pow(CampoY - TargetY, 2) + Mathf.Pow(CampoZ - TargetZ, 2));

			distance = FormalizeToPercent(distance,farClipPlane,go.name + " distancia");

			//Vector3 sp = Camera.main.WorldToScreenPoint(TargetX,TargetY,TargetZ);

			float totalScreenDistance = 1;
			//distancia do objeto ao centro da tela

			Vector2 TargetPixelPos = Camera.main.WorldToScreenPoint(new Vector3(TargetX,TargetY,TargetZ)); //- Screen.width/2;

			float screenDistance = Mathf.Sqrt(Mathf.Pow(TargetPixelPos.x - Screen.width/2, 2) + Mathf.Pow(TargetPixelPos.y - Screen.height/2, 2));

			totalScreenDistance = Mathf.Sqrt(Mathf.Pow(Screen.width, 2) + Mathf.Pow(Screen.height, 2));

			//screenDistance = FormalizeToPercent(screenDistance, totalScreenDistance, "screenDistance");

			float _imp =  FormalizeToPercent(go.GetComponent<imp>().IMP,10,go.name + " importancia");
			//float result = ((P[0] * value) + (P[1] * -1 * distance) + (P[2] * screenDistance) +  (P[3] * ( _imp)));

			//print ("distancia do objeto: " + (100 - distance).ToString() + "%");	

			float result = ((P[0] * value) + (P[1] * (100 - distance)) + (P[2] * ( _imp)));
			sfinal.Add(s.Split(',')[0] + "," + result.ToString() );



			/*
			print(s.Split(',')[0] + "\nRaiCaster: " + (P[0] * value).ToString());
			print ("DepthDistance: " + (P[1] * distance).ToString());
			print ("ProjectionDistance: " + (P[2] * screenDistance).ToString());
			print("Importance: " + (P[3] * ( _imp)).ToString());
			*/


			//DebugConsole.print("---------------------------------------------------------");

		}

		List<string> ff = new List<string> ();
		ff.AddRange(sfinal.OrderByDescending (p => p.Split (',')[1]).ToList());

		ResultadosFinais.AddRange(ff);
		//print ("3 > " + sfinal.Count.ToString ());
		
		return ff;
		

	}

	
}







