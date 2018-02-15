using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour {

	void Start() {
		ChunkManager.inst.Register (this);
	}

	void Update () {

	}
}
