using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGameState : MonoBehaviour {

  bool hasAlreadyBeenTriggered = false;

  public void ResetCurrentLevel() {
    LevelManager.m_instance.ReloadCurrentScene();
  }

  public void GotoNextLevel() {
    if (!hasAlreadyBeenTriggered) {
      hasAlreadyBeenTriggered = true;
      StartCoroutine(changeWorld());
    }
  }

  IEnumerator changeWorld() {
    yield return new WaitForSeconds(4);
    //Debug.Log("ChangeWorld");
    LevelManager.m_instance.LoadNextScene();
  }
}
