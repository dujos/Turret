using UnityEngine;
using System.Collections;

[RequireComponent (typeof (BoxCollider))]
public class Unit : MonoBehaviour 
{
	private BoxCollider collider;

	public void Awake () 
	{
		// lift unit up
		collider = GetComponent <BoxCollider> ();
		float offset = this.collider.bounds.extents.y;
		
		transform.position = new Vector3 (transform.position.x, 
		                                  transform.position.y + offset, 
		                                  transform.position.z); 
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnEnable () 
	{
		GameController.OnSelected += UnitSelected;
		GameController.OnDeselected += UnitDeselected;
	}

	public void OnDisable () 
	{
		GameController.OnSelected -= UnitSelected;
		GameController.OnDeselected -= UnitDeselected;
	}

	// Unit selected movement on
	public void UnitSelected (Unit unit) 
	{
		if (!unit.GetComponent<SimpleUnitMove> ().CanMoveUnit) 
		{
			unit.GetComponent<SimpleUnitMove> ().CanMoveUnit = true;
		}
	}

	// Unit deselected movement off
	public void UnitDeselected (Unit unit) 
	{
		Debug.Log ("x");
		if (unit.GetComponent<SimpleUnitMove> ().CanMoveUnit) 
		{
			unit.GetComponent<SimpleUnitMove> ().CanMoveUnit = false;
		}
	}
}