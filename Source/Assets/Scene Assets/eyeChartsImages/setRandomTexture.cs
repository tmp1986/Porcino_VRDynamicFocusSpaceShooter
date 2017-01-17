using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;


public class setRandomTexture : MonoBehaviour {

	//public List<Material> listMaterial = new List<Material>();
	// Use this for initialization
	//public List<string> parPlacaTextura = new List<string>();

	public string final = "";

	void Start () 
	{
		//parPlacaTextura.Clear ();

		//Setmaterial ();
		//EnableParticles(false);
		//EnableNeve (false);
		Plugin(true);
	}



	bool state = true;
	bool state2 = true;
	bool state3 = false;
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.O)) 
		{
			Plugin(state3);
			state3 = !state3;
		}
//		if (Input.GetKeyDown (KeyCode.I)) 
//		{
//			GameObject.Find("LeftEyeAnchor").GetComponent<DepthOfField>().aperture = GameObject.Find("LeftEyeAnchor").GetComponent<DepthOfField>().aperture + 1;
//			GameObject.Find("RightEyeAnchor").GetComponent<DepthOfField>().aperture = GameObject.Find("RightEyeAnchor").GetComponent<DepthOfField>().aperture + 1;
//		}
//		if (Input.GetKeyDown (KeyCode.K)) 
//		{
//			GameObject.Find("LeftEyeAnchor").GetComponent<DepthOfField>().aperture = GameObject.Find("LeftEyeAnchor").GetComponent<DepthOfField>().aperture - 1;
//			GameObject.Find("RightEyeAnchor").GetComponent<DepthOfField>().aperture = GameObject.Find("RightEyeAnchor").GetComponent<DepthOfField>().aperture - 1;
//		}
//
//		if (Input.GetKeyDown (KeyCode.P)) 
//		{
//			EnableParticles(state);
//			state = !state;
//		}
//		if (Input.GetKeyDown (KeyCode.N)) 
//		{
//			EnableNeve(state2);
//			state2 = !state2;
//		}
//
//		if (Input.GetKeyDown (KeyCode.U)) 
//		{
//
//			Setmaterial ();
//		}
//
//		if (Input.GetKeyDown (KeyCode.Alpha1)) 
//		{
//			load (0);
//		}
//		if (Input.GetKeyDown (KeyCode.Alpha2)) 
//		{
//			load (1);
//		}
//		if (Input.GetKeyDown (KeyCode.Alpha3)) 
//		{
//			load (2);
//		}
//		if (Input.GetKeyDown (KeyCode.Alpha4)) 
//		{
//			load (3);
//		}
//
//		if (Input.GetKeyDown(KeyCode.L))
//		{
//			bool state = GameObject.Find("LeftEyeAnchor").GetComponents<DepthOfField>()[0].enabled;
//
//			GameObject.Find("LeftEyeAnchor").GetComponents<DepthOfField>()[0].enabled = !state;
//			GameObject.Find("LeftEyeAnchor").GetComponents<DepthOfField>()[1].enabled = !state;
//		}
//
//		if (Input.GetKeyDown(KeyCode.R))
//		{
//			bool state = GameObject.Find("RightEyeAnchor").GetComponents<DepthOfField>()[0].enabled;
//
//
//			GameObject.Find("RightEyeAnchor").GetComponents<DepthOfField>()[0].enabled = !state;
//			GameObject.Find("RightEyeAnchor").GetComponents<DepthOfField>()[1].enabled = !state;
//		}
	}

//	void Setmaterial()
//	{
//		parPlacaTextura.Clear ();
//		final = "";
//		foreach (GameObject g in GameObject.FindGameObjectsWithTag("Chart")) 
//		{
//			int r = Random.Range(0,listMaterial.Count);
//			g.renderer.material = listMaterial[r];
//
//		}
//
//		foreach (GameObject g in GameObject.FindGameObjectsWithTag("Chart")) 
//		{
//			parPlacaTextura.Add(g.name.Replace("EyeChart","Placa") + "," + g.renderer.material.name.Replace("(Instance)","") + "|");
//		}
//
//		//System.IO.File.WriteAllText("C:/PlayerSets.txt",string.Empty);
//		foreach (string s in parPlacaTextura)
//		{
//
//			final = final + s;
//		}
//
//
//
//
//		List<string> ff = new List<string> ();
//		parPlacaTextura = parPlacaTextura.OrderBy(p => p.Split (',') [0]).ToList ();
//
//
//		writeFile (final);
//
//	}

//	void EnableParticles(bool state)
//	{
//
//		List<GameObject> p = new List<GameObject> ();
//		p.AddRange (GameObject.FindGameObjectsWithTag ("Particules"));
//
//		foreach (GameObject g in p) 
//		{
//			g.GetComponent<ParticleSystem>().enableEmission = state;
//		}
//		
//	}
//
//	void EnableNeve(bool state2)
//	{
//		
//		GameObject g = new GameObject();
//		g = GameObject.Find("NEVE");
//		
//		g.GetComponent<ParticleSystem>().enableEmission = state2;
//
//		
//	}
//
//	void writeFile(string s) 
//	{
//		FileInfo fi = new FileInfo(@"C:/1.txt");
//
//		using(TextWriter txtWriter = new StreamWriter(fi.Open(FileMode.Create)))
//		{
//			txtWriter.WriteLine(s);
//		}
//
//
//	}
//
//	public void load(int n)
//	{
//		Application.LoadLevel(n);
//	}


	public void Plugin(bool state)
	{
		if (state) 
		{
//			GameObject LUZ1 = GameObject.Find ("LUZ1");
//			GameObject LUZ2 = GameObject.Find ("LUZ2");
//			GameObject CSPOT = GameObject.Find ("CAMERA_SPOT");

//			LUZ1.GetComponent<Light> ().intensity = 0.09f;
//			LUZ1.GetComponent<Light> ().cookieSize = 10;
//			LUZ2.GetComponent<Light> ().intensity = 0.09f;
//			LUZ2.GetComponent<Light> ().cookieSize = 10;

//			CSPOT.GetComponent<Light> ().enabled = true;

			GameObject.Find("LeftEyeAnchor").GetComponents<DepthOfField>()[0].enabled = true;
			GameObject.Find("LeftEyeAnchor").GetComponents<DepthOfField>()[1].enabled = true;
			GameObject.Find("RightEyeAnchor").GetComponents<DepthOfField>()[0].enabled = true;
			GameObject.Find("RightEyeAnchor").GetComponents<DepthOfField>()[1].enabled = true;
		} 
		else 
		{
			//GameObject LUZ1 = GameObject.Find ("LUZ1");
			//GameObject LUZ2 = GameObject.Find ("LUZ2");
//			GameObject CSPOT = GameObject.Find ("CAMERA_SPOT");
			
//			LUZ1.GetComponent<Light> ().intensity = 0.15f;
//			LUZ1.GetComponent<Light> ().cookieSize = 10;
//			LUZ2.GetComponent<Light> ().intensity = 0.15f;
//			LUZ2.GetComponent<Light> ().cookieSize = 10;
			
//			CSPOT.GetComponent<Light> ().enabled = false;

			GameObject.Find("LeftEyeAnchor").GetComponents<DepthOfField>()[0].enabled = false;
			GameObject.Find("LeftEyeAnchor").GetComponents<DepthOfField>()[1].enabled = false;
			GameObject.Find("RightEyeAnchor").GetComponents<DepthOfField>()[0].enabled = false;
			GameObject.Find("RightEyeAnchor").GetComponents<DepthOfField>()[1].enabled = false;
		}

	}

}
