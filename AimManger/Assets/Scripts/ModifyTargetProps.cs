using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifyTargetProps : MonoBehaviour
{
	[SerializeField] AimingResults aimingResults;
	[SerializeField] TargetSpawnData targetSpawnData;

	[SerializeField] GameObject prefab_Target;

	int _cnt_targetSize = 0;
	int _cnt_targetLifetime = 0;
	int _cnt_targetSpawnAngle = 0;

	const float SIZE_MODIFICATION_RATIO = 1.05f;
	const int SIZE_MODIFICATION_TRIGGER_COUNT = 3;

	const float LIFETIME_MODIFICATION_AMOUNT = 0.01f;
	const int LIFETIME_MODIFICATION_TRIGGER_COUNT = 5;

	const float SPAWNANGLE_MODIFICATION_AMOUNT = 1f;
	const int SPAWNANGLE_MODIFICATION_TRIGGER_COUNT = 3;

	public void Extend_Target_Size() {
		if (_cnt_targetSize >= 0) {
			_cnt_targetSize++;
		} else {
			// 연속이 끊기면 초기화
			_cnt_targetSize = 0;
			_cnt_targetSize++;
		}
		
		if (_cnt_targetSize == SIZE_MODIFICATION_TRIGGER_COUNT) {
			// Size Up Target
			targetSpawnData.size *= SIZE_MODIFICATION_RATIO;
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

		if (_cnt_targetSize == -(SIZE_MODIFICATION_TRIGGER_COUNT)) {
			// Size Down Target
			targetSpawnData.size /= SIZE_MODIFICATION_RATIO;
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

		if (_cnt_targetLifetime == LIFETIME_MODIFICATION_TRIGGER_COUNT) {
			// Increase target Lifetime
			targetSpawnData.lifeTime += LIFETIME_MODIFICATION_AMOUNT;
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

		if (_cnt_targetLifetime == -(LIFETIME_MODIFICATION_TRIGGER_COUNT)) {
			// Decrease target Lifetime
			targetSpawnData.lifeTime -= LIFETIME_MODIFICATION_AMOUNT;
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

		if (_cnt_targetSpawnAngle == SPAWNANGLE_MODIFICATION_TRIGGER_COUNT) {
			// Increase target SpawnAngle
			targetSpawnData.spawnAngle += SPAWNANGLE_MODIFICATION_AMOUNT;
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

		if (_cnt_targetSpawnAngle == -(SPAWNANGLE_MODIFICATION_TRIGGER_COUNT)) {
			// Decrease target SpawnAngle
			targetSpawnData.spawnAngle -= SPAWNANGLE_MODIFICATION_AMOUNT;
			_cnt_targetSpawnAngle = 0;
			return;
		}
	}
}
