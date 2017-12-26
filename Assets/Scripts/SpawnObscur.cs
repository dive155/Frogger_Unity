using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObscur : MonoBehaviour {

	private bool _clear;

	// Use this for initialization
	void Start () {
		_clear = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay(Collider other) {
		if (other.gameObject.CompareTag ("Car")) {
			_clear = false;
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.CompareTag ("Car")) {
			_clear = true;
		}
	}

	public bool clear() {
		return _clear;
	}

}
