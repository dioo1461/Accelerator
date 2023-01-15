using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetProps : MonoBehaviour
{
	public float _lifeTime;
	public int _health;

	public void Init_Props(float size, float lifeTime, int health = 1) {
		Apply_Scale(size);
		_lifeTime = Mathf.Clamp(lifeTime, TargetSpawnData.MIN_LIFETIME, TargetSpawnData.MAX_SPAWN_ANGLE);
		_health = health;
		//StartCoroutine(Destroy_Via_Lifetime_Coroutine());
	}

	void Apply_Scale(float scale) {
		if (scale > TargetSpawnData.MAX_SIZE) {
			gameObject.transform.localScale *= TargetSpawnData.MAX_SIZE;
			return;
		}
		if (scale < TargetSpawnData.MIN_SIZE) {
			gameObject.transform.localScale *= TargetSpawnData.MIN_SIZE;
			return;
		}
		gameObject.transform.localScale *= scale;
	}
	
}
