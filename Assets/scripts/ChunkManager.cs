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

	public List <Snake> AllChunks = new List<Snake> ();

	public void Register (Snake snake) {

		AllChunks.Add (snake);

	}
}
