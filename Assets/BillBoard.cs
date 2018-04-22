using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//transform.LookAt (-Camera.main.transform.position, Vector3.up);
		this.transform.forward = Camera.main.transform.forward;
	}
}


