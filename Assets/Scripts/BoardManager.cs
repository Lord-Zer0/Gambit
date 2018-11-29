using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour {
	private const float TILE_SIZE = 1.0f;
	private const float TILE_OFFSET = 0.5f;
	private int selectAlpha;
	private int selectNum;

	private Vector3 offsetFix = new Vector3(-0.5f, 0f, -0.5f);

	private void Update() {
		DrawChessBoard();
	}

	private void DrawChessBoard() {
		Vector3 widthLine = Vector3.right * 8;
		//widthLine 
		Vector3 heightLine = Vector3.forward * 8;
		//heightLine += offsetFix;

		for (int i = 0; i <= 8; i++) {
			Vector3 start = (Vector3.forward * i) + offsetFix;
			Debug.DrawLine(start, start + widthLine);
			for (int j = 0; j <= 8; j++) {
				start = (Vector3.right * j) + offsetFix;
				Debug.DrawLine(start, start + heightLine);
			}
		}
	}
}
