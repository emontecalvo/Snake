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

	float PauseTime = 1.0f;

	string WhatDirection = "up";


	
	void Update() {
		
		if (IsPaused) {
			PauseTime -= 0.2f;
			if (PauseTime <= 0) {
				IsPaused = false;
			}
		} else {
			MovementLogic ();
			KeepMoving ();
			PauseTime = 1.0f;
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
			speed.x = -600;
			IsPaused = true;
		} else if (WhatDirection == "right") {
			speed.x = 600;
			IsPaused = true;
		} else if (WhatDirection == "up") {
			speed.y = 600;
			IsPaused = true;
		} else {
			speed.y = -600;
			IsPaused = true;
		}

		transform.position = transform.position + speed * Time.deltaTime;
	}






}
