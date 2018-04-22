using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorHelper : MonoBehaviour {


	public void SetDead(){
		GetComponent<Animator> ().SetBool ("Dead", true);
	}
}
