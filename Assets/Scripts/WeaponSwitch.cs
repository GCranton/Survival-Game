using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour {
	public GameObject weapon1;
	public GameObject weapon2;
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Swap Weapon")){
			SwitchWeapons();
		}
	}

	void SwitchWeapons(){
		if(weapon1.active){
			weapon1.SetActive(false);
			weapon2.SetActive(true);
		}
		else if(weapon2.active){
			weapon2.SetActive(false);
			weapon1.SetActive(true);
		}
	}
}
