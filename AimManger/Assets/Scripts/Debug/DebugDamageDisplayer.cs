using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DebugDamageDisplayer : MonoBehaviour
{
	[SerializeField] GameObject prefab_DamageDisplayer;
	[SerializeField] Transform debugCanvas;

	Vector3 Return_Random_Position(Vector3 origin) {
		float _c = 1f;
		float x = Random.Range(origin.x - _c, origin.x + _c);
		float y = Random.Range(origin.y - _c, origin.y + _c);
		float z = Random.Range(origin.z - _c, origin.z + _c);
		return new Vector3(x, y, z);
	}
	public void Display_Damage(GameObject target, float damage) {
		GameObject instance = Instantiate(prefab_DamageDisplayer, Return_Random_Position(target.transform.localPosition), target.transform.rotation, debugCanvas);
		instance.GetComponent<TextMeshPro>().text = damage.ToString("F0");
	}


}
