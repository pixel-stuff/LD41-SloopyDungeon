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


	bool Right = false;
	bool Left = false;
	bool Up = false;
	bool Down = false;
	bool NotMove = false;

	void ClearFlag(){
		 Right = false;
		 Left = false;
		 Up = false;
		 Down = false;
		 NotMove = false;
	}

	private Vector3 lastPosition;
	// Use this for initialization
	void Start () {
		lastPosition = this.transform.localPosition;
	}
	
	// Update is called once per frame
	void Update() {
		Vector3 SpeedVector = this.transform.localPosition - lastPosition;
		if (SpeedVector == Vector3.zero) {
			return;
		}
		float xStrength = Mathf.Abs (SpeedVector.x);
		float zStrength = Mathf.Abs (SpeedVector.z);
		if (xStrength + zStrength > MovingEpsilon) {
			if (xStrength >= zStrength) {
				if (SpeedVector.x > 0) {
					if (!Right) {
						ClearFlag ();
						Right = true;
						OnMoveRight.Invoke ();
					}
				} else {
					if (!Left) {
						ClearFlag ();
						Left = true;
						OnMoveLeft.Invoke ();
					}
				}
			} else {
				if (SpeedVector.z > 0) {
					if (!Up) {
						ClearFlag ();
						Up = true;
						OnMoveUp.Invoke ();
					}
				} else {
					if (!Down) {
						ClearFlag ();
						Down = true;
						OnMoveDown.Invoke ();
					}
				}
			}
		} else {
			if (!NotMove) {
				ClearFlag ();
				NotMove = true;
				OnStopMoving.Invoke ();
			}
		}
		lastPosition = this.transform.localPosition;
	}

}
