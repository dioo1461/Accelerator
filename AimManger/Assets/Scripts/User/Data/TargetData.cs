using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetData : MonoBehaviour
{
	public float size { get; private set; }
	public float spawnAngle { get; private set; }
	public float lifeTime { get; private set; }
	

	const float MAX_SIZE = 1;
	const float MIN_SIZE = 0.5f;
	const float MAX_LIFETIME = 0.45f;
	const float MIN_LIFETIME = 0.1f;

}
