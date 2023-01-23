using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : Weapons {
	public static Rifle singleton;

	[SerializeField] TargetsManager targetsManager;

	public float damage; // 발당 대미지
	public float rpm; // 분당 연사속도 (초당 연사속도 * 60)
	public float head_multiplication; // 헤드샷 계수
	public float recoil; // 반동 세기 (0 ~ 0)

	private void Awake() {
		singleton = this;
		Init_Data();
	}
	void Init_Data() {
		damage = WeaponsData.RIFLE_DAMAGE;
		rpm = WeaponsData.RIFLE_RPM;
		head_multiplication = WeaponsData.RIFLE_HEAD_MULTIPLICATION;
		recoil = WeaponsData.RIFLE_RECOIL;
	}

	// public new float spread_ratio;

	/// <summary> 타깃을 쏴서 그 대미지로 죽으면 true, 아니면 false 반환.
	/// </summary>
	public override bool Shoot_Target(GameObject target) {
		return targetsManager.Damage_Target(target, damage);
	}



}
