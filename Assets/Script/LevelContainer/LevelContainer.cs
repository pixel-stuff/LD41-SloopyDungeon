using UnityEngine;
using System.Collections.Generic;
using System.Linq;

[RequireComponent(typeof(Rigidbody))]
public class LevelContainer : MonoBehaviour {

  //UNITY VAR
  [Header("Anchor")]
  [SerializeField] Transform upAnchor;
  [SerializeField] Transform downAnchor;
  [SerializeField] Transform leftAnchor;
  [SerializeField] Transform rightAnchor;

  [Header("Anchor")]
  [SerializeField] float yRotationLock = 25.0f;
  [SerializeField] float maxRotation = 30.0f;

  // VAR
  Dictionary<InputDirection,Vector3> anchorPositions;
  Vector3 rotationTemp;

	/// <summary>
  /// Start this instance.
  /// </summary>
	void Start () {
    anchorPositions = new Dictionary<InputDirection, Vector3>();
    anchorPositions.Add(InputDirection.UP,downAnchor.position);
    anchorPositions.Add(InputDirection.DOWN,upAnchor.position);
    anchorPositions.Add(InputDirection.LEFT,rightAnchor.position);
    anchorPositions.Add(InputDirection.RIGHT,leftAnchor.position);

    InputManager.m_instance.onKeyBoardInputMaintain += handleInputMaintain;
    InputManager.m_instance.onKeyBoardInputEnter += handleInputEnter;

	}

  /// <summary>
  /// Handles the input that are held pressed.
  /// </summary>
  void handleInputEnter(InputDirection _direction){
    var normal = transform.TransformDirection(GetComponent<MeshFilter>().mesh.normals[0]);
    GetComponent<Rigidbody>().AddForceAtPosition(normal*7.0f,anchorPositions[_direction],ForceMode.Impulse);
  }
	
  /// <summary>
  /// Handles the input that are held pressed.
  /// </summary>
  void handleInputMaintain(InputDirection _direction){
    var normal = transform.TransformDirection(GetComponent<MeshFilter>().mesh.normals[0]);
    GetComponent<Rigidbody>().AddForceAtPosition(normal*2.0f,anchorPositions[_direction],ForceMode.Impulse);
  }

  /// <summary>
  /// Update this instance.
  /// </summary>
  void Update() {
    rotationTemp = transform.eulerAngles;

    //block Y rotation
    rotationTemp.y = yRotationLock;

    //block X rotation if needed
    if(rotationTemp.x > 180 && rotationTemp.x < (360 - maxRotation)){
      rotationTemp.x = -maxRotation;
    }else if(rotationTemp.x > maxRotation && rotationTemp.x <= 180){
      rotationTemp.x = maxRotation;
    }

    //block z rotation if needed
    if(rotationTemp.z > 180 && rotationTemp.z < (360 - maxRotation)){
      rotationTemp.z = -maxRotation;
    }else if(rotationTemp.z > maxRotation && rotationTemp.z <= 180){
      rotationTemp.z = maxRotation;
    }

    transform.eulerAngles = rotationTemp;
    transform.localPosition = Vector3.zero;
  }

  /// <summary>
  /// Ons the destroy.
  /// </summary>
  void OnDestroy() {
    InputManager.m_instance.onKeyBoardInputMaintain -= handleInputMaintain;
    InputManager.m_instance.onKeyBoardInputEnter -= handleInputEnter;
  }
}
