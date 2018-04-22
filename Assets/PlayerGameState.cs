using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGameState : MonoBehaviour {

	public void ResetCurrentLevel(){
		Application.LoadLevel(Application.loadedLevel);
	}

	public void GotoNextLevel(){
		StartCoroutine (changeWorld());

	}

	IEnumerator changeWorld(){
		yield return new WaitForSeconds(3.0f);
		Application.LoadLevel(Application.loadedLevel);
	}
}
