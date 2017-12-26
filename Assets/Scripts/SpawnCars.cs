using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCars : MonoBehaviour {

	public Transform[] spawnLocations;
	public GameObject[] spawnPrefab;
	public GameObject[] spawnClone;

	public SpawnObscur sob1;
	public SpawnObscur sob2;


	private float Timer;
	// Use this for initialization
	void Start () {
		Timer = Time.time + 0.3f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate () {
		//if (Input.GetKeyDown ("z")) {
		if (Timer < Time.time) {
			spawn ();
			Timer = Time.time + 0.3f;
		}
	}

	void spawn(){
		int loc = Random.Range (0, 6);
		if (loc <= 2) {
			if (sob1.clear ()) {
				spawnClone [0] = Instantiate (spawnPrefab [0], spawnLocations [loc].transform.position, Quaternion.Euler (0, 0, 0)) as GameObject;
			}
		} else {
			if (sob2.clear ()) {
				spawnClone [0] = Instantiate (spawnPrefab [0], spawnLocations [loc].transform.position, Quaternion.Euler (0, 180, 0)) as GameObject;
			}
		}
	}
}
