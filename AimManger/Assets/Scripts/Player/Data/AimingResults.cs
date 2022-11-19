using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingResults : MonoBehaviour
{
	public TargetSpawnData targetSpawnData;

	public float accuracy { get; private set; }
	public bool is_hit = false;

	float _num_hits = 0f;
	float _num_misses = 0f;
	float _num_total = 0f;

	int _cnt_targetSize = 0;
	int _cnt_targetLifetime = 0;

	const float STANDARD_ACCURACY = 50f;

	const float SIZE_MODIFICATION_RATIO = 1.05f;
	const int SIZE_MODIFICATION_TRIGGER_COUNT = 3;

	const float LIFETIME_MODIFICATION_AMOUNT = 0.01f;
	const int LIFETIME_MODIFICATION_TRIGGER_COUNT = 5;

	void OnShoot() {
		if (is_hit) {
			_num_hits++;
			_num_total++;
		} else {
			_num_misses++;
			_num_total++;
		}
		accuracy = _num_hits / _num_total;

		Modify_Target_Size();
		Modify_Target_Lifetime();
	}

	void Modify_Target_Size() {
		if (accuracy >= STANDARD_ACCURACY) {
			if (_cnt_targetSize >= 0) {
				_cnt_targetSize++;
			} else {
				_cnt_targetSize = 0;
				_cnt_targetSize++;
			}
		} else {
			if (_cnt_targetSize < 0) {
				_cnt_targetSize--;
			} else {
				_cnt_targetSize = 0;
				_cnt_targetSize--;
			}
		}

		if (_cnt_targetSize == SIZE_MODIFICATION_TRIGGER_COUNT) {
			// Size Up Target
			targetSpawnData.size *= SIZE_MODIFICATION_RATIO;
			_cnt_targetSize = 0;
			return;
		}

		if (_cnt_targetSize == -(SIZE_MODIFICATION_TRIGGER_COUNT)) {
			// Size Down Target
			targetSpawnData.size /= SIZE_MODIFICATION_RATIO;
			_cnt_targetSize = 0;
			return;
		}
	}

	void Modify_Target_Lifetime() {
		if (accuracy >= STANDARD_ACCURACY) {
			if (_cnt_targetLifetime >= 0) {
				_cnt_targetLifetime++;
			} else {
				_cnt_targetLifetime = 0;
				_cnt_targetLifetime++;
			}
		} else {
			if (_cnt_targetLifetime < 0) {
				_cnt_targetLifetime--;
			} else {
				_cnt_targetLifetime = 0;
				_cnt_targetLifetime--;
			}
		}

		if (_cnt_targetLifetime == LIFETIME_MODIFICATION_TRIGGER_COUNT) {
			// Decrease target Lifetime
			targetSpawnData.lifeTime -= LIFETIME_MODIFICATION_AMOUNT;
			_cnt_targetLifetime = 0;
			return;
		}

		if (_cnt_targetLifetime == -(LIFETIME_MODIFICATION_TRIGGER_COUNT)) {
			// Increase target Lifetime
			targetSpawnData.lifeTime += LIFETIME_MODIFICATION_AMOUNT;
			_cnt_targetLifetime = 0;
			return;
		}
	}

	void Modify_Target_Spawn_Angle() {
		if (accuracy >= STANDARD_ACCURACY) {
			
		} else {
			
		}

		if (_cnt_targetLifetime == LIFETIME_MODIFICATION_TRIGGER_COUNT) {
			// Decrease target Lifetime
			targetSpawnData.lifeTime -= LIFETIME_MODIFICATION_AMOUNT;
			_cnt_targetLifetime = 0;
			return;
		}

		if (_cnt_targetLifetime == -(LIFETIME_MODIFICATION_TRIGGER_COUNT)) {
			// Increase target Lifetime
			targetSpawnData.lifeTime += LIFETIME_MODIFICATION_AMOUNT;
			_cnt_targetLifetime = 0;
			return;
		}






	}

}
