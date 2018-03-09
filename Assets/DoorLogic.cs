using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLogic : MonoBehaviour {
	private bool drawGUI = false;
	private bool doorClosed = true;
	public GameObject door;
	
	void OnGUI(){
		if(drawGUI){
			GUI.Box(new Rect(Screen.width/2 - 51, 200,102,22), "Press E to open");
		}
	}

	// Update is called once per frame
	void Update () {
		if (drawGUI && Input.GetButtonDown("Interact")){
			ChangeDoorState();
		}
	}

	void OnTriggerEnter (Collider collider){
		if(collider.tag == "Player"){
			drawGUI = true;
		}
	}

	void OnTriggerExit (Collider collider) {
		if(collider.tag == "Player"){
			drawGUI = false;
		}
	}

	void ChangeDoorState(){
		if(doorClosed){
			StartCoroutine(DoorOpening());
		}
	}

	IEnumerator DoorOpening(){
		door.GetComponent<Animation>().Play("Open");
		//if I want a sound
		//door.GetComponen<Audio>().PlayOneShot();
		doorClosed = false;

		yield return new WaitForSeconds(3);

		door.GetComponent<Animation>().Play("Close");
		doorClosed = true;
	}
	
}
