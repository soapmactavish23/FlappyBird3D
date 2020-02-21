using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApagaObjeto : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("apagaObj", 1.5f);
	}
	
	// Update is called once per frame
	void apagaObj () {
		Destroy (gameObject);
	}
}
