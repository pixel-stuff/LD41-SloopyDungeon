using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]
public class LevelContainer : MonoBehaviour {

  //UNITY VAR
  [SerializeField] Transform upAnchor;
  [SerializeField] Transform downAnchor;
  [SerializeField] Transform leftAnchor;
  [SerializeField] Transform rightAnchor;

  // VAR
  Dictionary<InputDirection,Vector3> anchorPositions;

	/// <summary>
  /// Start this instance.
  /// </summary>
	void Start () {
    anchorPositions = new Dictionary<InputDirection, Vector3>();
    anchorPositions.Add(InputDirection.UP,upAnchor.position);
    anchorPositions.Add(InputDirection.DOWN,downAnchor.position);
    anchorPositions.Add(InputDirection.LEFT,leftAnchor.position);
    anchorPositions.Add(InputDirection.RIGHT,rightAnchor.position);

    InputManager.m_instance.onKeyBoardInputMaintain += handleInputMaintain;
    InputManager.m_instance.onKeyBoardInputEnter += handleInputEnter;

	}

  /// <summary>
  /// Handles the input that are held pressed.
  /// </summary>
  void handleInputEnter(InputDirection _direction){
    GetComponent<Rigidbody>().AddForceAtPosition(Vector3.up*4.0f,anchorPositions[_direction],ForceMode.Impulse);
  }
	
  /// <summary>
  /// Handles the input that are held pressed.
  /// </summary>
  void handleInputMaintain(InputDirection _direction){
    GetComponent<Rigidbody>().AddForceAtPosition(Vector3.up*2.0f,anchorPositions[_direction],ForceMode.Impulse);
  }

  /// <summary>
  /// Update this instance.
  /// </summary>
  //void Update() {
    
  //}

  /// <summary>
  /// Ons the destroy.
  /// </summary>
  void OnDestroy() {
    InputManager.m_instance.onKeyBoardInputMaintain -= handleInputMaintain;
    InputManager.m_instance.onKeyBoardInputEnter -= handleInputEnter;
  }
}
