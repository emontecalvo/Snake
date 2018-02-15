using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodMgr : MonoBehaviour {

	private static FoodMgr _inst = null;

	public static FoodMgr inst {
		get {
			if (_inst == null) {
				_inst = FindObjectOfType<FoodMgr> ();
			}
			return _inst;
		}
	}

	public List <Food> AllFood = new List<Food> ();

	public void Register (Food food) {

		AllFood.Add (food);

	}
}
