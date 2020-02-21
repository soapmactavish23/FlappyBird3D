using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour {

	Rigidbody rb = new Rigidbody();

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, -5);
	}

	// Update is called once per frame
	void Update () {
		if(GetComponent<Rigidbody> ().velocity.x > 0){
			Destroy (gameObject);
		}
		if (transform.position.z < -10) {
			Destroy (gameObject);
		}

	}
}
