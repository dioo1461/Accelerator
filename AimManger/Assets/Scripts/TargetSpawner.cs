using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
	public TargetSpawnData targetSpawnData;

	public Transform playerTransform;
	public Transform hierarchy_targets;
	public GameObject prefab_target;
	public GameObject prefab_targetSpawnRange;

	

	//const float SPAWN_Z_POS = 10f;

	public void Spawn_Target() {

	}

	void Spawn_TargetSpawnRange() {
		Instantiate(prefab_targetSpawnRange, playerTransform.localPosition, playerTransform.rotation, hierarchy_targets);
	}

	float Calculate_Spawn_Angle() {
		return Random.Range(0, targetSpawnData.spawnAngle);
	}

	void temp() {
		GameObject targetSpawnRange = Instantiate(prefab_targetSpawnRange, playerTransform.localPosition, playerTransform.rotation, hierarchy_targets);

		// raycast from player, target: targetSpawnRange, rotation: Calculate_Spawn_Angle()
		// spawn new target where raycastHit occurs
		// 이렇게 하면 점점 목표물과 거리가 멀어지는 문제 발생..
	}

	/*Vector3 Calculate_Spawn_Position(float origin_xPos, float origin_yPos, float angle) {

		float _maxPos = SPAWN_Z_POS * Mathf.Tan(angle);
		float _xPos = Random.Range(0, _maxPos) + origin_xPos;
		float _yPos = Random.Range(0, _maxPos) + origin_yPos;

		Vector3 _position = new Vector3(0, 0, SPAWN_Z_POS);

		return _position;
	}*/


}
