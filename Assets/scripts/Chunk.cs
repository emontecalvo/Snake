using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour {

	public Vector3 SecondToLastPosition;

	bool AmILast = false;

	void Start() {
		ChunkManager.inst.Register (this);

		if (ChunkManager.inst.AllChunks.Count == 1) {
			AmILast = true;
			Vector3 temp = Snake.inst.transform.position;
			temp.y += 0.5f;
			temp.x += 0.5f;
			transform.position = temp;
		} else {
			Debug.Log ("yo");
		}
	}

	void Update () {
		ChunkMovement ();
	}

	void ChunkMovement() {
		transform.position = Snake.inst.LastSnakePosition;
	}
}
