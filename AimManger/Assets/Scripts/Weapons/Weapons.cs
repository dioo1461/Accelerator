using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapons : MonoBehaviour {
	

	public float damage; // 발당 대미지
	public float rpm; // 분당 연사속도 (초당 연사속도 * 12)
	public float head_multiplication; // 헤드샷 계수
	public float recoil; // 반동 세기 (0 ~ 0)
	// public float spread_ratio;

	
}