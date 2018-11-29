using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovement : MonoBehaviour {

	public string unitType; // Identify which moveSet is open to the unit
	public bool canMove; // Determine if there are spots on the movement map where
	public Vector3 position;

	// Use this for initialization
	void Start () {
		unitType = this.tag.ToString();
		print(unitType);
		position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
