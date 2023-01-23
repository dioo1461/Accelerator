using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {
	[SerializeField] TargetSpawner targetSpawner;
	[SerializeField] TargetSpawnData targetSpawnData;
	[SerializeField] TargetsManager targetsManager;
	[SerializeField] AimingResults aimingResults;
	[SerializeField] DebugDamageDisplayer debugDamageDisplayer;

	[SerializeField] GameObject prefab_target;
	[SerializeField] GameObject playerObj;
	[SerializeField] Camera mainCamera;

	int _current_weapon = 1;

	RaycastHit hitInfo;
	float ray_maxDistance = 10000f;
	int layerMask;
	float _lifeTime_timer;
	GameObject _current_target_obj;


	void Start() {
		layerMask = 1 << LayerMask.NameToLayer("Target");
		_current_target_obj = targetSpawner.Spawn_Target();
		_lifeTime_timer = targetSpawnData.Get_Target_LifeTime();
	}

	void Equip_Rifle() {

	}

	void Update() {
		switch (_current_weapon) {
			case 1:
				if (MyInputMethods.singleton.Periodical_Check_KeyPress(KeyBinding.fire_1, 60f/WeaponsData.RIFLE_RPM)) {
					GameObject _hitObj = Get_Hit_Target();
					if (_hitObj != null) {
						aimingResults.HitOrMiss(true);
						debugDamageDisplayer.Display_Damage(_hitObj, WeaponsData.RIFLE_DAMAGE);
						// 라이플 대미지로 타깃이 죽으면 없애고 재생성
						if (Rifle.singleton.Shoot_Target(_hitObj) == true) {
							Respawn_Target(_hitObj);
						}
					} else {
						aimingResults.HitOrMiss(false);
					}
				}
				break;
		}

		if (_lifeTime_timer > 0) {
			_lifeTime_timer -= Time.deltaTime;
		} else {
			Respawn_Target(_current_target_obj);
			aimingResults.HitOrMiss(false);
		}
	}

	void Respawn_Target(GameObject pre_target) {
		targetSpawner.Despawn_Target(pre_target);
		_current_target_obj = targetSpawner.Spawn_Target();
		_lifeTime_timer = targetSpawnData.Get_Target_LifeTime();
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
