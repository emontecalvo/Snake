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

	public GameObject FoodPrefab;

	public List <Food> AllFood = new List<Food> ();

	public void Register (Food food) {

		AllFood.Add (food);

	}

	public void Unregister (Food food) {
		AllFood.Remove (food);
		MakeNewFood ();
	}

	void MakeNewFood() {
		GameObject food = (GameObject)Instantiate (FoodPrefab);
		Vector3 position = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f), 0);
		food.transform.position = position;

	}
}
