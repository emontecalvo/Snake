using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Snake : MonoBehaviour {

	private static Snake _inst = null;

	public static Snake inst {
		get {
			if (_inst == null) {
				_inst = FindObjectOfType<Snake> ();
			}
			return _inst;
		}
	}


	public KeyCode LeftKey;
	public KeyCode RightKey;
	public KeyCode UpKey;
	public KeyCode DownKey;

	public GameObject ChunkPrefab;

	bool IsPaused = false;

	float PauseTime = 2.0f;

	string WhatDirection = "up";

	Vector3 LastPosition;


	void Update() {
		InputLogic ();
	
		if (IsPaused) {
			PauseTime -= 0.2f;
			if (PauseTime <= 0) {
				IsPaused = false;
			}
		} else {
			MovementLogic ();
			AnythingToEat ();
			PauseTime = 2.0f;
		}

	}

	void InputLogic () {

		if (Input.GetKeyDown (LeftKey)) {
			WhatDirection = "left";
		}

		if (Input.GetKeyDown (RightKey)) {
			WhatDirection = "right";
		}

		if (Input.GetKeyDown (UpKey)) {
			WhatDirection = "up";
		}

		if (Input.GetKeyDown (DownKey)) {
			WhatDirection = "down";
		}
	}

	void MovementLogic() {
		Vector3 speed = Vector3.zero;

		if (WhatDirection == "left") {
			speed.x = -0.5f;
			IsPaused = true;
		} else if (WhatDirection == "right") {
			speed.x = 0.5f;
			IsPaused = true;
		} else if (WhatDirection == "up") {
			speed.y = 0.5f;
			IsPaused = true;
		} else {
			speed.y = -0.5f;
			IsPaused = true;
		}

		transform.position = transform.position + speed;
	}

	void AnythingToEat() {
		foreach (Food food in FoodMgr.inst.AllFood) {
			Vector3 toFood = food.transform.position - transform.position;
			float distance = toFood.magnitude;
			if (distance <= 0.5f) {
				Debug.Log ("IT'S FOOD");
				GameObject chunk = (GameObject)Instantiate (ChunkPrefab);

				Vector3 temp = transform.position;
				temp.y += 1.0f;
				temp.x += 1.0f;
				chunk.transform.position = temp;
				transform.position = temp;
			}
		}
	}

//	void FollowTheChunks() {
//		if (IsLast) {
//			Vector3 subSpot = LastPosition;
//
//			if (WhatDirection == "up") {
//				subSpot.y = LastPosition.y - 0.5f;		
//			} else if (WhatDirection == "down") {
//				subSpot.y = LastPosition.y + 0.5f;
//			} else if (WhatDirection == "left") {
//				subSpot.x = LastPosition.x + 0.5f;
//			} else if (WhatDirection == "right") {
//				subSpot.x = LastPosition.x - 0.5f;		
//			}
//			LastPosition = transform.position;
//		}
//
//	}

	void MakeANewChunk() {

	}

}
