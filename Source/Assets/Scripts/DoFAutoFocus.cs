﻿using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;



[RequireComponent(typeof(Camera))]
[RequireComponent(typeof(DepthOfField34))]
public class DoFAutoFocus : MonoBehaviour
{
	
	public GameObject doFFocusTarget;
	private Vector3 lastDoFPoint;
	private DepthOfField34 dofComponent;
	
	public DoFAFocusQuality focusQuality = DoFAutoFocus.DoFAFocusQuality.NORMAL;
	public LayerMask hitLayer = 1;
	public float maxDistance = 100.0f;
	public bool interpolateFocus = false;
	public float interpolationTime = 0.7f;

	public bool UsarHeuristicas = false;
	public bool _debug = false;
	public GameObject focoHeuristicaGM;

	public enum DoFAFocusQuality
	{
		NORMAL,
		HIGH
	}
	
	/// <summary>
	/// Init all needed objects
	/// </summary>
	void Start ()
	{
		doFFocusTarget = new GameObject ("DoFFocusTarget");
		dofComponent = gameObject.GetComponent<DepthOfField34> ();
		dofComponent.objectFocus = doFFocusTarget.transform;

	
	}

	public void ToggleValueChanged()
	{
		UsarHeuristicas = !UsarHeuristicas;
	}


	public void DebugActivate()
	{
		DebugConsole.Clear();
		_debug = !_debug;
	}
	/// <summary>
	/// 
	/// </summary>
	void Update ()
	{
		if (!UsarHeuristicas) 
		{
			if (focusQuality == DoFAutoFocus.DoFAFocusQuality.HIGH) 
			{
				Focus ();
			}
		} 
		else 
		{
			doFFocusTarget.transform.position =  new Vector3(focoHeuristicaGM.transform.position.x, focoHeuristicaGM.transform.position.y, focoHeuristicaGM.transform.position.z - 0.5f);

		}
		
	}
	
	void FixedUpdate ()
	{

		if (!UsarHeuristicas)
		{
						// switch between modes Test Focus like the Physicsupdate
						if (focusQuality == DoFAutoFocus.DoFAFocusQuality.NORMAL) {
								Focus ();
						}
		}
		else 
		{
			doFFocusTarget.transform.position =  new Vector3(focoHeuristicaGM.transform.position.x, focoHeuristicaGM.transform.position.y, focoHeuristicaGM.transform.position.z - 0.5f);
				
		}
	}
	
	
	/// <summary>
	/// Interpolate DoF Target
	/// </summary>
	/// <param name="targetPosition">
	/// A <see cref="Vector3"/>
	/// </param>
	/// <returns>
	/// A <see cref="IEnumerator"/>
	/// </returns>	
	IEnumerator InterpolateFocus (Vector3 targetPosition)
	{
		
		Vector3 start = this.doFFocusTarget.transform.position;
		Vector3 end = targetPosition;
		float dTime = 0;
		
		Debug.DrawLine (start, end,Color.green);
		
		while (dTime < 1) {
			yield return null;
			//new WaitForEndOfFrame();
			dTime += Time.deltaTime / this.interpolationTime;
			this.doFFocusTarget.transform.position = Vector3.Lerp (start, end, dTime);
		}
		this.doFFocusTarget.transform.position = end;
	}


	void HeuristicalFocusReceiver(string gm)
	{
		//print ("fui chamado");
		focoHeuristicaGM = GameObject.Find (gm);
		GameObject.Find("Text").GetComponent<Text>().text = "HEURISTICA FOCO: " + gm;
	}
	/// <summary>
	/// Raycasts the focus point
	/// </summary>
	void Focus ()
	{
		// our ray
		Ray ray = camera.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit, this.maxDistance, this.hitLayer)) {
			Debug.DrawLine (ray.origin, hit.point);
			
			// do we have a new point?					
			if (this.lastDoFPoint == hit.point) {
				return;
				// No, do nothing
			} else if (this.interpolateFocus) { // Do we interpolate from last point to the new Focus Point ?
				// stop the Coroutine
				StopCoroutine ("InterpolateFocus");
				// start new Coroutine
				StartCoroutine (InterpolateFocus (hit.point));
				
			} else {
				this.doFFocusTarget.transform.position = hit.point;
			}
			// asign the last hit
			this.lastDoFPoint = hit.point;

			if (_debug)
				DebugConsole.Log("F.point: " + hit.point.ToString());
		}
	}
	
}