using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogDeath : MonoBehaviour {
	public GameObject Frog_Alive;
	public GameObject Frog_Dead;

	public FrogControl frogControl;

	private bool alive;

	void Start (){
		alive = true;
	}


	void OnTriggerEnter(Collider other) {
		if (alive) { //if collided with a car
			if (other.gameObject.CompareTag ("Car")) {
				alive = false;
				frogControl.Kill (); //prohibiting movement
				Frog_Alive.SetActive (false); 
				Frog_Dead.SetActive (true); //spilling the blood
			}
		}
	}
}
