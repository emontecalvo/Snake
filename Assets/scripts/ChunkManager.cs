using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkManager : MonoBehaviour {

	private static ChunkManager _inst = null;

	public static ChunkManager inst {
		get {
			if (_inst == null) {
				_inst = FindObjectOfType<ChunkManager> ();
			}
			return _inst;
		}
	}

	public List <Chunk> AllChunks = new List<Chunk> ();

	public void Register (Chunk chunk) {

		AllChunks.Add (chunk);

	}

	void Update() {

	}

	public void MoveTheChunks() {
		if (AllChunks.Count > 0) {

			for (int i = 0; i < AllChunks.Count; i++) {
				if (i == 0) {
					AllChunks [i].transform.position = Snake.inst.LastSnakePosition;
					AllChunks [i].LastChunkPosition = AllChunks [i].CurrentChunkPosition;
					AllChunks [i].CurrentChunkPosition = AllChunks[i].transform.position;
//					Debug.LogFormat ("**********   Frame Count: {0}, i : {1}, last chunk pos: {2}, current chunk pos {3}, transform pos: {4} ", 
//						Time.frameCount, i, AllChunks [i].LastChunkPosition, AllChunks [i].CurrentChunkPosition, AllChunks [i].transform.position);
				} else {
					Chunk lastSubChunk = AllChunks [i - 1];
					AllChunks[i].transform.position = lastSubChunk.LastChunkPosition;
					AllChunks[i].LastChunkPosition = AllChunks[i].CurrentChunkPosition;
					AllChunks[i].CurrentChunkPosition = AllChunks[i].transform.position;
//					Debug.LogFormat ("Frame Count: {0}, i : {1}, last chunk pos: {2}, current chunk pos {3}, transform pos: {4} ", 
//						Time.frameCount, i, AllChunks [i].LastChunkPosition, AllChunks [i].CurrentChunkPosition, AllChunks [i].transform.position);
				}
			}		
		}

	}


}
