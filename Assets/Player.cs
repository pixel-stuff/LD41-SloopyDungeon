using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : TypedObject {

  [SerializeField] UnityEvent OnSwordUse;
  [SerializeField] UnityEvent OnPlayerBeingHit;
	[SerializeField] UnityEvent OnDoorTouch;

	public override MyType GetType()
	{
		return MyType.Player;
	}
		

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Monster") {
			Debug.Log (this.gameObject.name + "TOUCH the Monster");
      if (this.gameObject.GetComponent<Inventory> ().HaveSword()) {
        OnSwordUse.Invoke ();
				if (other.GetComponent<Life> ()) {
					other.GetComponent<Life> ().TakeDommage (1);
					//this.gameObject.GetComponent<Inventory> ().LostSword ();
				}
      } else {
        OnPlayerBeingHit.Invoke ();
				if (other.GetComponent<Life> ()) {
					this.GetComponent<Life> ().TakeDommage (1);
				}
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
