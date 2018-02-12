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

	float LifeSpan = 1.0f;


	
	void Update() {
		
		if (IsPaused) {
			LifeSpan -= 0.2f;
			if (LifeSpan <= 0) {
				IsPaused = false;
			}
		} else {
			MovementLogic ();
			LifeSpan = 1.0f;
		}

	}


	void MovementLogic () {
		IsPaused = false;
		Vector3 speed = Vector3.zero;

		if (Input.GetKey (LeftKey) && !IsPaused) {
			speed.x = -600;
			IsPaused = true;
		}

		if (Input.GetKey (RightKey) && !IsPaused) {
			speed.x = 600;
			IsPaused = true;
		}

		if (Input.GetKey (UpKey) && !IsPaused) {
			speed.y = 600;
			IsPaused = true;
		}

		if (Input.GetKey (DownKey) && !IsPaused) {
			speed.y = -600;
			IsPaused = true;
		}

		transform.position = transform.position + speed * Time.deltaTime;
	}
}
