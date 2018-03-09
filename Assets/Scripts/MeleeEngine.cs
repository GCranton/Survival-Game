using UnityEngine;
using System.Collections;

public class MeleeEngine : MonoBehaviour {
	public int Damage = 50;
	public float Distance;
	public float MaxDistance = 2.5f;
	public Transform System;

	void Start(){

	}

	void Update() {

		//Attacking
		if(Input.GetButtonDown("Fire1"))
		{
			GetComponent<Animation>().Play("Attack");
		}

		//Sprint Animation
		// if(Input.GetButton("Sprint")){
		// 	GetComponent<Animation>().CrossFade("Sprint");
		// }

		// if(Input.GetButtonUp("Sprint")){
		// 	GetComponent<Animation>().CrossFade("Idle");
		// }

		// //Idle Animation
		// if(GetComponent<Animation>().isPlaying == false){
		// 	GetComponent<Animation>().CrossFade("Idle");
		// }
	}

	void AttackDamage() {
		RaycastHit hit;
			if(Physics.Raycast(System.transform.position, System.transform.TransformDirection(Vector3.forward), out hit)){
				Distance = hit.distance;
				if(Distance <= MaxDistance) {
					hit.transform.SendMessage("ApplyDamage", Damage, SendMessageOptions.DontRequireReceiver);
				}
			}
	}
}