using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDetectorFront : MonoBehaviour {

	public CarControl carControl;

	private bool alive;
	// Use this for initialization
	void Start () {
		alive = true;
	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay(Collider other) {
		if (alive) {
			if (other.gameObject.CompareTag ("Car")) {
				carControl.SlowDown ();
			}
			alive = carControl.IsMoving ();
		}
	}

	void OnTriggerExit (Collider other) {
		if (alive) {
			if (other.gameObject.CompareTag ("Car")) {
				carControl.SpeedUp ();
			}
			alive = carControl.IsMoving ();
		}
	}
}
