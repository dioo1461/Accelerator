using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugDamagePrefab : MonoBehaviour
{
	float timer = 1f;

	private void Update() {
		if (timer > 0f) {
			timer -= Time.deltaTime;
		} else {
			Destroy(gameObject);
		}
	}
	

}
