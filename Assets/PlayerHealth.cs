using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	public int Health = 100;


	void ApplyDamage(int Damage) {
		Health -= Damage;
		if(Health <= 0){
			Death();
		}
	}

	void Death() {
		//Destroy(gameObject);
		//Debug.Log("You Died!");
		RespawnMenu menu = GetComponent<RespawnMenu>();
		menu.playerIsDead = true;
	}
}
