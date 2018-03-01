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

//		if (ChunkManager.inst.AllChunks.Count == 1) {
//			AmILast = true;
//			Vector3 temp = Snake.inst.transform.position;
//			temp.y += 0.5f;
//			temp.x += 0.5f;
//			transform.position = temp;
//			CurrentChunkPosition = transform.position;
//		}
//		} else {
//			foreach (Chunk chunk in ChunkManager.inst.AllChunks) {
//				if (chunk.AmILast = true) {
//					chunk.AmILast = false;
//					AmILast = true;
//					Vector3 temp2 = chunk.transform.position;
//					temp2.y += 0.5f;
//					temp2.x += 0.5f;
//					transform.position = temp2;
//					CurrentChunkPosition = transform.position;
//				}
//			}
//		}
	}

	void Update () {
	//	ChunkBigUpdate ();
	}

	void ChunkBigUpdate() {
	//	LastChunkPosition = CurrentChunkPosition;
		ChunkMovement ();
	//	CurrentChunkPosition = transform.position;
	}

	void ChunkMovement() {
////		int counterCurrent = 1;
//		int counterLast = 0;
////		Chunk currentSubChunk = ChunkManager.inst.AllChunks [counterCurrent];
//		Chunk lastSubChunk = ChunkManager.inst.AllChunks [counterLast];
//		foreach (Chunk chunk in ChunkManager.inst.AllChunks) {
//			if (ChunkManager.inst.AllChunks[0] == chunk) {
//				chunk.transform.position = Snake.inst.LastSnakePosition;
//				chunk.LastChunkPosition = chunk.CurrentChunkPosition;
//				chunk.CurrentChunkPosition = transform.position;
//			} else {
//
//				chunk.transform.position = lastSubChunk.LastChunkPosition;
//				Debug.Log ("CURRENT CHUNK POS:  " + lastSubChunk.CurrentChunkPosition);
//				Debug.Log ("last CHUNK POS:  " + lastSubChunk.LastChunkPosition);
//				chunk.LastChunkPosition = chunk.CurrentChunkPosition;
//				chunk.CurrentChunkPosition = transform.position;
//				counterLast += 1;
//			}
//
//		}

	}
}
