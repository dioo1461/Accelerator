using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetsManager : MonoBehaviour
{
	[SerializeField] TargetSpawnData targetSpawnData;

	public TargetProps[] targets_arr;

	int _cur_idx = 0; // 현재 탐색의 시작이 되는 index(자신을 포함하여 탐색)
	int _targets_cnt = 0;
	bool _is_cycle_completed = false;

	public const int TARGETS_ARR_MAX_CAPACITY = 5000;

	private void Start() {
		targets_arr = new TargetProps[TARGETS_ARR_MAX_CAPACITY];
	}

	/// <summary> 배열에서 빈 지점을 찾아 index를 반환. 배열이 꽉 차있을 경우 -1 반환.
	/// </summary>
	int Find_Empty_Index() {
		int _search_idx = _cur_idx;
		// int _search_cnt = 0;
		// 아직 Array 한바퀴를 다 안 돌았을 때는 (cur_idx 뒤쪽이 다 비어있는 상태)
		// 그냥 _cur_idx 바로 뒤 index를 반환하면 됨
		if (!_is_cycle_completed) {
			_cur_idx++;
			if (_cur_idx >= TARGETS_ARR_MAX_CAPACITY - 1) {
				_cur_idx = 0;
				_is_cycle_completed = true;
			}
			return _search_idx;
		}

		// 한바퀴 돈 상태면 index 0부터 순서대로 탐색
		// 아니면 한바퀴 돌때마다 비어있는공간을 제거하기?
		// (타겟이 절반 이상일 때 조건, 혹은 성능테스트 후 임계점을 찾아 그 지점을 조건으로 하기)
		_search_idx = 0;
		while (_search_idx < TARGETS_ARR_MAX_CAPACITY) {
			if (targets_arr[_search_idx]==null) {
				_cur_idx = _search_idx + 1;
				return _search_idx;
			}
		}

		// 배열이 꽉 차면 -1 반환
		return -1;
	}

	/// <summary>targets_arr 배열에 등록 성공 시 true, 등록 실패 시 해당 타깃 객체 파괴 후 false 반환
	/// </summary>
	public bool Add_Target(GameObject target) {
		int _empty_idx = Find_Empty_Index();
		if (_empty_idx != -1) {
			targets_arr[_empty_idx] = target.GetComponent<TargetProps>();
			target.GetComponent<TargetProps>().Init_Props(_empty_idx, targetSpawnData.Get_Target_Size(), targetSpawnData.Get_Target_LifeTime());
			_targets_cnt++;
			return true;
		} else {
			Destroy(target);
			Debug.Log("Target Spawn Limit Exceeded");
			return false;
		}
	}

	public void Damage_Target(GameObject target, float damage) {
		int _id = GetComponent<TargetProps>().id;
		targets_arr[_id].health -= damage;
		if (targets_arr[_id].health <= 0) {
			Remove_Target(target);
		}
	}

	public void Remove_Target(GameObject target) {
		targets_arr[target.GetComponent<TargetProps>().id] = null;
		_targets_cnt--;
	}

	public TargetProps Get_Target_Props(int target_id) {
		return targets_arr[target_id];
	}

	public GameObject Get_Target_Obj(int target_id) {
		return targets_arr[target_id].gameObject;
	}

	public int Get_target_ID(GameObject target) {
		return target.GetComponent<TargetProps>().id;
	}

}
