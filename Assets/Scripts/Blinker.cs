using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Blinker : MonoBehaviour {
	private float Timer;
	private bool _enabled;
	private bool _activated;

	public SpriteRenderer[] blinkers;
	// Use this for initialization
	void Start () {
		Timer = Time.time ;
		enabled = true;
		_activated = false;

		foreach (SpriteRenderer blink in blinkers) {
			blink.enabled = false; 
		}
	}
	
	// Update is called once per frame
	void Update () {
		foreach (SpriteRenderer blink in blinkers) {
			blink.transform.LookAt (Camera.main.transform.position, -Vector3.up);
		} //sprites should look at the camera
		if (_activated) { //if the car has crashed
			if (Timer < Time.time) { //blinker timer
				Timer = Time.time + 0.6f; 
				if (!_enabled) { //switching blinkers
					foreach (SpriteRenderer blink in blinkers) {
						blink.enabled = true; 
					}
					_enabled = true;
				} else {
					foreach (SpriteRenderer blink in blinkers) {
						blink.enabled = false;
					}
					_enabled = false;
				}
			}
		} else {
			foreach (SpriteRenderer blink in blinkers) {
				blink.enabled = false;
			}
		}
	}

	public void ActivateBlinkers() {
		_activated = true;
		//Timer = Time.time;
	}

	public void DeactivateBlinkers() {
		_activated = false;
		foreach (SpriteRenderer blink in blinkers) {
			//blink.enabled = false; 
			blink.gameObject.SetActive (false);
		}
	}
}
