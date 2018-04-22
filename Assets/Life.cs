using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Life : MonoBehaviour {

	[SerializeField] UnityEvent OnTakingNonLetalDmg;
	[SerializeField] UnityEvent OnTakingLetalDmg;
	[SerializeField] UnityEvent OnHeal;
	public int MaxLife = 3;
	public int CurrentLife;
	// Use this for initialization
	void Start () {
		Init();
	}

	public void Init(){
		CurrentLife = MaxLife;
		for (int i = 0; i < MaxLife; i++) {
			OnHeal.Invoke ();
		}
	}
		
	public void TakeDommage(int nbDommage){
		CurrentLife -= nbDommage;
		if(CurrentLife > 0){
			OnTakingNonLetalDmg.Invoke ();
		}else{
			OnTakingLetalDmg.Invoke ();
		}
	}

	public void Heal(int nbHeal){
		CurrentLife += nbHeal;
		if (CurrentLife > MaxLife) {
			CurrentLife = MaxLife;
		}
		OnHeal.Invoke ();
	}

	public bool IsDead(){
		return CurrentLife <= 0;
	}
}
