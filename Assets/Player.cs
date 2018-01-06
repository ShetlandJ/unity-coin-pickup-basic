using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float speed = 8;
	int coinCount;
	Rigidbody myRigidbody;
	Vector3 velocity;

	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody> ();
		print("There are 5 coins in this world! Can you find them all?");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 input = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical"));
		Vector3 direction = input.normalized;
		 velocity = direction * speed;

	}

	void FixedUpdate() {
		myRigidbody.position += velocity * Time.deltaTime;
	}

	void OnTriggerEnter(Collider triggerCollidor) {
		if (triggerCollidor.tag == "Coin") {
			Destroy (triggerCollidor.gameObject);
			coinCount++;
			if (coinCount > 1) {
				print ("You've collected " + coinCount + " coins!");
			} else {
				print ("You've collected " + coinCount + " coin!");
			}

			if (coinCount == 5) {
				print ("Congrats, you found all the coins!");
			}
		}
	}
}
