using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class RespawnMenu : MonoBehaviour {
	public bool playerIsDead = false;
	public GameObject melee;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(playerIsDead){
			FirstPersonController control = GetComponent<FirstPersonController>();
			control.enabled = false;

			melee.SetActive(false);

			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}
	}

	void OnGUI(){
		if(playerIsDead){
			if(GUI.Button(new Rect((float)(Screen.width*.5-50),(float)(Screen.height*0.5-20),100,40), "Respawn")){
				respawnPlayer();
			}
			if(GUI.Button(new Rect((float)(Screen.width*0.5-50),(float)(Screen.height*0.5-90),100,40),"Menu")){
				//placeholder
				Debug.Log("Return to Menu");
			}
		}
	}

	void respawnPlayer(){
		//placeholder
		Debug.Log("Respawn the Player");
	}
}
