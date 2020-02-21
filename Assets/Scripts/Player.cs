using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public Camera camera;

	public AudioClip somBate;
	public AudioClip somPonto;
	public AudioClip voa;

	void OnTriggerEnter(Collider obj){
		if (obj.CompareTag ("Finish")) {
			camera.SendMessage ("GameOver");
		}
	}

	void OnTriggerExit(Collider obj){
		if (obj.CompareTag ("GameController")) {
			camera.SendMessage ("maisPontos");
			GetComponent<AudioSource> ().PlayOneShot (somPonto);
		}
	}

	void SomBate(){
		GetComponent<AudioSource> ().PlayOneShot (somBate);
	}

	void SomVoa(){
		GetComponent<AudioSource> ().PlayOneShot (voa);	
	}
}
