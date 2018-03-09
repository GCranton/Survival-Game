using UnityEngine;
using System.Collections;

public class EnemyLogic : MonoBehaviour {
	public int Health = 100;

	void ApplyDamage(int Damage) {
		Health -= Damage;
		if(Health <= 0){
			Death();
		}
	}

	void Death() {
		Destroy(gameObject);
	}
}
