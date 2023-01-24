using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
	[SerializeField] DebugCurrentWeapon debugCurrentWeapon;

	public WeaponsData.WeaponsEnum current_weapon;

	private void Awake() {
		current_weapon = WeaponsData.WeaponsEnum.Rifle;
		
	}

	private void Update() {

	}
	#region Equip Weapon
	public void Equip_Rifle() {
		current_weapon = WeaponsData.WeaponsEnum.Rifle;
		debugCurrentWeapon.Change_Weapon(WeaponsData.WeaponsEnum.Rifle);
	}

	public void Equip_Railgun() {
		current_weapon = WeaponsData.WeaponsEnum.Railgun;
		debugCurrentWeapon.Change_Weapon(WeaponsData.WeaponsEnum.Railgun);
	}

	public void Equip_Revolver() {
		current_weapon = WeaponsData.WeaponsEnum.Revolver;
		debugCurrentWeapon.Change_Weapon(WeaponsData.WeaponsEnum.Revolver);
	}

	public void Equip_Shotgun() {
		current_weapon = WeaponsData.WeaponsEnum.Shotgun;
		debugCurrentWeapon.Change_Weapon(WeaponsData.WeaponsEnum.Shotgun);
	}
	#endregion

}
