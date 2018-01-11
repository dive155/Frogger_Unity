using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class FrogControl : MonoBehaviour {
	private float speed;
	private Vector3 rotDest;

	private bool alive;

    [SerializeField] private Transform body;

	void Start () {
		speed = 7;
		alive = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (alive) {
			/*if (Input.GetKey ("d")) {
				transform.Translate (-speed * Time.deltaTime, 0, 0);
			} else if (Input.GetKey ("a")) {
				transform.Translate (speed * Time.deltaTime, 0, 0);
			} else if (Input.GetKey ("s")) {
				transform.Translate (0, 0, speed * Time.deltaTime);
			} else if (Input.GetKey ("w")) {
				transform.Translate (0, 0, -speed * Time.deltaTime);
			}
            */
            transform.Translate (-speed * Time.deltaTime * CrossPlatformInputManager.GetAxis("Horizontal"), 0, 0);
            transform.Translate (0, 0, -speed * Time.deltaTime * CrossPlatformInputManager.GetAxis("Vertical"));

            rotDest = new Vector3 (CrossPlatformInputManager.GetAxis("Horizontal"), 0, CrossPlatformInputManager.GetAxis("Vertical"));
            body.transform.rotation = Quaternion.Lerp(body.transform.rotation, Quaternion.LookRotation(rotDest), 0.3f);
		}
	}



	public void Kill () {
		alive = false;
	}

}