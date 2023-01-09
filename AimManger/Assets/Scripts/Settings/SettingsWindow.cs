using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsWindow : MonoBehaviour
{
	[SerializeField] GameObject settingsWindow;

	public void Enable_Settings_Window() {
		settingsWindow.SetActive(false);
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
	}

	public void Disable_Settings_Window() {
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}

	void start() {
		
	}
}
