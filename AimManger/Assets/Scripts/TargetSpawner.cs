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

	const float RADIUS_SPHERE_COORDINATE = 10f;

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

	float Degree_To_Radian(float degree) => Mathf.PI * degree / 180f;
	float Radian_To_Degree(float radian) => radian * (180f / Mathf.PI);

	public void Despawn_Target(GameObject target) {
		Destroy(target);
	}

	public void Spawn_Target() {
		Vector3 _tempRotation = Calculate_Raycast_Rotation(mainCamera.transform.position, mainCamera.transform.forward);
		Debug.DrawRay(mainCamera.transform.position, _tempRotation * 1000, Color.red, 1f);
		if (Physics.Raycast(mainCamera.transform.position, _tempRotation, out hitInfo, ray_maxDistance, layerMask)) {
			Instantiate(prefab_target, hitInfo.point, Quaternion.identity, hierarchy_targets);
			Debug.Log("Instantiate");
		}
	}

	Vector3 Calculate_Raycast_Rotation(Vector3 originPosition, Vector3 originRotation) {
		RaycastHit _hitInfo;
		Physics.Raycast(mainCamera.transform.position, originRotation, out _hitInfo, ray_maxDistance, layerMask);
		
		// (delta) x^2 + y^2 + z^2 <= radius * tangent theta
		float _tangentTheta = Mathf.Tan(Degree_To_Radian(targetSpawnData.spawnAngleRange));
		float _totalCapacity = Mathf.Pow(RADIUS_SPHERE_COORDINATE * _tangentTheta, 2);
		Debug.Log("Tangent Theta : " + _tangentTheta);
		Debug.Log("TotalCapacity : " + _totalCapacity);
		float _deltaX = Random.Range(-_tangentTheta, _tangentTheta);
		_totalCapacity -= Mathf.Pow(_deltaX, 2);
		float _deltaY = Random.Range(-Mathf.Sqrt(_totalCapacity), Mathf.Sqrt(_totalCapacity));
		_totalCapacity -= Mathf.Pow(_deltaY, 2);
		float _deltaZ = Random.Range(-Mathf.Sqrt(_totalCapacity), Mathf.Sqrt(_totalCapacity));
		Vector3 _newPosition = new Vector3(_hitInfo.point.x + _deltaX, _hitInfo.point.y + _deltaY, _hitInfo.point.z + _deltaZ);

		return _newPosition - originPosition;
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
