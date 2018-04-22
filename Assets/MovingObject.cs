using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovingObject : MonoBehaviour {

	public float MovingEpsilon = 0.001f;

	[SerializeField] UnityEvent OnMoveLeft;
	[SerializeField] UnityEvent OnMoveRight;
	[SerializeField] UnityEvent OnStopMoving;
	[SerializeField] UnityEvent OnMoveUp;
	[SerializeField] UnityEvent OnMoveDown;

	private Vector3 lastPosition;
	// Use this for initialization
	void Start () {
		lastPosition = this.transform.localPosition;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 SpeedVector = this.transform.localPosition - lastPosition;
		float xStrength = Mathf.Abs (SpeedVector.x);
		float zStrength = Mathf.Abs (SpeedVector.z);
		if (xStrength + zStrength > MovingEpsilon) {
			if (xStrength >= zStrength) {
				if (SpeedVector.x > 0) {
					OnMoveRight.Invoke ();
				} else {
					OnMoveLeft.Invoke ();
				}
			} else {
				if (SpeedVector.z > 0) {
					OnMoveUp.Invoke ();
				} else {
					OnMoveDown.Invoke ();
				}
			}
		} else {
			OnStopMoving.Invoke ();
		}
		lastPosition = this.transform.localPosition;
	}

}
