using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateView : MonoBehaviour {
	bool isStandard = true;

	void Update() {
		RotateCamera();
	}

	private void RotateCamera() {
		if (BoardManager.Instance.isWhiteTurn != isStandard) {
			transform.RotateAround(transform.position, Vector3.up, 180);

			isStandard = !isStandard;
		}
		
	}
}
