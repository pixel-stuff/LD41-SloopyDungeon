using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : TypedObject {

	public override MyType GetType()
	{
		return MyType.Player;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision with Player");
    }


}
