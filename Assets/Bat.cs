using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour {

	public GameObject Cave;
	private float speedVariationMax= 1.1f;
	private float speedVariationMin= 0.8f;

	public Vector3 BatSpeed;

	// Use this for initialization
	void Start () {

	}

	
	// Update is called once per frame
	void Update () {
		this.transform.localPosition = this.transform.localPosition + BatSpeed* Time.deltaTime * Random.Range(speedVariationMin,speedVariationMax);
	}
}
