using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawner : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Car")) {
			Destroy (other.transform.parent.gameObject); //удаляем машинку
		}
	}
}
