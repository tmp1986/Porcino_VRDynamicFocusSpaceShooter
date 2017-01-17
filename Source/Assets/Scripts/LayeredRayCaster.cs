using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Text;
using UnityEngine.UI;



[Serializable]
public class Layer
{
    public int Weight; // the weigth of the layer, can set from inspector too.
    public bool Visible; // setting to false won't show the rays on this layer nor cast them.
    [HideInInspector]
    public int Number; // set from code, you can't (shouldn't modify)
    [HideInInspector]
    public Color color; // automatically generated
    [HideInInspector]
    public List<Vector3> Points;

}
public class LayeredRayCaster : MonoBehaviour
{
    /// <summary>
    /// emitter of rays set from inspector
    /// </summary>
	[Header("Rays Origins Point")]
    public GameObject raysSource;
	[Space(15)]
    //public bool printInfo = false;

	[Header("Number of Layers")]
	public int layerCount = 10;
	[Space(15)]
	
	[Header("Number of Rays Per Layer")]
	public int raysCountPerLayer;
	[Space(15)]


	[Header("Cone Radius Size")]
    public float coneRadius;
	[Space(15)]

	[Space(15)]
	[Header("Rays Maximum Distance")]
    public float maxDistance = 10;


	[Header("Max Distance Hited by Rays")]
	public float maxDistanceHitedObject = 0.0f;
	[Space(15)]
    /// <summary>
    /// default layer =1
    ///  you can add / remove layers using AddLayer / RemoveLayer methods
    /// </summary>
    int layerMask = 1;

    List<Vector3> rayHitPositions = new List<Vector3>();

    // to prevent re-calculation when not needed.
    int prevrayCountPerLayer, prefLayerCount;
    float prevRadius, prevDistance;

	public GameObject OverlapSphereSource; 
	public List<GameObject> ovsList = new List<GameObject> ();

	public List<string> resultHitLayer = new List<string> (); 


	public List<string> listOfResults = new List<string>();

    ColourGenerator colorGenerator;
    public Layer[] layers;

    public Dictionary<GameObject, Dictionary<int,int>> objectAndHitLayer;
    void Start()
    {
        colorGenerator = new ColourGenerator();
		ReDrawRays(); 


		OverlapSphereSource = GameObject.Find("First Person Controller - DOF");;

       	

    }

    /// <summary>
    /// to prevent the over heat of printing same info every frame.
    /// we try to print only when some action happens such as rotate of the source
    /// or change of the parameters.
    /// </summary>


    // Update is called once per frame
    void Update()
    {
		//Get the list of objects inside the overlapSphere from overlapSphere script
		OverlapSphere osscript = OverlapSphereSource.GetComponent<OverlapSphere>();
		ovsList = osscript.objectsFound;

        if (raysCountPerLayer <= 0)
            return;

        rayHitPositions.Clear();

        if (raysCountPerLayer != prevrayCountPerLayer || prevRadius != coneRadius || prevDistance != maxDistance
            || prefLayerCount != layerCount)
        {
            if (raysCountPerLayer <= 0 || coneRadius < 0 || maxDistance < 0 || layerCount <= 0)
                return;
            ReDrawRays();

        }

        DrawRayHit();



    }

    private void ReDrawRays()
    {
        prevrayCountPerLayer = raysCountPerLayer;
        prevRadius = coneRadius;
        prevDistance = maxDistance;
        prefLayerCount = layerCount;

        colorGenerator.Reset();
        CreateNewLayers(); //generate layers 
        Distribute(); //distribute geometric cone points

    }
	//Create layers from layer class
    private void CreateNewLayers()
    {
        layers = new Layer[layerCount];
        for (int i = 0; i < layers.Length; i++)
        {
            layers[i] = new Layer();
            layers[i].Number = layers.Length - i;
            layers[i].Weight = layers.Length - i;
            layers[i].color = colorGenerator.NextColour();
            layers[i].Visible = true;
            layers[i].Points = new List<Vector3>();
        }
    }





    /// <summary>
    /// Draws a ray cast, displaying hit information
    /// </summary>
    void DrawRayHit()
    {
		//A Dictionary to save the gameobject was hited in lawer and your weight
        objectAndHitLayer = new Dictionary<GameObject, Dictionary<int,int>>();
		resultHitLayer.Clear ();


		//looping all layers
        for(int i =0; i< layers.Length;i++)
        {
			//if lawer isn't visible we don't calculate hit for this layer
            if (!layers[i].Visible)
                continue;

			//looping all Points inside Layer
            for(int j =0; j < layers[i].Points.Count;j++)
            {
				//hitInfo
                RaycastHit hitInfo;

				//create a ray from source to layer[alllayers].Point[allpoints]
                if (Physics.Raycast(raysSource.transform.position, layers[i].Points[j] + raysSource.transform.forward * maxDistance, out hitInfo, maxDistance, layerMask))
                {


                    //We have a hit! red line
					//distancia entre o object alvo e a camera
					float _maxdistance = Mathf.Sqrt (Mathf.Pow(raysSource.transform.position.x - hitInfo.point.x, 2) + Mathf.Pow(raysSource.transform.position.y - hitInfo.point.y, 2) + Mathf.Pow(raysSource.transform.position.z - hitInfo.point.z, 2));
					
					if (_maxdistance > maxDistanceHitedObject)
						maxDistanceHitedObject = _maxdistance;
					//listAllHit.Add(objectAndHitLayer);
					//Draw a line with the same point where we have a hit, using red color	
                    Debug.DrawLine(raysSource.transform.position, hitInfo.point, Color.red, .01f, true);

					//Add to a list the ray hit position
                    rayHitPositions.Add(hitInfo.point);

		
					//if this hit collider 1 or more gameobject
                    if (hitInfo.collider.gameObject != null)
                    {
						//if gameobject exists in dictionary
                        if (objectAndHitLayer.ContainsKey(hitInfo.collider.gameObject))
                        {
							//if the gameobject's layer exist
                            if (objectAndHitLayer[hitInfo.collider.gameObject].ContainsKey(layers[i].Number))
							{

								//increment the number of rays inside this layer
                                objectAndHitLayer[hitInfo.collider.gameObject][layers[i].Number]++;
								//DisplayHitInfo();
							}
                            else
							{
								//still the same number of rays before
                                objectAndHitLayer[hitInfo.collider.gameObject].Add(layers[i].Number, 1);
								//DisplayHitInfo();
							}

                        }
						//if gameobject not exists in dictionary
                        else
                        {

							//create a dictionaryof ints
                            Dictionary<int, int> dic = new Dictionary<int, int>();
							//add the new layer id with weight
                            dic.Add(layers[i].Number, 1);
							//add the new gameobject to collection
                            objectAndHitLayer.Add(hitInfo.collider.gameObject, dic);

                        }
                    }

                }
                else
                {
					//We don't have a hit another color line
                    Debug.DrawLine(raysSource.transform.position, layers[i].Points[j] + raysSource.transform.forward * maxDistance, layers[i].color, .01f, true);
                }

            }
			DisplayHitInfo();
        }
        
    }

    private void DisplayHitInfo()
    {
		//resultHitLayer.Clear ();
        foreach (var item in objectAndHitLayer)
        {
			GameObject go = (GameObject)item.Key;
			if (ovsList.Contains(go))
			{
				 string text2 = "";
				foreach (var subItem in item.Value)
				{
					text2 = item.Key.name + ","+ subItem.Value + "," + subItem.Key + "," + layers[layers.Length - subItem.Key].Weight;
				}
				resultHitLayer.Add(text2.ToString());

			}
			CalculateStringValues(resultHitLayer);
        }


    }

	private void CalculateStringValues(List<string> list)
	{
		listOfResults.Clear ();
		//list.Sort();

		Dictionary<string, int> r = list.Select(x => x.Split(','))
			.GroupBy(x => x[0])
				.ToDictionary(x => x.Key, x => x.Sum(y => int.Parse(y[1])*int.Parse(y[3])));

		foreach (KeyValuePair<string, int> kvp in r)
		{
			//print(kvp.Key + " " + kvp.Value.ToString());
			listOfResults.Add(kvp.Key + "," + kvp.Value.ToString());
		}
	}


    /// <summary>
    /// Raises the draw gizmos event.
    /// </summary>
    void OnDrawGizmos()
    {
        //Draw the hit locations
        foreach (Vector3 rayHitPosition in rayHitPositions)
        {
            Gizmos.DrawWireSphere(rayHitPosition, 0.1f);
        }
   
    }

    public void AddLayer(int layer)
    {
        layerMask = layerMask | (1 << layer);
    }

    public void RemoveLayer(int layer)
    {
        layerMask = layerMask & ~(1 << layer);
    }





	//reference : http://www.softimageblog.com/archives/115
    public void Distribute()
    {
		//totalRays is the number of rays per layer * number of layers
        int totalRays = raysCountPerLayer * layerCount;

		//avoid 0 rays calculation
        if (totalRays <= 0)
            return;

		//start with negative lawer index
        int currentLayer = -1;

		//makes a loop from 0 to total of rays
        for (int i = 0; i < totalRays; i++)
        {
            if (i % raysCountPerLayer == 0) //check if i is divisible by raysCountPerLayer
			{						//Clamp(float value, float min, float max);
                currentLayer = Mathf.Clamp(currentLayer + 1, 0, layers.Length-1);
            }
			//current theta 
            float theta = i * PHI;

			//current radius
            float r = Mathf.Sqrt(i) / Mathf.Sqrt(totalRays);

			//triangle point
            Vector3 point = new Vector3(r * Mathf.Cos(theta), r * Mathf.Sin(theta), 0) * coneRadius;
            layers[currentLayer].Points.Add(point);
        }

    }

    /// <summary>
    /// Golden angle phiAngle.
    /// </summary>
    readonly float PHI = Mathf.PI * (3 - Mathf.Sqrt(5));




}
