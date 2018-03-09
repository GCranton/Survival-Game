using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedAI : MonoBehaviour {
	public float distance;
	public Transform target;
	public float lookDistance = 25.0f;
	public float attackRange = 1.5f;
	public float chaseRange = 10.0f;
	public float moveSpeed = 5.0f;
	public float damping = 6.0f;
	public float attackRepeatTime = 1.0f;

	public int damage = 40;
	
	private float attackTime;

	public CharacterController controller;
	public float gravity = 20.0f;
	private Vector3 moveDirection = Vector3.zero;


	Renderer rend;
	
	void Start(){
		attackTime = Time.time;
		rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		distance = Vector3.Distance(target.position, transform.position);

		//looks at player if close enough
		if(distance < lookDistance){
			LookAt();
		}

		//stops looking at player
		if(distance > lookDistance){
			rend.material.SetColor("_Color", Color.green);
		}

		if(distance < attackRange){
			Attack();
		}
		//stops to attack
		else if(distance < chaseRange){
			Chase();
		}
	}

	void LookAt(){
		rend.material.SetColor("_Color", Color.yellow);
		Quaternion rotation = Quaternion.LookRotation(target.position - transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
	}

	void Chase(){
		rend.material.SetColor("_Color", Color.red);

		moveDirection = transform.forward;
		moveDirection *= moveSpeed;
		moveDirection.y -= gravity * Time.deltaTime;

		controller.Move(moveDirection * Time.deltaTime);
	}

	void Attack(){
		if(Time.time > attackTime){
			target.SendMessage("ApplyDamage", damage);
			//Debug.Log("Enemy has attacked");
			attackTime = Time.time + attackRepeatTime;
		}
	}

	void ApplyDamage(){
		chaseRange += 30;
		moveSpeed += 2;
		lookDistance += 40;
	}
}
