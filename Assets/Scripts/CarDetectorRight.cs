using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDetectorRight : MonoBehaviour {

	public CarControl carControl;

	private bool alive;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		alive = true;
	}

	void OnTriggerStay(Collider other) {
		if (alive) {
			if (other.gameObject.CompareTag ("Lane_Separator") || other.gameObject.CompareTag ("Car")) {
				carControl.TurnLeft ();
			}
			alive = carControl.IsMoving ();
		}
	}
}
