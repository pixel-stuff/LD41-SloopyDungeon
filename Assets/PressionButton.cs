using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressionButton : MonoBehaviour {

	[SerializeField] UnityEvent OnActivateButton;
	[SerializeField] UnityEvent OnCoolDownOver;

	private float CooldownSec;
	private bool IsActivated = false;

	void Update () {
		if(IsActivated){
			CooldownSec -= Time.deltaTime;
			if (CooldownSec < 0) {
				OnCoolDownOver.Invoke ();
				IsActivated = false;
			}
		}
	}

	public void SetCooldown(float cooldown){
		CooldownSec = cooldown;
	}

	void OnTriggerEnter(Collider other){
		Debug.Log ("TouchTheButton");
		if (other.gameObject.tag == "player" || other.gameObject.tag == "HeavyObject") {
			if (!IsActivated) {
				OnActivateButton.Invoke ();
				IsActivated = true;
			}
		}
	}
}
