using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGameState : MonoBehaviour {

	public void ResetCurrentLevel(){
    LevelManager.m_instance.ReloadCurrentScene();
	}

	public void GotoNextLevel(){
    LevelManager.m_instance.LoadNextScene();

	}

	IEnumerator changeWorld(){
		yield return new WaitForSeconds(3.0f);
		Application.LoadLevel(Application.loadedLevel);
	}
}
