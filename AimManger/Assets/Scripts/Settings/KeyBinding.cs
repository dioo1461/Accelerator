using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBinding : MonoBehaviour {

	public static KeyCode moveUp_1;
	public static KeyCode moveDown_1;
	public static KeyCode moveLeft_1;
	public static KeyCode moveRight_1;

	public static KeyCode moveUp_2;
	public static KeyCode moveDown_2;
	public static KeyCode moveLeft_2;
	public static KeyCode moveRight_2;

	public static KeyCode fire_1;
	public static KeyCode fire_2;

	public static KeyCode zoom_1;
	public static KeyCode zoom_2;

	public static KeyCode change_rifle_1;
	public static KeyCode change_rifle_2;
	public static KeyCode change_railgun_1;
	public static KeyCode change_railgun_2;
	public static KeyCode change_revolver_1;
	public static KeyCode change_revolver_2;
	public static KeyCode change_shotgun_1;
	public static KeyCode change_shotgun_2;

	/*	int _stack_index = 0;
		bool[] _stack_check_coroutine_running;*/

	void Start() {
		/*singleton = this;

		_stack_check_coroutine_running = new bool[10];
		for (int i=0; i<10; i++) {
			_stack_check_coroutine_running[i] = false;
		}*/

		moveUp_1 = KeyCode.W;
		moveDown_1 = KeyCode.S;
		moveLeft_1 = KeyCode.A;
		moveRight_1 = KeyCode.D;

		fire_1 = KeyCode.Mouse0;
		zoom_1 = KeyCode.Mouse1;

		change_rifle_1 = KeyCode.Alpha1;
		change_railgun_1 = KeyCode.Alpha2;
		change_revolver_1 = KeyCode.Alpha3;
		change_shotgun_1 = KeyCode.Alpha4;


	}

}


