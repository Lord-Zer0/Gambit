using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Chessman : MonoBehaviour {
	public int CurrentX { set; get;}
	public int CurrentZ { set; get;}
	public bool isWhite;

	public void SetPosition(int x, int z) {
		CurrentX = x;
		CurrentZ = z;
	}

	public virtual bool PossibleMove(int x, int z) {
		return true;
	}
}
