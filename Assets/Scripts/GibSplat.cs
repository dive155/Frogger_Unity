using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GibSplat : MonoBehaviour {

	public GameObject[] bloodPrefab;

	public float bloodDistance;
	public float scaleMin;
	public float scaleMax;

	private Vector3 lastBloodPos;
	private bool firstBlood;
	private int index;
	private int splats;
	private GameObject blood;

	void Start () {
		firstBlood = true;
		lastBloodPos = new Vector3 (0, 0, 0);
		splats = 0;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionStay(Collision collision) {

		if (collision.gameObject.CompareTag ("Ground")) { //if collided with ground
			ContactPoint contact = collision.contacts[collision.contacts.GetLength (0)-1];
			Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
			Vector3 pos = contact.point; //getting collision point
			pos.Set (pos.x, pos.y + 0.05f, pos.z); //lifting it above ground

			if (firstBlood) { //remembering first bloody position
				lastBloodPos = pos;
				firstBlood = false;
			}
			
			if (Vector3.Distance(pos, lastBloodPos) >= bloodDistance){ //distance between blood stains
				index = Random.Range(0,3);//random blood
				//scaling for divercity:
				bloodPrefab[index].gameObject.transform.localScale = new Vector3(1,1,1) * Random.Range(scaleMin, scaleMax);
				blood = bloodPrefab [index]; //getting our blood
				Instantiate<GameObject>(blood, pos, rot); //spawning blood
				lastBloodPos = pos; //remembering last bloody position
				/*splats = splats + 1;
				if (splats > 20) { //if too much blood, stop splatting
					gameObject.SetActive (false);
				}*/
			}
		}
	}

}
