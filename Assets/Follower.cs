using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour {

	public GameObject Target;
	public float offsetY;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = Target.transform.position + new Vector3(0.0f,offsetY,0.0f);

	}
}
