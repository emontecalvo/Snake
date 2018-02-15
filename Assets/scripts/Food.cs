using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour {


	
	void Start() {
		FoodMgr.inst.Register (this);
	}

	void Update () {
		
	}


}
