using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour {

	//the collider that enters the zone
	private string collider;

	void OnTriggerEnter (Collider other){
		collider = other.tag;

		//if player enters, play 
		if(collider == "Player"){
			GetComponent<AudioSource>().Play();
			GetComponent<AudioSource>().loop = true;
		}
	}

	void OnTriggerExit(Collider other){
		collider = other.tag;

		if(collider == "Player"){
			GetComponent<AudioSource>().Stop();
			GetComponent<AudioSource>().loop = false;
		}
	}
}
