using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LizardHPManager : MonoBehaviour {

	public GameObject OneHP;
	public GameObject TwoHP;
	public GameObject ThreeHP;

	public int lifeCount = 0;

	public void OnTakeHit(){
		DisplayHP(--lifeCount);
	}
	public void OnHeal(){
		DisplayHP(++lifeCount);
	}

	public void DisplayHP(int currentHP){
		if (currentHP == 1) {
			OneHP.SetActive (true);
			TwoHP.SetActive (false);
			ThreeHP.SetActive (false);
		} else if (currentHP == 2) {
			OneHP.SetActive (false);
			TwoHP.SetActive (true);
			ThreeHP.SetActive (false);
		} else if (currentHP == 3) {
			OneHP.SetActive (false);
			TwoHP.SetActive (false);
			ThreeHP.SetActive (true);
		} else {
			OneHP.SetActive (false);
			TwoHP.SetActive (false);
			ThreeHP.SetActive (false);
		}
	}
}
