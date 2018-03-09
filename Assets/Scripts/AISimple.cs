using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISimple : MonoBehaviour {
	public float distance;
	public Transform target;
	public float lookDistance = 25.0f;
	public float attackRange = 15.0f;
	public float moveSpeed = 5.0f;
	public float damping = 6.0f;
	Renderer rend;
	
	void Start(){
		rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		distance = Vector3.Distance(target.position, transform.position);

		//looks at player if close enough
		if(distance < lookDistance){
			rend.material.SetColor("_Color", Color.yellow);
			LookAt();
			

		}

		//stops looking at player
		if(distance > lookDistance){
			rend.material.SetColor("_Color", Color.green);
		}

		//if close enough, charges
		if(distance < attackRange){
			rend.material.SetColor("_Color", Color.red);
			Attack();
		}
	}

	void LookAt(){
		//ought to stop it from pinging off into space
		transform.Translate(Vector3.zero);
		Quaternion rotation = Quaternion.LookRotation(target.position - transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
	}

	void Attack(){
		transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
	}
}
