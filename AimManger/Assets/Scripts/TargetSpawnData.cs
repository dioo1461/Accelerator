using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawnData : MonoBehaviour
{
	public float size { get; private set; }
	public int health { get; private set; }
	public float spawnAngle { get; private set; }
	public float lifeTime { get; private set; }
	

	public const float MAX_SIZE = 2f;
	public const float MIN_SIZE = 0.5f;
	public const float SIZE_CHANGE_PER_TIC = 0.05f;
	public const float SIZE_STANDARD_ACCURACY = 50f;
	public const float MAX_LIFETIME = 0.45f;
	public const float MIN_LIFETIME = 0.10f;
	public const float LIFETIME_CHANGE_PER_TIC = 0.01f;
	public const float LIFETIME_STANDARD_ACCURACY = 50f;
	public const float MAX_SPAWN_ANGLE = 70f;
	public const float MIN_SPAWN_ANGLE = 30f;
	public const float ANGLE_CHANGE_PER_TIC = 5f;
}	
