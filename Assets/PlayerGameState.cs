using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGameState : MonoBehaviour {

	public void ResetCurrentLevel(){
		Application.LoadLevel(Application.loadedLevel);
	}

	public void GotoNextLevel(){
		Application.LoadLevel(Application.loadedLevel);
	}
}
