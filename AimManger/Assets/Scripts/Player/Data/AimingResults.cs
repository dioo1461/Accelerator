using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingResults : MonoBehaviour
{
	[SerializeField] TargetSpawner targetSpawner;
	[SerializeField] TargetSpawnData targetSpawnData;
	[SerializeField] AdjustTargetProps adjustTargetProps;

	[SerializeField] GameObject prefab_target;


	public float accuracy { get; private set; }
	public bool is_hit = false;

	public float num_hits = 0f;
	public float num_misses = 0f;
	public float num_total = 0f;

	public const float STANDARD_ACCURACY = 50f;

	public void HitOrMiss(bool isHit) {
		if (isHit) {
			num_hits++;
			num_total++;
		} else {
			num_misses++;
			num_total++;
		}

		accuracy = num_hits / num_total * 100f;

		if (accuracy > STANDARD_ACCURACY) {
			adjustTargetProps.Reduce_Target_Size();
			adjustTargetProps.Reduce_Target_Lifetime();
			adjustTargetProps.Extend_Target_Spawn_Angle();
		} else {
			adjustTargetProps.Extend_Target_Size();
			adjustTargetProps.Extend_Target_Lifetime();
			adjustTargetProps.Reduce_Target_Spawn_Angle();
		}
	}
	

}
