using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : TypedObject {

	[SerializeField] UnityEvent OnMonsterTouch;
	[SerializeField] UnityEvent OnDoorTouch;

	public override MyType GetType()
	{
		return MyType.Player;
	}
		

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Monster") {
			Debug.Log (this.gameObject.name + "TOUCH the Monster");
			OnMonsterTouch.Invoke ();
			if (this.gameObject.GetComponent<Inventory> ().HaveSword()) {
				other.GetComponent<Life> ().TakeDommage (1);
				this.gameObject.GetComponent<Inventory> ().LostSword ();
			} else {
				this.GetComponent<Life> ().TakeDommage (1);
			}
			this.gameObject.GetComponent<Rigidbody> ().AddForce (other.GetComponent<Monster>().Reflect(this.transform.position));
		}

		if (other.gameObject.tag == "Door") {
			Debug.Log (this.gameObject.name + "TOUCH the Door");
			OnDoorTouch.Invoke ();
			this.GetComponent<PlayerGameState> ().GotoNextLevel ();
		}
	}


}
