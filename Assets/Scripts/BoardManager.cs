using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour {
	private const float TILE_SIZE = 1.0f;
	private const float TILE_OFFSET = 0.5f;
	private int selectAlpha;
	private int selectNum;
	public List<GameObject> unitPrefabs;
	public List<GameObject> activeUnits;

	private Vector3 offsetFix = new Vector3(-0.5f, 0f, -0.5f);

	private void Update() {
		UpdateSelection();
		DrawChessBoard();
	}

	private void UpdateSelection() {
		if (!Camera.main) {
			return;
		}

		RaycastHit hit;
		if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 25.0f, LayerMask.GetMask("BoardLevel"))) {
			selectAlpha = (int)hit.point.x;
			selectNum = (int)hit.point.z;
		} else {
			selectAlpha = -1;
			selectNum = -1;
		}
		print(selectAlpha + selectNum);
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

		// Draw Selection
		if (selectAlpha >= 0 && selectNum >= 0) {
			Debug.DrawLine(
				Vector3.forward * selectNum + Vector3.right * selectAlpha,
				Vector3.forward * (selectNum + 1) + Vector3.right * (selectAlpha + 1)
			);

			Debug.DrawLine(
				Vector3.forward * (selectNum + 1) + Vector3.right * (selectAlpha + 1),
				Vector3.forward * selectNum + Vector3.right * selectAlpha
			);
		}
	}
}
