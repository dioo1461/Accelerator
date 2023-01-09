using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {
	[SerializeField] TargetSpawner targetSpawner;
	[SerializeField] AimingResults aimingResults;

	[SerializeField] GameObject prefab_target;
	[SerializeField] GameObject playerObj;
	[SerializeField] Camera mainCamera;

	RaycastHit hitInfo;
	float ray_maxDistance = 10000f;
	int layerMask;

	void Start() {
		layerMask = 1 << LayerMask.NameToLayer("Target");
	}

	void Update() {
		if (Input.GetKeyDown(KeyBinding.fire_1)) {
			aimingResults.HitOrMiss(Check_Target_Hit());
		}
	}

	

	bool Check_Target_Hit() {
		Debug.DrawRay(mainCamera.transform.position, mainCamera.transform.forward * 1000f, Color.blue, 1f);
		if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hitInfo, ray_maxDistance, layerMask)) {
			Debug.Log(hitInfo.transform.name);
			targetSpawner.Despawn_Target(hitInfo.transform.gameObject);
			targetSpawner.Spawn_Target();
			return true;
		} else {
			return false;
		}
	}
}
