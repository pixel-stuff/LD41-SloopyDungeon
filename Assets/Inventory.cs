using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour {

	[SerializeField] UnityEvent OnTakingTheSword;
	[SerializeField] UnityEvent OnLoosingASword;

	public int SwordCount = 0;

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Sword") {
			Debug.Log (this.gameObject.name + "TOUCH the Sword");
			other.gameObject.SetActive (false);
			SwordCount++;
			OnTakingTheSword.Invoke ();
		}
	}

	public void LostSword(){
		SwordCount--;
		OnLoosingASword.Invoke ();
	}

	public bool HaveSword(){
		return SwordCount > 0;
	}
}
