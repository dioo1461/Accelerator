using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {
	[SerializeField] TargetSpawner targetSpawner;
	[SerializeField] TargetSpawnData targetSpawnData;
	[SerializeField] TargetsManager targetsManager;
	[SerializeField] AimingResults aimingResults;

	[SerializeField] GameObject prefab_target;
	[SerializeField] GameObject playerObj;
	[SerializeField] Camera mainCamera;

	RaycastHit hitInfo;
	float ray_maxDistance = 10000f;
	int layerMask;
	float _timer;
	GameObject _current_target_obj;

	void Start() {
		layerMask = 1 << LayerMask.NameToLayer("Target");
		_current_target_obj = targetSpawner.Spawn_Target();
		_timer = targetSpawnData.Get_Target_LifeTime();
	}

	void Update() {
		if (Input.GetKeyDown(KeyBinding.fire_1)) {
			GameObject _hitObj = Get_Hit_Target();
			if (_hitObj != null) {
				aimingResults.HitOrMiss(true);
				Respawn_Target(_hitObj);
			} else {
				aimingResults.HitOrMiss(false);
			}
		}

		if (_timer > 0) {
			_timer -= Time.deltaTime;
		} else {
			Respawn_Target(_current_target_obj);
			aimingResults.HitOrMiss(false);
		}		
	}

	void Respawn_Target(GameObject pre_target) {
		targetSpawner.Despawn_Target(pre_target);
		_current_target_obj = targetSpawner.Spawn_Target();
		_timer = targetSpawnData.Get_Target_LifeTime();
	}

	GameObject Get_Hit_Target() {
		Debug.DrawRay(mainCamera.transform.position, mainCamera.transform.forward * 1000f, Color.blue, 1f);
		if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hitInfo, ray_maxDistance, layerMask)) {
			return hitInfo.transform.gameObject;
		} else {
			return null;
		}
	}
}
