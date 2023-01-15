using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawnData : MonoBehaviour
{
	public float size;
	public float lifeTime;
	public float spawnAngle;
	public int health;

	/// <summary>
	/// 타깃 Size의 최소, 최대값의 범위를 넘지 않는 값 반환
	/// </summary>
	public float Get_Target_Size() {
		return Mathf.Clamp(size, MIN_SIZE, MAX_SIZE);
	}

	/// <summary>
	/// 타깃 LifeTime의 최소, 최대값의 범위를 넘지 않는 값 반환
	/// </summary>
	public float Get_Target_LifeTime() {
		return Mathf.Clamp(lifeTime, MIN_LIFETIME, MAX_LIFETIME);
	}

	/// <summary>
	/// 타깃 SpawnAngle의 최소, 최대값의 범위를 넘지 않는 값 반환
	/// </summary>
	public float Get_Target_SpawnAngle() {
		return Mathf.Clamp(spawnAngle, MIN_SPAWN_ANGLE, MAX_SPAWN_ANGLE);
	}
	
	public const float MAX_SIZE = 2f;
	public const float MIN_SIZE = 0.5f;
	public const float SIZE_STANDARD_ACCURACY = 50f;
	public const float SIZE_ADJUST_RATIO_PER_TIC = 1.05f;
	public const int SIZE_ADJUST_TRIGGER_COUNT = 3;

	public const float MAX_LIFETIME = 1.50f;
	public const float MIN_LIFETIME = 0.50f;
	public const float LIFETIME_STANDARD_ACCURACY = 50f;
	public const float LIFETIME_ADJUST_AMOUNT_PER_TIC = 0.1f;
	public const int LIFETIME_ADJUST_TRIGGER_COUNT = 3;

	public const float MAX_SPAWN_ANGLE = 40f;
	public const float MIN_SPAWN_ANGLE = 10f;
	public const float SPAWN_ANGLE_STANDARD_ACCURACY = 50f;
	public const float SPAWN_ANGLE_ADJUST_AMOUNT_PER_TIC = 1f;
	public const int SPAWN_ANGLE_ADJUST_TRIGGER_COUNT = 3;

}	
