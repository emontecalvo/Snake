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
}
