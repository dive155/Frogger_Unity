using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControl : MonoBehaviour {
	public Rigidbody rb;
	public HingeJoint Wheel1;
	public HingeJoint Wheel2;
	public HingeJoint Wheel3;
	public HingeJoint Wheel4;

	public GameObject[] bodys;
	public GameObject burnedBody;
	public float expForce;
	public Blinker blinker;

	public int minSpeed;
	public int maxSpeed;
	public int frontPower;
	public int rearPower;
	public ParticleSystem WhiteSmoke;
	public ParticleSystem BlackSmoke;
	public ParticleSystem ExplosionSmoke;

	private int tarVel;
	private bool moving;
	private bool exploded;
	private bool dangerAhead;

	private int health;
	private Vector3 comas;

    [SerializeField] private Detector leftDetector;
    [SerializeField] private Detector rightDetector;
    [SerializeField] private Detector frontDetector;
    [SerializeField] private Detector frontDetector2;

	// Use this for initialization
	void Start () {

        EnableBodies();
        SetUpWheels();
        EnableDetectors();
	}

    private void EnableBodies()
    {
        foreach (GameObject body in bodys) {
            body.SetActive (false);
        }
        int selector;
        selector = Random.Range (0, bodys.Length); //randomizing car model
        bodys[selector].SetActive (true);
    }

    private void SetUpWheels()
    {

        //rb = GetComponent<Rigidbody> ();
        //comas = new Vector3 (-1, -1, 0);
        comas = new Vector3 (0, -0.3f, 0);
        rb.centerOfMass = comas; //moving the center of mass to avoid wheelies
        moving = true;
        exploded = false;
        dangerAhead = false;
        health = 5000;

        tarVel = Random.Range (minSpeed, maxSpeed); //choosing random speed
        Vector3 locVel = transform.InverseTransformVector(rb.velocity); //getting the orientation of the car
        locVel.x = -tarVel; //preparing a little push
        rb.velocity = transform.TransformDirection (locVel); //pushing the car forward

        //print(tarVel);
        //tarVel *= 850; //target rotational velocity
        tarVel *= 850;
        //print(tarVel);
        var motor = Wheel1.motor; //setting the spin
        motor.targetVelocity = tarVel;
        motor.force = frontPower;
        Wheel3.motor = motor;
        Wheel4.motor = motor;
        motor.force = rearPower;
        Wheel1.motor = motor;
        Wheel2.motor = motor;
    }

    private void EnableDetectors()
    {
        frontDetector.ObstacleDetected += SlowDown;
        frontDetector.ObstacleGone += SpeedUp;
        frontDetector2.ObstacleDetected += SlowDown;
        frontDetector2.ObstacleGone += SpeedUp;
        rightDetector.ObstacleDetected += TurnLeft;
        leftDetector.ObstacleDetected += TurnRight;
    }

	public void StopCar() {
		moving = false;
		var motor = Wheel1.motor; //stopping
		motor.targetVelocity = 0;
		motor.force = 1;
		Wheel3.motor = motor;
		Wheel4.motor = motor;
		Wheel1.motor = motor;
		Wheel2.motor = motor;

        frontDetector.Enabled = false;
        frontDetector2.Enabled = false;
        rightDetector.Enabled = false;
        leftDetector.Enabled = false;
	}
        


	void OnCollisionEnter(Collision col) {
		if (col.collider.gameObject.CompareTag ("Car")) {
			//print ("We hit a car");
			//print (col.impulse.magnitude);
			if (col.impulse.magnitude > 100) { //if collided, reducing health
				health = health - (int) col.impulse.magnitude;
			}
			if (health < 4000) {
				WhiteSmoke.Play ();
			}
			if (health < 1500) {
				WhiteSmoke.Stop ();
				BlackSmoke.Play ();
			}
			if (health <= 0) {
				ExplodeCar ();
			}
		}
	}

	void ExplodeCar(){
		if (!exploded) { //exploding the car
			ExplosionSmoke.Play (); //showing the explosion
			exploded = true;
			foreach (GameObject body in bodys) {
				body.SetActive (false);
			}
			burnedBody.SetActive (true); //using burned body
			blinker.DeactivateBlinkers(); //turning off blinkers
			//throwing the car somewhere:
			rb.velocity = rb.velocity + (new Vector3 (Random.Range (-1.0f, 1.0f)* expForce, Random.Range (0.0f, 1.0f)* expForce, Random.Range (-1.0f, 1.0f)* expForce)); 
		}
	}


	// Update is called once per frame
	void Update () {
		//print (rb.velocity); 
		if (Input.GetKey ("r")) {
			Application.LoadLevel (Application.loadedLevel);
		}
	}

	public void TurnRight () {
			rb.AddTorque (new Vector3 (0, 700, 0));
	}

	public void TurnLeft () {
			rb.AddTorque (new Vector3 (0, -700, 0));
	}

	public bool IsMoving() {
		return moving;
	}

	public void SlowDown() {
		dangerAhead = true;
	}

	public void SpeedUp() {
		dangerAhead = false;
	}

	void FixedUpdate () {
		/*
		if (Input.GetKey ("d")) { //turn right
			rb.AddTorque (new Vector3 (0, 1000, 0));
		} 
		if (Input.GetKey ("a")) { //turn left
			rb.AddTorque (new Vector3 (0, -1000, 0));
		}*/
		if (moving && !dangerAhead) { //damned cars don't go fast enough
			if (rb.velocity.magnitude < tarVel / 850) { //gotta go fast
				rb.AddForce (0, -700, 0);
				rb.AddRelativeForce (-7000, 0, 0);
				rb.AddRelativeTorque (new Vector3 (0, 0, 100)); //also they want to do wheelies
			}
			//rb.AddRelativeTorque (new Vector3 (0, 0, 1));
		}

		/*if (Input.GetKey ("f")) {
			var motor = Wheel1.motor;
			motor.targetVelocity = tarVel;
			Wheel1.motor = motor;
			Wheel2.motor = motor;
			Wheel3.motor = motor;
			Wheel4.motor = motor;
		} 
		else {
			var motor = Wheel1.motor;
			motor.targetVelocity = 0;
			motor.freeSpin = true;
			Wheel1.motor = motor;
			Wheel2.motor = motor;
			Wheel3.motor = motor;
			Wheel4.motor = motor;
		}*/
	}
}
