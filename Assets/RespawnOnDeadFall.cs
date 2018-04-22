using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RespawnOnDeadFall : MonoBehaviour {

	[SerializeField] UnityEvent OnTouchDeadFall;
	public GameObject RespawnGameObject;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (this.transform.position.y < -1000) {
			OnTouchDeadFall.Invoke ();
		}
	}

	public void RespawnOnTransform(){
		this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
		this.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
		this.transform.position = RespawnGameObject.transform.position;
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "DeadFall") {
			Debug.Log (this.gameObject.name + "TOUCH the deadFall");
			OnTouchDeadFall.Invoke ();
		}
	}
}
