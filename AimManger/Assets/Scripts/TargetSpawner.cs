using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour {
	[SerializeField] TargetSpawnData targetSpawnData;
	[SerializeField] AimingResults aimingResults;

	[SerializeField] Transform hierarchy_targets;
	[SerializeField] Camera mainCamera;
	[SerializeField] GameObject playerObj;
	[SerializeField] GameObject prefab_target;
	//[SerializeField] GameObject prefab_targetSpawnRange;

	public float ray_maxDistance = 100000000000f;
	public int layerMask;

	const float RADIUS_SPHERE_COORDINATE = 10f;

	Vector3 prevSpawnRotation;
	//const float SPAWN_Z_POS = 10f;

	void Awake() {
		layerMask = 1 << LayerMask.NameToLayer("Coordinate");
		Spawn_Target();
		//StartCoroutine(Spawn_Via_LifeTime_Coroutine());
	}
	
	IEnumerator Spawn_Via_LifeTime_Coroutine() {
		float _timer = targetSpawnData.lifeTime;

		while (_timer >= 0) {
			_timer -= Time.deltaTime;
			yield return null;
		}
		Spawn_Target();
		aimingResults.HitOrMiss(false);
	}

	float Degree_To_Radian(float degree) => Mathf.PI * degree / 180f;
	float Radian_To_Degree(float radian) => radian * (180f / Mathf.PI);

	public void Despawn_Target(GameObject target) {
		Destroy(target);
	}

	public void Spawn_Target() {
		RaycastHit _hitInfo;
		Vector3 _tempRotation = Calculate_Raycast_Rotation(mainCamera.transform.position, mainCamera.transform.forward);
		Vector3 _outerPosition = mainCamera.transform.position + 5 * _tempRotation;
		// 왜 10f은 되고 100f는 안될까? -> 왠진 모르겠는데 100f로 하면 너무 멀어짐
		/*타겟 사라지던 버그 해결 : _tempRotation에 곱해주는 값을 10에서 점점 줄이니 버그가 사라졌음.
		* 원래 작은 각도에서보다 큰 각도에서 버그가 빈번히 발생하는 경향이 있었음.
		* 버그 일어난 근본적인 원인은 추후 알아봐야 할 듯.*/
		//Debug.DrawRay(_outerPosition, -(_tempRotation)*1000f, Color.red, 1f);
		if (Physics.Raycast(_outerPosition, -(_tempRotation), out _hitInfo, ray_maxDistance, layerMask)) {
			GameObject _target = Instantiate(prefab_target, _hitInfo.point, Quaternion.identity, hierarchy_targets);
			_target.GetComponent<TargetProps>().Init_Props(targetSpawnData.size, targetSpawnData.lifeTime);
			//Debug.Log("Instantiate");
		}
		/*Debug.Log("outerPosition : " + _outerPosition);
		Debug.Log("hitPoint : " + _hitInfo.point);*/
	}

	Vector3 Calculate_Raycast_Rotation(Vector3 originPosition, Vector3 originRotation) {
		RaycastHit _hitInfo;
		Vector3 _outerPosition = mainCamera.transform.position + 100f * originRotation;
		Physics.Raycast(_outerPosition, -originRotation, out _hitInfo, ray_maxDistance, layerMask);
		float _tangentTheta = Mathf.Tan(Degree_To_Radian(Mathf.Clamp(targetSpawnData.spawnAngle, TargetSpawnData.MIN_SPAWN_ANGLE, TargetSpawnData.MAX_SPAWN_ANGLE)));
		float _totalCapacity = Mathf.Pow(RADIUS_SPHERE_COORDINATE * _tangentTheta, 2);
		float _deltaX = Random.Range(-RADIUS_SPHERE_COORDINATE * _tangentTheta, RADIUS_SPHERE_COORDINATE * _tangentTheta);
		_totalCapacity -= Mathf.Pow(_deltaX, 2);
		float _deltaY = Random.Range(-Mathf.Sqrt(_totalCapacity), Mathf.Sqrt(_totalCapacity));
		_totalCapacity -= Mathf.Pow(_deltaY, 2);
		float _deltaZ = Random.Range(-Mathf.Sqrt(_totalCapacity), Mathf.Sqrt(_totalCapacity));

		Vector3 _newPosition = new Vector3(_hitInfo.point.x + _deltaX, _hitInfo.point.y + _deltaY, _hitInfo.point.z + _deltaZ);
		//Debug.Log("rot : " + (_newPosition - originPosition));
		//Debug.Log("normalized rot : " + (_newPosition - originPosition).normalized);
		return (_newPosition - originPosition);
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
