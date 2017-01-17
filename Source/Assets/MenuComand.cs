using UnityEngine;
using System.Collections;


public class MenuComand : MonoBehaviour {

	public int SceneIndex;

	public int v;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Application.loadedLevelName == "GAMEOVER")
		 {
			v =  PlayerPrefs.GetInt("PlayerScore");
			GameObject.FindGameObjectWithTag("SCOREUI").GetComponent<TextMesh>().text = v.ToString();
		}
		if (Application.loadedLevelName == "MENU")
		{
			PlayerPrefs.SetInt("PlayerScore",0);
			//v =  PlayerPrefs.GetInt("PlayerScore");
			//GameObject.FindGameObjectWithTag("SCOREUI").GetComponent<TextMesh>().text = v.ToString();
		}
		//string scene = SceneManager.GetActiveScene ().name;
		if (Input.anyKey) 
		{
			if (SceneIndex ==  0)
				Application.LoadLevel(1);
			//if (SceneIndex == 2)
				//Application.LoadLevel(0);
		}
	}
}
