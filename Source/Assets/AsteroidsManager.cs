using UnityEngine;
using System.Collections;

public class AsteroidsManager : MonoBehaviour {
	
	public GameObject Asteroid;
	public int Quantity;
	public int Lim;

	public float MinMaxSpace; 
	public float MinMaxSpaceY; 
	// Use this for initialization
	void Start () 
	{
		//StartCoroutine(generateMeteor ());

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (GameObject.Find ("OBJECTS").transform.childCount < Lim) {
						generateMeteor ();
						
				}
	}

	void generateMeteor()
	{
		//DebugConsole.print("a");
		for (int i=0; i<Quantity; i++) 
		{
			GameObject asteroid = ((GameObject)Instantiate(Asteroid, new Vector3 (Random.Range(-MinMaxSpace,MinMaxSpace),0f,Random.Range(-MinMaxSpace,MinMaxSpace)),Quaternion.identity));
			asteroid.transform.parent = GameObject.Find ("OBJECTS").transform;
			//asteroid.transform.position = new Vector3 (0, 0, 0);
			asteroid.name = asteroid.name + asteroid.GetInstanceID().ToString ();
			if (asteroid.transform.position.x < MinMaxSpaceY && asteroid.transform.position.x > 0f)
			{
				asteroid.transform.position = new Vector3(Random.Range(MinMaxSpaceY,MinMaxSpace),0f,asteroid.transform.position.z);
			}
			else if (asteroid.transform.position.x > -MinMaxSpaceY && asteroid.transform.position.x < 0f)
			{
				asteroid.transform.position = new Vector3(Random.Range(-MinMaxSpace,-MinMaxSpaceY),0f,asteroid.transform.position.z);
			}
			
			if (asteroid.transform.position.z <MinMaxSpaceY && asteroid.transform.position.z > 0f)
			{
				asteroid.transform.position = new Vector3(asteroid.transform.position.x, 0f, Random.Range(MinMaxSpaceY,MinMaxSpace));
			}
			else if (asteroid.transform.position.z >-MinMaxSpaceY && asteroid.transform.position.z < 0f)
			{
				asteroid.transform.position = new Vector3(asteroid.transform.position.x, 0f, Random.Range(-MinMaxSpace,-MinMaxSpaceY));
			}
		}
		//yield return new WaitForSeconds(0);

	}


}
