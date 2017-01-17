using UnityEngine;
using System.Collections;

public class AutoDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		StartCoroutine(destroy ());
	}

	IEnumerator destroy()
	{
		yield return new WaitForSeconds (1);
		Destroy (gameObject);
	}
	// Update is called once per frame
	void Update () {
	
	}
}
