using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugAccuracy : MonoBehaviour
{
	[SerializeField] AimingResults aimingResults;

	[SerializeField] Text text_accuracy;

    void Update()
    {
		text_accuracy.text = "Accuracy : " + aimingResults.accuracy.ToString("F2");
    }
	
}
