using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Chessman : MonoBehaviour {
	public int CurrentX {set; get;}
	public int CurrentZ {set; get;}
	public bool isWhite;
	public bool HasMoved = false;

	public void SetPosition(int x, int z) {
		CurrentX = x;
		CurrentZ = z;
	}

	public virtual bool[,] PossibleMoves() {
		return new bool[8, 8];
	}
}
