using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugGetAxis : MonoBehaviour
{
	
	[SerializeField] Text _getAxisText;
	[SerializeField] ObjectRotationWithPlayer cameraRotation;
    void Update()
    {
		_getAxisText.text = Input.GetAxis("Mouse X").ToString();

	}
}
