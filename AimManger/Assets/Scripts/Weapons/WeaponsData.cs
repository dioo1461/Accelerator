using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsData : MonoBehaviour
{
	public enum Enum {
		None = 0,
		Rifle = 1,
		Railgun = 2,
		Revolver = 3,
		Shotgun = 4,
	}

	public const float RIFLE_DAMAGE = 1f;
	public const float RIFLE_RPM = 600f;
	public const float RIFLE_HEAD_MULTIPLICATION = 2f;
	public const float RIFLE_RECOIL = 0f;
	public const float RIFLE_SPREAD_RATIO = 0f;
	public const int RIFLE_AMMUNITION_AMOUNT = -1;

	public const float RAILGUN_DAMAGE = 1f;
	public const float RAILGUN_RPM = 30f;
	public const float RAILGUN_HEAD_MULTIPLICATION = 2f;
	public const float RAILGUN_RECOIL = 0f;
	public const float RAILGUN_SPREAD_RATIO = 0f;
	public const int RAILGUN_AMMUNITION_AMOUNT = -1;

	public const float REVOLVER_DAMAGE = 1f;
	public const float REVOLVER_RPM = 60f;
	public const float REVOLVER_HEAD_MULTIPLICATION = 2f;
	public const float REVOLVER_RECOIL = 0f;
	public const int REVOLVER_AMMUNITION_AMOUNT = -1;
	public const float REVOLVER_SPREAD_RATIO = 0f;

	public const float SHOTGUN_DAMAGE = 1f;
	public const float SHOTGUN_RPM = 80f;
	public const float SHOTGUN_HEAD_MULTIPLICATION = 2f;
	public const float SHOTGUN_RECOIL = 0f;
	public const int SHOTGUN_AMMUNITION_AMOUNT = -1;
	public const float SHOTGUN_SPREAD_RATIO = 0f;




}
