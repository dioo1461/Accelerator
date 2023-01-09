using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetProps : MonoBehaviour
{
	float _lifeTime;
	int _health;

	
	IEnumerator Destroy_Via_Lifetime_Coroutine() {
		float _timer = _lifeTime;
		while (_timer >= 0) {
			_timer -= Time.deltaTime;
			yield return null;
		}
		Destroy(gameObject);
	}

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
