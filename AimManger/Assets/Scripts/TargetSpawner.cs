using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour {
	public TargetSpawnData targetSpawnData;

	public Transform hierarchy_targets;
	public Camera mainCamera;
	public GameObject playerObj;
	public GameObject prefab_target;
	public GameObject prefab_targetSpawnRange;

	public float ray_maxDistance = 10000f;
	public int layerMask;

	Vector3 prevSpawnRotation;
	RaycastHit hitInfo;
	Ray ray;
	//const float SPAWN_Z_POS = 10f;

	void Awake() {
		layerMask = 1 << LayerMask.NameToLayer("Coordinate");

		Spawn_Target();
	}
	void Update() {
		
	}

	public void Despawn_Target(GameObject target) {
		Destroy(target);
	}

	public void Spawn_Target() {
		Debug.DrawRay(mainCamera.transform.position, Calculate_Raycast_Rotation(mainCamera.transform.forward) * 1000, Color.red, 1f);
		if (Physics.Raycast(mainCamera.transform.position, Calculate_Raycast_Rotation(mainCamera.transform.forward), out hitInfo, ray_maxDistance, layerMask)) {
			Instantiate(prefab_target, hitInfo.point, Quaternion.identity, hierarchy_targets);
			Debug.Log("Instantiate");
		}
	}

	Vector3 Calculate_Raycast_Rotation(Vector3 originRotation) {
		Debug.Log(originRotation.x);
		Debug.Log(originRotation.y);
		Debug.Log(originRotation.z);
		float tempX = Random.Range(originRotation.x - targetSpawnData.spawnAngleRange, originRotation.x + targetSpawnData.spawnAngleRange);
		float tempY = Random.Range(originRotation.y - targetSpawnData.spawnAngleRange, originRotation.y + targetSpawnData.spawnAngleRange);
		float tempZ = Random.Range(originRotation.z - targetSpawnData.spawnAngleRange, originRotation.z + targetSpawnData.spawnAngleRange);

		return new Vector3(tempX, tempY, tempZ);
	}





	/*void Spawn_TargetSpawnRange() {
		Instantiate(prefab_targetSpawnRange, playerTransform.localPosition, playerTransform.rotation, hierarchy_targets);
	}


	void temp() {
		GameObject targetSpawnRange = Instantiate(prefab_targetSpawnRange, playerTransform.localPosition, playerTransform.rotation, hierarchy_targets);

		// raycast from player, target: targetSpawnRange, rotation: Calculate_Spawn_Angle()
		// spawn new target where raycastHit occurs
		// 이렇게 하면 점점 목표물과 거리가 멀어지는 문제 발생..
	}

	Vector3 Calculate_Spawn_Position(float origin_xPos, float origin_yPos, float angle) {

		float _maxPos = SPAWN_Z_POS * Mathf.Tan(angle);
		float _xPos = Random.Range(0, _maxPos) + origin_xPos;
		float _yPos = Random.Range(0, _maxPos) + origin_yPos;

		Vector3 _position = new Vector3(0, 0, SPAWN_Z_POS);

		return _position;
	}*/
	

}
