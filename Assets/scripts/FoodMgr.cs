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
		Vector3 position = new Vector3(Random.Range(-8.75f, 8.69f), Random.Range(-4.07f, 6.02f), 0);

		int overlapCounter = 0;
		if (position == Snake.inst.CurrentSnakePosition) {
			overlapCounter += 1;
		}
		for (int i = 0; i < ChunkManager.inst.AllChunks.Count; i++) {
			if (position == ChunkManager.inst.AllChunks [i].CurrentChunkPosition) {
				overlapCounter += 1;
			}
		}

		while (overlapCounter > 0) {
			position = new Vector3(Random.Range(-8.75f, 8.69f), Random.Range(-4.07f, 6.02f), 0);
			overlapCounter = 0;
			if (position == Snake.inst.CurrentSnakePosition) {
				overlapCounter += 1;
			}
			for (int i = 0; i < ChunkManager.inst.AllChunks.Count; i++) {
				if (position == ChunkManager.inst.AllChunks [i].CurrentChunkPosition) {
					overlapCounter += 1;
				}
			}
		}
		food.transform.position = position;
	}
}
