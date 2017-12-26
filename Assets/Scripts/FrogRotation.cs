using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogRotation : MonoBehaviour {

	private Vector3 rotDest;
	public int rotSpeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey("d")){
			rotDest = new Vector3 (0, 90, 0);
			transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.Euler (rotDest), Time.deltaTime * rotSpeed);

		}
		else if(Input.GetKey("a")){
			rotDest = new Vector3 (0, -90, 0);
			transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.Euler (rotDest), Time.deltaTime * rotSpeed);
		}
		else if(Input.GetKey("s")){
			rotDest = new Vector3 (0, 180, 0);
			transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.Euler (rotDest), Time.deltaTime * rotSpeed);
		}
		else if(Input.GetKey("w")){
			rotDest = new Vector3 (0, 0, 0);
			transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.Euler (rotDest), Time.deltaTime * rotSpeed);
		}
	}
}
