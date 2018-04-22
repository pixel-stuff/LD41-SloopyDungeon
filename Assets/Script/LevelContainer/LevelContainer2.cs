using UnityEngine;
using System.Collections.Generic;

public class LevelContainer2 : MonoBehaviour {

  //UNITY VAR
  [Header("Anchor")]
  [SerializeField] float yRotationLock = 25.0f;
  [SerializeField] float maxRotation = 30.0f;

  // VAR
  Dictionary<InputDirection,Vector3> rotationOrientation;
  Vector3 rotationTemp;
  Vector3 currentAnglesToApply;

	/// <summary>
  /// Start this instance.
  /// </summary>
  void Start () {
    rotationOrientation = new Dictionary<InputDirection, Vector3>();
    rotationOrientation.Add(InputDirection.UP,new Vector3(1.0f,0.0f,0.0f));
    rotationOrientation.Add(InputDirection.DOWN,new Vector3(-1.0f,0.0f,0.0f));
    rotationOrientation.Add(InputDirection.LEFT,new Vector3(0.0f,0.0f,1.0f));
    rotationOrientation.Add(InputDirection.RIGHT,new Vector3(0.0f,0.0f,-1.0f));

    currentAnglesToApply = Vector3.zero;

    InputManager.m_instance.onKeyBoardInputMaintain += handleInputMaintain;
    InputManager.m_instance.onKeyBoardInputEnter += handleInputEnter;
	}

  /// <summary>
  /// Handles the input that are held pressed.
  /// </summary>
  void handleInputEnter(InputDirection _direction){
    AddAnglesToApply(rotationOrientation[_direction]*0.8f);

   }
	
  /// <summary>
  /// Handles the input that are held pressed.
  /// </summary>
  void handleInputMaintain(InputDirection _direction){
    AddAnglesToApply(rotationOrientation[_direction]*0.5f);
  }

  void AddAnglesToApply(Vector3 _toAdd){
    currentAnglesToApply += _toAdd;
  }

  /// <summary>
  /// Update this instance.
  /// </summary>
  void Update() {
    rotationTemp = transform.eulerAngles;

    rotationTemp += currentAnglesToApply;

    currentAnglesToApply /= 1.50f;


    UpdateControleAngles();

    rotationTemp.y = yRotationLock;
    transform.eulerAngles = rotationTemp;
  }

  void UpdateControleAngles(){
    //block X rotation if needed
    if(rotationTemp.x > 180 && rotationTemp.x < (360 - maxRotation)){
      currentAnglesToApply.x = 0.0f;
      rotationTemp.x = -maxRotation;
    }else if(rotationTemp.x > maxRotation && rotationTemp.x <= 180){
      currentAnglesToApply.x = 0.0f;
      rotationTemp.x = maxRotation;
    }

    //block z rotation if needed
    if(rotationTemp.z > 180 && rotationTemp.z < (360 - maxRotation)){
      currentAnglesToApply.z = 0.0f;
      rotationTemp.z = -maxRotation;
    }else if(rotationTemp.z > maxRotation && rotationTemp.z <= 180){
      currentAnglesToApply.z = 0.0f;
      rotationTemp.z = maxRotation;
    }

    if(Mathf.Abs(currentAnglesToApply.x) < Mathf.Epsilon && Mathf.Abs(currentAnglesToApply.z) < Mathf.Epsilon){
      currentAnglesToApply = Vector3.zero;
    }
  }

  public void resetLevel(){
    currentAnglesToApply = Vector3.zero;
    transform.eulerAngles = Vector3.zero;
  }

  /// <summary>
  /// Ons the destroy.
  /// </summary>
  void OnDestroy() {
    InputManager.m_instance.onKeyBoardInputMaintain -= handleInputMaintain;
    InputManager.m_instance.onKeyBoardInputEnter -= handleInputEnter;
  }
}
