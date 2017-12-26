using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollisions : MonoBehaviour {

	public CarControl carControl;
	public Blinker blinker;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Car_Detector") || other.gameObject.CompareTag ("Gibs")) { //if collided with car
			carControl.StopCar();
			blinker.ActivateBlinkers ();
		}
	}

}
