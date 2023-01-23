using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : Weapons {
	void Init_Props() {
		damage = 1f;
		rpm = 600f;
		head_multiplication = 2f;
		recoil = 0f;
	}
	public Rifle() {
		
	}
	// public new float spread_ratio;


}
