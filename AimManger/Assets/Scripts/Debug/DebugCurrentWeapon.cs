using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugCurrentWeapon : MonoBehaviour
{
	[SerializeField] Text text_CurrentWeapon;

	public void Change_Weapon(WeaponsData.WeaponsEnum weapon) {
		text_CurrentWeapon.text = System.Enum.GetName(typeof(WeaponsData.WeaponsEnum), weapon);
	}
}
