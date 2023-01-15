using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustTargetProps : MonoBehaviour
{
	[SerializeField] AimingResults aimingResults;
	[SerializeField] TargetSpawnData targetSpawnData;

	[SerializeField] GameObject prefab_Target;

	int _cnt_targetSize = 0;
	int _cnt_targetLifetime = 0;
	int _cnt_targetSpawnAngle = 0;


	public void Extend_Target_Size() {
		if (_cnt_targetSize >= 0) {
			_cnt_targetSize++;
		} else {
			// 연속이 끊기면 초기화
			_cnt_targetSize = 0;
			_cnt_targetSize++;
		}
		
		if (_cnt_targetSize == TargetSpawnData.SIZE_ADJUST_TRIGGER_COUNT) {
			// Size Up Target
			targetSpawnData.size *= TargetSpawnData.SIZE_ADJUST_RATIO_PER_TIC;
			_cnt_targetSize = 0;
			return;
		}
	}

	public void Reduce_Target_Size() {
		if (_cnt_targetSize < 0) {
			_cnt_targetSize--;
		} else {
			// 연속이 끊기면 초기화
			_cnt_targetSize = 0;
			_cnt_targetSize--;
		}

		if (_cnt_targetSize == -(TargetSpawnData.SIZE_ADJUST_TRIGGER_COUNT)) {
			// Size Down Target
			targetSpawnData.size /= TargetSpawnData.SIZE_ADJUST_RATIO_PER_TIC;
			_cnt_targetSize = 0;
			return;
		}
	}
	public void Extend_Target_Lifetime() {
		if (_cnt_targetLifetime >= 0) {
			_cnt_targetLifetime++;
		} else {
			// 연속이 끊기면 초기화
			_cnt_targetLifetime = 0;
			_cnt_targetLifetime++;
		}

		if (_cnt_targetLifetime == TargetSpawnData.LIFETIME_ADJUST_TRIGGER_COUNT) {
			// Increase target Lifetime
			targetSpawnData.lifeTime += TargetSpawnData.LIFETIME_ADJUST_AMOUNT_PER_TIC;
			_cnt_targetLifetime = 0;
			return;
		}
	}

	public void Reduce_Target_Lifetime() {
		if (_cnt_targetLifetime < 0) {
			_cnt_targetLifetime--;
		} else {
			// 연속이 끊기면 초기화
			_cnt_targetLifetime = 0;
			_cnt_targetLifetime--;
		}

		if (_cnt_targetLifetime == -(TargetSpawnData.LIFETIME_ADJUST_TRIGGER_COUNT)) {
			// Decrease target Lifetime
			targetSpawnData.lifeTime -= TargetSpawnData.LIFETIME_ADJUST_AMOUNT_PER_TIC;
			_cnt_targetLifetime = 0;
			return;
		}
	}

	public void Extend_Target_Spawn_Angle() {
		if (_cnt_targetSpawnAngle >= 0) {
			_cnt_targetSpawnAngle++;
		} else {
			// 연속이 끊기면 초기화
			_cnt_targetSpawnAngle = 0;
			_cnt_targetSpawnAngle++;
		}

		if (_cnt_targetSpawnAngle == TargetSpawnData.SPAWN_ANGLE_ADJUST_TRIGGER_COUNT) {
			// Increase target SpawnAngle
			targetSpawnData.spawnAngle += TargetSpawnData.SPAWN_ANGLE_ADJUST_AMOUNT_PER_TIC;
			_cnt_targetSpawnAngle = 0;
			return;
		}
	}

	public void Reduce_Target_Spawn_Angle() {
		if (_cnt_targetSpawnAngle < 0) {
			_cnt_targetSpawnAngle--;
		} else {
			// 연속이 끊기면 초기화
			_cnt_targetSpawnAngle = 0;
			_cnt_targetSpawnAngle--;
		}

		if (_cnt_targetSpawnAngle == -(TargetSpawnData.SPAWN_ANGLE_ADJUST_TRIGGER_COUNT)) {
			// Decrease target SpawnAngle
			targetSpawnData.spawnAngle -= TargetSpawnData.SPAWN_ANGLE_ADJUST_AMOUNT_PER_TIC;
			_cnt_targetSpawnAngle = 0;
			return;
		}
	}
}
