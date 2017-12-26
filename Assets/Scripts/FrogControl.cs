using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogControl : MonoBehaviour {
	private float speed;
	private Vector3 rotDest;

	private bool alive;

	void Start () {
		speed = 7;
		alive = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (alive) {
			if (Input.GetKey ("d")) {
				transform.Translate (-speed * Time.deltaTime, 0, 0);
			} else if (Input.GetKey ("a")) {
				transform.Translate (speed * Time.deltaTime, 0, 0);
			} else if (Input.GetKey ("s")) {
				transform.Translate (0, 0, speed * Time.deltaTime);
			} else if (Input.GetKey ("w")) {
				transform.Translate (0, 0, -speed * Time.deltaTime);
			}
		}
	}



	public void Kill () {
		alive = false;
	}

}