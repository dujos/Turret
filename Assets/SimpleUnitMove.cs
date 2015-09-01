using UnityEngine;
using System.Collections;

public class SimpleUnitMove : MonoBehaviour {

	private float x;
	private float y;

	private bool canMoveUnit = false;
	public bool CanMoveUnit { get; set; }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (CanMoveUnit) 
		{
			x = Input.GetAxisRaw ("Horizontal");
			y = Input.GetAxisRaw ("Vertical");
			transform.Translate (new Vector3 (x, 0, y) * 10 * Time.deltaTime);
		}
	}
}
