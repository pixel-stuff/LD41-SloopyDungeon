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

  // EVENT
  public event Action<InputDirection> onKeyBoardInputEnter;
  public event Action<InputDirection> onKeyBoardInputMaintain;
  public event Action<Vector3> onMouseClickStart;

  // VAR
  bool isMouseClicking;

  /// <summary>
  /// Start this instance.
  /// </summary>
  void Start() {
  }

  /// <summary>
  /// Update this instance.
  /// </summary>
  void Update() {
    switch (GameStateManager.getGameState()) {
      case GameState.Menu:
        UpdateBoardMenuState();
        break;
      case GameState.Pause:
        UpdateBoardPauseState();
        break;
      case GameState.Playing:
        UpdateKeyBoardPlayingState();
        if (Input.mousePresent) {
          UpdateMousePlayingState();
        }
        break;
      case GameState.GameOver:
        UpdateBoardGameOverState();
        break;
    }
  }

  /// <summary>
  /// get input from keyboard when the Game state is playing
  /// </summary>
  void UpdateKeyBoardPlayingState() {
    // switcher pause/playing state
    if (Input.GetKeyDown(KeyCode.P)) {
      GameStateManager.setGameState(GameState.Pause);
    }

    // Detecte Input Enter
    if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {
      if (onKeyBoardInputEnter != null) {
        onKeyBoardInputEnter.Invoke(InputDirection.UP);
      }
    }

    if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
      if (onKeyBoardInputEnter != null) {
        onKeyBoardInputEnter.Invoke(InputDirection.LEFT);
      }
    }

    if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) {
      if (onKeyBoardInputEnter != null) {
        onKeyBoardInputEnter.Invoke(InputDirection.DOWN);
      }
    }

    if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
      if (onKeyBoardInputEnter != null) {
        onKeyBoardInputEnter.Invoke(InputDirection.RIGHT);
      }
    }



    // Detecte Input Maintain
    if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
      if (onKeyBoardInputMaintain != null) {
        onKeyBoardInputMaintain.Invoke(InputDirection.UP);
      }
    }

    if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
      if (onKeyBoardInputMaintain != null) {
        onKeyBoardInputMaintain.Invoke(InputDirection.LEFT);
      }
    }

    if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
      if (onKeyBoardInputMaintain != null) {
        onKeyBoardInputMaintain.Invoke(InputDirection.DOWN);
      }
    }

    if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
      if (onKeyBoardInputMaintain != null) {
        onKeyBoardInputMaintain.Invoke(InputDirection.RIGHT);
      }
    }
  }

  /// <summary>
  /// get input for mouse when the Game state is playing
  /// </summary>
  void UpdateMousePlayingState() {
    if (Input.GetMouseButtonDown(0)) {
      isMouseClicking = true;
      if (onMouseClickStart != null) {
        onMouseClickStart(Input.mousePosition);
      }
    }

    //if(isMouseClicking && Input.GetM)


  }

  /// <summary>
  /// get input from keyboard when the Game state is in a menu
  /// </summary>
  void UpdateBoardMenuState() {
    if (Input.GetKeyDown(KeyCode.Return)) {
      GameStateManager.setGameState(GameState.Playing);
      SceneManager.LoadSceneAsync("LevelScene");
    }
  }

  /// <summary>
  /// get input from keyboard when the Game state is pause.
  /// </summary>
  void UpdateBoardPauseState() {
    if (Input.GetKeyDown(KeyCode.P)) {
      GameStateManager.setGameState(GameState.Playing);
    }
  }

  /// <summary>
  /// get input from keyboard when the Game state is game over.
  /// </summary>
  void UpdateBoardGameOverState() {

  }

}
