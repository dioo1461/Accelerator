using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugWeaponCooldown : MonoBehaviour
{
	[SerializeField] PlayerShooting playerShooting;
	Text text_cooldown;

	private void Awake() {
		text_cooldown = GetComponent<Text>();
	}

	private void Update() {
		text_cooldown.text = playerShooting._fire_cooldown.ToString("F2");
	}
}
