using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {
	[SerializeField] TargetSpawner targetSpawner;
	[SerializeField] TargetSpawnData targetSpawnData;
	[SerializeField] TargetsManager targetsManager;
	[SerializeField] AimingResults aimingResults;

	[SerializeField] DebugDamageDisplayer debugDamageDisplayer;
	[SerializeField] DebugCurrentWeapon debugCurrentWeapon;

	[SerializeField] GameObject prefab_target;
	[SerializeField] GameObject playerObj;
	[SerializeField] Camera mainCamera;


	RaycastHit hitInfo;
	float ray_maxDistance = 10000f;
	int layerMask;
	float _lifeTime_timer;
	GameObject _current_target_obj;

	public WeaponsData.WeaponsEnum current_weapon;
	public float _fire_cooldown; // TODO: DebugWeaponCooldown 삭제 후 private 변수로 바꿀 것

	void Start() {
		layerMask = 1 << LayerMask.NameToLayer("Target");
		_current_target_obj = targetSpawner.Spawn_Target();
		_lifeTime_timer = targetSpawnData.Get_Target_LifeTime();
	}


	void Update() {
		switch (current_weapon) {
			case WeaponsData.WeaponsEnum.Rifle:
				if (Input.GetKey(KeyBinding.fire_1) && _fire_cooldown <= 0f) {
					_fire_cooldown = 60 / WeaponsData.RIFLE_RPM;
					GameObject _hitObj = Get_Hit_Target();
					if (_hitObj != null) {
						aimingResults.HitOrMiss(true);
						debugDamageDisplayer.Display_Damage(_hitObj, WeaponsData.RIFLE_DAMAGE);
						// 한 발 쏘고 그 피해로 타깃이 죽으면 없애고 재생성
						if (Rifle.singleton.Shoot_Target(_hitObj) == true) {
							Respawn_Target(_hitObj);
						}
					} else {
						aimingResults.HitOrMiss(false);
					}
				}
				break;

			case WeaponsData.WeaponsEnum.Railgun:
				if (Input.GetKey(KeyBinding.fire_1) && _fire_cooldown <= 0f) {
					_fire_cooldown = 60 / WeaponsData.RAILGUN_RPM;
					GameObject _hitObj = Get_Hit_Target();
					if (_hitObj != null) {
						aimingResults.HitOrMiss(true);
						debugDamageDisplayer.Display_Damage(_hitObj, WeaponsData.RAILGUN_DAMAGE);
						// 한 발 쏘고 그 피해로 타깃이 죽으면 없애고 재생성
						if (Rifle.singleton.Shoot_Target(_hitObj) == true) {
							Respawn_Target(_hitObj);
						}
					} else {
						aimingResults.HitOrMiss(false);
					}
				}
				break;
		}
		_fire_cooldown -= Time.deltaTime;


		if (_lifeTime_timer > 0) {
			_lifeTime_timer -= Time.deltaTime;
		} else {
			Respawn_Target(_current_target_obj);
			aimingResults.HitOrMiss(false);
		}

		// 무기 변경
		if (_fire_cooldown <= 0f && Input.GetKeyDown(KeyBinding.change_rifle_1) || Input.GetKeyDown(KeyBinding.change_rifle_2)) {
			if (current_weapon != WeaponsData.WeaponsEnum.Rifle) {
				Equip_Rifle();
			}
		}
		if (_fire_cooldown <= 0f && Input.GetKeyDown(KeyBinding.change_railgun_1) || Input.GetKeyDown(KeyBinding.change_railgun_2)) {
			if (current_weapon != WeaponsData.WeaponsEnum.Railgun) {
				Equip_Railgun();
			}
		}
		if (_fire_cooldown <= 0f && Input.GetKeyDown(KeyBinding.change_revolver_1) || Input.GetKeyDown(KeyBinding.change_revolver_2)) {
			if (current_weapon != WeaponsData.WeaponsEnum.Revolver) {
				Equip_Revolver();
			}
		}
		if (_fire_cooldown <= 0f && Input.GetKeyDown(KeyBinding.change_shotgun_1) || Input.GetKeyDown(KeyBinding.change_shotgun_2)) {
			if (current_weapon != WeaponsData.WeaponsEnum.Shotgun) {
				Equip_Shotgun();
			}
		}
	}

	#region Equip Weapon
	public void Equip_Rifle() {
		current_weapon = WeaponsData.WeaponsEnum.Rifle;
		_fire_cooldown = WeaponsData.RIFLE_CHANGE_DELAY;
		debugCurrentWeapon.Change_Weapon(WeaponsData.WeaponsEnum.Rifle);
	}

	public void Equip_Railgun() {
		current_weapon = WeaponsData.WeaponsEnum.Railgun;
		_fire_cooldown = WeaponsData.RAILGUN_CHANGE_DELAY;
		debugCurrentWeapon.Change_Weapon(WeaponsData.WeaponsEnum.Railgun);
	}

	public void Equip_Revolver() {
		current_weapon = WeaponsData.WeaponsEnum.Revolver;
		_fire_cooldown = WeaponsData.REVOLVER_CHANGE_DELAY;
		debugCurrentWeapon.Change_Weapon(WeaponsData.WeaponsEnum.Revolver);
	}

	public void Equip_Shotgun() {
		current_weapon = WeaponsData.WeaponsEnum.Shotgun;
		_fire_cooldown = WeaponsData.SHOTGUN_CHANGE_DELAY;
		debugCurrentWeapon.Change_Weapon(WeaponsData.WeaponsEnum.Shotgun);
	}
	#endregion
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
