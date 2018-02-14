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

	bool IsPaused = false;

	public bool IsFood;

	float PauseTime = 2.0f;

	string WhatDirection = "up";




	void Start() {
		ChunkManager.inst.Register (this);
	}
	
	void Update() {

		if (!IsFood) {
			if (IsPaused) {
				PauseTime -= 0.2f;
				if (PauseTime <= 0) {
					IsPaused = false;
				}
			} else {
				MovementLogic ();
				KeepMoving ();
				AnythingToEat ();
				PauseTime = 2.0f;
			}
		}

	}

	void MovementLogic () {
		IsPaused = false;

		if (Input.GetKey (LeftKey) && !IsPaused) {
			WhatDirection = "left";
		}

		if (Input.GetKey (RightKey) && !IsPaused) {
			WhatDirection = "right";
		}

		if (Input.GetKey (UpKey) && !IsPaused) {
			WhatDirection = "up";
		}

		if (Input.GetKey (DownKey) && !IsPaused) {
			WhatDirection = "down";
		}
	}

	void KeepMoving() {
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
		foreach (Snake snake in ChunkManager.inst.AllChunks) {
			Vector3 toChunk = snake.transform.position - transform.position;
			float distance = toChunk.magnitude;
			if (snake != this) {
				if (distance <= 0.5f) {
					Debug.Log ("I AM HERE!");
				}			
			}

		}
	}




}
