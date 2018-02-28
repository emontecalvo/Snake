using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour {


	
	void Start() {
		FoodMgr.inst.Register (this);
	}

	void Update () {
		
	}

	public void FoodEaten() {
		Destroy (gameObject);
	}

	void OnDestroy() {
		if (FoodMgr.inst != null) {
			FoodMgr.inst.Unregister (this);
		}
	}


}
