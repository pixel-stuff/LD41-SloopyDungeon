using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public enum InputDirection {
  UP,
  DOWN,
  LEFT,
  RIGHT
}

public class InputManager : MonoBehaviour {

  #region Singleton
  public static InputManager m_instance;
  void Awake() {
    if (m_instance == null) {
      //If I am the first instance, make me the Singleton
      m_instance = this;
      DontDestroyOnLoad(this.gameObject);
    } else {
      //If a Singleton already exists and you find
      //another reference in scene, destroy it!
      if (this != m_instance)
        Destroy(this.gameObject);
    }
  }
  #endregion Singleton

  public event Action<InputDirection> onInputEnter;
  public event Action<InputDirection> onInputMaintain;

  // Use this for initialization
  void Start() {
  }

  // Update is called once per frame
  void Update() {
    switch (GameStateManager.getGameState()) {
      case GameState.Menu:
        UpdateMenuState();
        break;
      case GameState.Pause:
      case GameState.Playing:
        UpdatePlayingState();
        break;
        //case GameState.Pause:
        // Do nothing
        //UpdatePauseState();
        break;
      case GameState.GameOver:
        UpdateGameOverState();
        break;
    }
  }

  void UpdateMenuState() {
    if (Input.GetKeyDown(KeyCode.Return)) {
      GameStateManager.setGameState(GameState.Playing);
      SceneManager.LoadSceneAsync("LevelScene");
    }
  }

  void UpdatePlayingState() {
    // switcher pause/playing state
    if (Input.GetKeyDown(KeyCode.P)) {
      switch (GameStateManager.getGameState()) {
        case GameState.Playing:
          GameStateManager.setGameState(GameState.Pause);
          break;
        case GameState.Pause:
        default:
          GameStateManager.setGameState(GameState.Playing);
          break;
      }
    }

    // Detecte Input Enter
    if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.W)) {
      if (onInputEnter != null) {
        onInputEnter.Invoke(InputDirection.UP);
      }
    }

    if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.A)) {
      if (onInputEnter != null) {
        onInputEnter.Invoke(InputDirection.LEFT);
      }
    }

    if (Input.GetKeyDown(KeyCode.S)) {
      if (onInputEnter != null) {
        onInputEnter.Invoke(InputDirection.DOWN);
      }
    }

    if (Input.GetKeyDown(KeyCode.D)) {
      if (onInputEnter != null) {
        onInputEnter.Invoke(InputDirection.RIGHT);
      }
    }



    // Detecte Input Maintain
    if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.W)) {
      if (onInputMaintain != null) {
        onInputMaintain.Invoke(InputDirection.UP);
      }
    }

    if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.A)) {
      if (onInputMaintain != null) {
        onInputMaintain.Invoke(InputDirection.LEFT);
      }
    }

    if (Input.GetKey(KeyCode.S)) {
      if (onInputMaintain != null) {
        onInputMaintain.Invoke(InputDirection.DOWN);
      }
    }

    if (Input.GetKey(KeyCode.D)) {
      if (onInputMaintain != null) {
        onInputMaintain.Invoke(InputDirection.RIGHT);
      }
    }
  }

  void UpdatePauseState() {
    if (Input.GetKeyDown(KeyCode.P)) {
      GameStateManager.setGameState(GameState.Playing);
    }
  }

  void UpdateGameOverState() {

  }

}
