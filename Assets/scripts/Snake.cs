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

	public Vector3 CurrentSnakePosition;
	public Vector3 LastSnakePosition;

	void Start() {
		CurrentSnakePosition = transform.position;
	}


	void Update() {
		InputLogic ();

		if (IsPaused) {
			PauseTime -= 0.2f;
			if (PauseTime <= 0) {
				IsPaused = false;
			}
		} else {
			PauseTime = 2.0f;
			BigUpdate ();
			ChunkManager.inst.AreChunksTouching (transform.position);
			ChunkManager.inst.MoveTheChunks ();
		}
	}

	void BigUpdate() {
		// set last position
		LastSnakePosition = CurrentSnakePosition;
		MovementLogic ();
		// set current position
		CurrentSnakePosition = transform.position;
		AnythingToEat ();

		// proper log statement:   (varArgs in C++)
		// function that takes a variable number of arguments (C# params)
		// 1st argument = string, some variable # of other arguments after that
		// Time.frameCount = integer representing which frame it is
		// Time.time = time since you pushed play (seconds since game started)
		// Time.deltaTime = seconds since the last update
//		Debug.LogFormat("BigUpdate: {0}, time: {1}, deltaTime: {2} ", Time.frameCount, Time.time, Time.deltaTime);
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
				GameObject chunk = (GameObject)Instantiate (ChunkPrefab);
				food.FoodEaten ();
			}
		}
	}


}
