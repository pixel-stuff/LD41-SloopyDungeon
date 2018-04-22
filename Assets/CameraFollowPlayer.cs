using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour {
  // UNITY VAR
  [SerializeField] Vector3 cameraPosition = new Vector3(-13.5f,6.4f,-0.5f);
  [SerializeField] Vector3 cameraLocal = new Vector3(40.0f,60.0f,0.0f);

  // VAR
  Transform playerTransfrom;
  Vector3 positionTemp;

	// Use this for initialization
	void Start () {
    playerTransfrom =  GameObject.FindGameObjectWithTag("player").transform;
	}
	
	// Update is called once per frame
	void Update () {
    positionTemp = transform.localPosition;

	}
}
