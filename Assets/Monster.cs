using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {

	public float ReflectAmplitude = 10;

	public Vector3 Reflect(Vector3 targetPosition){
		if (this.gameObject.GetComponent<Life> ().IsDead()) {
			return Vector3.zero;
		}
		return ((targetPosition - this.transform.position).normalized)*ReflectAmplitude;
	}
}
