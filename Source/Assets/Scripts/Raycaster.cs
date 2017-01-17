using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System;
using System.Linq;
public class Raycaster : MonoBehaviour {

    /// <summary>
    /// emitter of rays set from inspector
    /// </summary>
    public GameObject raysSource;
    public int raysCount;
    public int density;
    public float coneRadius;

	public float maxDistance = 10;

    /// <summary>
    /// default layer =1
   ///  you can add / remove layers using AddLayer / RemoveLayer methods
    /// </summary>
    public int layerMask = 1; 
	
     List<Vector3> rayHitPositions = new List<Vector3>();
     List<Vector3> sphereHitPositions = new List<Vector3>();

    public Dictionary<GameObject, int> objectsAndHitRays;
	public string maxHitsName;


    // to prevent re-calculation when not needed.
    int prevCount;
    float prevRadius, prevDistance;

    // to reduce print times.
    string maxObjName;
    int prevMaxHits;

    public Vector3[] points;
    void Start()
    {
        prevCount = raysCount;
        prevRadius = coneRadius;
        DistributePointsInCircle();
    }

	public string mostHited()
	{
		GameObject.Find("First Person Controller - DOF").SendMessage("MostHited", maxHitsName);
		return maxHitsName;
	}

    // Update is called once per frame
    void Update () {
        if (raysCount <= 0)
            return;
		//Allow us to rotate the caster at 20 degrees per second
		if(Input.GetKey(KeyCode.A)) {
			raysSource.transform.Rotate(Vector3.up, 20f * Time.deltaTime);
		}

		if(Input.GetKey(KeyCode.D)) {
			raysSource.transform.Rotate(Vector3.up, -20f * Time.deltaTime);
		}

		rayHitPositions.Clear();
		sphereHitPositions.Clear();

        if(raysCount != prevCount || prevRadius != coneRadius || prevDistance != maxDistance)
        {
            prevCount = raysCount;
            prevRadius = coneRadius;
            prevDistance = maxDistance;
            DistributePointsInCircle();
        }
        
		DrawRayHit();



	}



    /// <summary>
    /// Draws a ray cast, displaying hit information
    /// </summary>
    void DrawRayHit()
    {
        objectsAndHitRays = new Dictionary<GameObject, int>();

        for (int i = 0; i < points.Length; i++)
        {

            RaycastHit hitInfo;
            if (Physics.Raycast(raysSource.transform.position, points[i] + raysSource.transform.forward * maxDistance, out hitInfo, maxDistance, layerMask))
            {
                //We have a hit!
                Debug.DrawLine(raysSource.transform.position, hitInfo.point, Color.red, .01f, true);
                rayHitPositions.Add(hitInfo.point);
                if (hitInfo.collider.gameObject != null)
                {
                    if (objectsAndHitRays.ContainsKey(hitInfo.collider.gameObject))
                    {
                        objectsAndHitRays[hitInfo.collider.gameObject]++;
                    }
                    else
                        objectsAndHitRays.Add(hitInfo.collider.gameObject, 1);
                }

            }
            else
            {
                Debug.DrawLine(raysSource.transform.position, points[i] + raysSource.transform.forward * maxDistance, Color.green, .01f, true);
            }
        }

        PrintMaxHitCountInfo();
    }

    private void PrintMaxHitCountInfo()
    {
        if (objectsAndHitRays.Keys.Count > 0)
        {

            int maxHits = objectsAndHitRays.Values.Max<int>();
            foreach (var item in objectsAndHitRays.Keys)
            {

                if (objectsAndHitRays[item] == maxHits)
                {
                    if (item.name == maxObjName && maxHits == prevMaxHits)
                    {
                        // nothing new don't print, return
                        return;
                    }
                    prevMaxHits = maxHits;
                    maxObjName = item.name;
                    print(item.name + " was hit " + maxHits + " times.");
					maxHitsName = item.name.ToString();
					mostHited();
                }
            }
        }
    }



	/// <summary>
	/// Raises the draw gizmos event.
	/// </summary>
	void OnDrawGizmos() {
		//Draw the hit locations
		foreach(Vector3 rayHitPosition in rayHitPositions) {
			Gizmos.DrawWireSphere(rayHitPosition, 0.1f);
		}
		foreach(Vector3 sphereHitPosition in sphereHitPositions) {
			Gizmos.DrawWireSphere(sphereHitPosition, .5f);
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

    public void DistributePointsInCircle()
    {

        int boundaryPoints = (int)Mathf.Sqrt(density * raysCount);
        float phi = (Mathf.Sqrt(5) + 1.0f) / 2.0f;
        points = new Vector3[raysCount];
        for(int i =0; i < raysCount;i++)
        {
            float r = GetRadius(i, boundaryPoints);
            float theta = 2 * Mathf.PI * i / (phi * phi);
            points[i] = new Vector3(r * Mathf.Cos(theta), r * Mathf.Sin(theta), 0) * coneRadius;
        }
    }

    private float GetRadius(int i, int boundaryPoints)
    {
        if (i > raysCount - boundaryPoints)
            return 1;
        else
            return Mathf.Sqrt(i - 1f / 2f) / Mathf.Sqrt(raysCount - (boundaryPoints + 1f) / 2f);
    }
}
