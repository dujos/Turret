using UnityEngine;
using System.Collections;

public class Creep : Unit 
{
	private NavMeshAgent agent;

	public float detectionDistance;
	private Transform creepTransform;					// creep position
	private Transform creepTarget;						// target for creep to pursuit

	public void Awake () 
	{
		base.Awake ();
		agent = GetComponent <NavMeshAgent> ();
	}

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		DetectUnit ();
	}

	public void DetectUnit () 
	{
		// check if we detect something
		Vector3 target = transform.TransformDirection (Vector3.forward);
		 Debug.DrawRay(transform.localPosition, target * 100, Color.green);
		RaycastHit hit;

		if (Physics.Raycast (transform.localPosition, target, out hit, detectionDistance)) 
		{
			// unit detected pursuit
			if (hit.transform != creepTarget) 
			{
				// follow this target
				creepTarget = hit.transform;
				// set point for us to return after pursuit end
				creepTransform = transform;
				Pursuit (creepTarget.transform.position);
			}
		} 
		else 
		{
			// no unit detected patrol
			Patrol ();
		}
	}

	// send creep back to position before pursuit
	public void Patrol () 
	{

	}

	public void Pursuit (Vector3 target) 
	{
		Transform startPosition = transform;
		agent.SetDestination (target);
	}
}