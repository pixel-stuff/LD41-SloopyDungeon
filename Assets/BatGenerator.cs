﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatGenerator : MonoBehaviour {

	public GameObject BatPrefab;
	public int BatsCount = 10;
	public int CooldownSec = 10;


	public Vector3 BatSpeed;

	public float angleVariation = 20;
	public Vector3 PositionMultiplicator;

	public List<GameObject> CurrentsBats;

	public float TimeBetweenGeneration = 100000000;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < BatsCount; i++) {
			GameObject currentBat = Instantiate (BatPrefab);
			Bat currentBatScript = currentBat.GetComponent<Bat> ();
			currentBatScript.BatSpeed = BatSpeed;
			currentBat.transform.parent = this.gameObject.transform;
			CurrentsBats.Add (currentBat);
		}
	}
	
	// Update is called once per frame
	void Update () {
		TimeBetweenGeneration += Time.deltaTime;
		if (TimeBetweenGeneration > CooldownSec) {
			TimeBetweenGeneration = 0;
			foreach(GameObject bat in CurrentsBats){
				Vector3 random = Random.onUnitSphere;
				bat.transform.localPosition = new Vector3 (random.x* PositionMultiplicator.x,random.y* PositionMultiplicator.y,random.z* PositionMultiplicator.z);
				bat.transform.localEulerAngles = new Vector3 (0.0f, 90f + Random.Range (-angleVariation, angleVariation),0f);
			}
		}

	}
}
