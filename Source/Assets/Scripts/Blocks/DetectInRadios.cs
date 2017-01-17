using UnityEngine;
using System.Collections;

public class DetectInRadios : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void ExplosionDamage(Vector3 center, float radius) 
	{
		Collider[] hitColliders = Physics.OverlapSphere(center, radius);
		int i = 0;
		while (i < hitColliders.Length)
		{
						print (hitColliders [i].gameObject.name);
						//hitColliders[i].SendMessage("AddDamage");
						i++;
		}
	}
}
