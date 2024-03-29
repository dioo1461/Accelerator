﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordinateRotation : MonoBehaviour {
	public UserData userData;
	public Transform playerTransform;

	public float sensitivity = 4f; // 마우스 회전 속도
	public float moveSpeed = 1.0f; // 이동 속도

	public const float YAW_PITCH_VALUE = 0.0066f;

	void Update() {
		CoordinateFollowing();
		Rotate_Coordinate();
		//KeyboardMove();
	}

	// 마우스의 움직임에 따라 카메라를 회전 시킨다.
	void Rotate_Coordinate() {
		// 좌우로 움직인 마우스의 이동량 * 속도에 따라 카메라가 좌우로 회전할 양 계산
		float yRotateSize = Input.GetAxis("Mouse X") * sensitivity;
		// 현재 y축 회전값에 더한 새로운 회전각도 계산
		float yRotate = transform.eulerAngles.y + yRotateSize;

		// 위아래로 움직인 마우스의 이동량 * 속도에 따라 카메라가 회전할 양 계산(하늘, 바닥을 바라보는 동작)
		float xRotateSize = -Input.GetAxis("Mouse Y") * sensitivity;
		// 위아래 회전량을 더해주지만 -90도 ~ 90도로 제한 (-90:하늘방향, 90:바닥방향)
		// Clamp 는 값의 범위를 제한하는 함수
		float xRotate = Mathf.Clamp(transform.eulerAngles.x + xRotateSize, -90, 90);
		// 카메라 회전량을 카메라에 반영(X, Y축만 회전)
		transform.eulerAngles = new Vector3(xRotate, yRotate, 0);
	}

	/*// 키보드의 눌림에 따라 이동
    void KeyboardMove() {
        // WASD 키 또는 화살표키의 이동량을 측정
        Vector3 dir = new Vector3(
            Input.GetAxis("Horizontal"),
            0,
            Input.GetAxis("Vertical")
        );
        // 이동방향 * 속도 * 프레임단위 시간을 곱해서 카메라의 트랜스폼을 이동
        transform.Translate(dir * moveSpeed * Time.deltaTime);
    }*/

	void CoordinateFollowing() {
		transform.position = playerTransform.position + new Vector3(0, 0, 10f);
	}
}