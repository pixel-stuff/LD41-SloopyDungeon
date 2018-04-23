using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

  // UNITY VAR
  [SerializeField] List<string> levelScene;

  // VAR
  int currentIndexScene = 0;

  #region Singleton
  public static LevelManager m_instance;
  void Awake(){
    if(m_instance == null){
      //If I am the first instance, make me the Singleton
      m_instance = this;
      DontDestroyOnLoad(gameObject);
    }else{
      //If a Singleton already exists and you find
      //another reference in scene, destroy it!
      if(this != m_instance)
        Destroy(this.gameObject);
    }
  }
  #endregion Singleton

  public void LoadNextScene(){
    currentIndexScene++;
		Debug.Log ("LoadScene " + currentIndexScene + "  " + levelScene [currentIndexScene]);
    if(currentIndexScene > levelScene.Count){
      SceneManager.LoadScene("MenuScene");
    }else{
      SceneManager.LoadScene(levelScene[currentIndexScene]);
    }
  }

  public void ReloadCurrentScene(){
    SceneManager.LoadScene(levelScene[currentIndexScene]);
  }
}
