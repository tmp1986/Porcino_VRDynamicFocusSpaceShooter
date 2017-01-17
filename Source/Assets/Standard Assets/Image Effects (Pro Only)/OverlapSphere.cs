using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class OverlapSphere : MonoBehaviour
{
    // the object to be the center point of the sphere
    public Vector3 centerPoint;

    public float radius;
    public List<GameObject> objectsFound;



    // Physics related stuff should happen in this method.
    void FixedUpdate()
    {
        FindInRadious();
    }

	void posSphere(Vector3 point)
	{
		centerPoint = new Vector3(point.x,point.y,point.z);
	}


    /// <summary>
    /// Make sure the objects you want to be detected have
    /// any kind of collider component attached to them.
    /// such as: sphere collider, box collider, mesh collider, or capsule collider
    /// </summary>
    public void FindInRadious()
    {
        objectsFound = new List<GameObject>();
        
         
        Collider[] colls = Physics.OverlapSphere(centerPoint, radius);
        foreach (Collider col in colls)
        {
			if (col.transform.IsChildOf(GameObject.Find("OBJECTS").transform))
            	objectsFound.Add(col.gameObject);
        }
    }


    /// <summary>
    /// Draws the sphere gizmo
    /// for test purposes only
    /// </summary>
    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;       
        Gizmos.DrawWireSphere(centerPoint, radius);
    }
}
