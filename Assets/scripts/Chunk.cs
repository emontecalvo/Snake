using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour {

	public Vector3 CurrentChunkPosition;
	public Vector3 LastChunkPosition;

	bool AmILast = false;

	void Start() {
		ChunkManager.inst.Register (this);

		transform.position = Snake.inst.LastSnakePosition;

	}

	void Update () {

	}

}
