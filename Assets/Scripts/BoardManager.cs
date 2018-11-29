using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour {

	public Chessman[,] armyField { set; get;}
	private Chessman selectedUnit;
	private const float TILE_SIZE = 1.0f;
	private const float TILE_OFFSET = 0.5f;
	private int selectAlpha;
	private int selectNum;
	private Quaternion orientation = Quaternion.Euler(0, 180, 0);
	public List<GameObject> unitPrefabs;
	public List<GameObject> activeUnits;

	private Vector3 offsetFix = new Vector3(-0.5f, 0f, -0.5f);

	private void Start() {
		SpawnFullBoard();
	}

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

	private void SpawnUnit(int index, int x, int z) {
		Quaternion quat = Quaternion.identity;
		if (index > 5) {
			quat = orientation;
		}
		GameObject go = Instantiate(unitPrefabs[index], GetTileCentre(x, z), quat) as GameObject;
		go.transform.SetParent(transform);
		armyField[x, z] = go.GetComponent<Chessman> ();
		armyField[x, z].SetPosition(x, z);
		activeUnits.Add(go);
	}

	private Vector3 GetTileCentre(int x, int z) {
		Vector3 origin = Vector3.zero;
		origin.x += (TILE_SIZE * x);
		origin.z += (TILE_SIZE * z);
		return origin;
	}

	private void SpawnFullBoard() {

		armyField = new Chessman[8, 8];
		activeUnits = new List<GameObject>();

		// ==============================
		// Spawn all White Units
		// ==============================

		// Pawns ------------------------
		for (int i = 0; i < 8; i++) {
			SpawnUnit(0, i, 1);
		}

		// Rooks ------------------------
		SpawnUnit(1, 0, 0);
		SpawnUnit(1, 7, 0);
		
		// Knights ----------------------
		SpawnUnit(2, 1, 0);
		SpawnUnit(2, 6, 0);

		// Bishops ----------------------
		SpawnUnit(3, 2, 0);
		SpawnUnit(3, 5, 0);

		// Queen ------------------------
		SpawnUnit(4, 3, 0);

		// King -------------------------
		SpawnUnit(5, 4, 0);

		// ==============================
		// Spawn all Black Units
		// ==============================

		// Pawns ------------------------
		for (int i = 0; i < 8; i++) {
			SpawnUnit(6, i, 6);
		}

		// Rooks ------------------------
		SpawnUnit(7, 0, 7);
		SpawnUnit(7, 7, 7);
		
		// Knights ----------------------
		SpawnUnit(8, 1, 7);
		SpawnUnit(8, 6, 7);

		// Bishops ----------------------
		SpawnUnit(9, 2, 7);
		SpawnUnit(9, 5, 7);

		// Queen ------------------------
		SpawnUnit(10, 3, 7);

		// King -------------------------
		SpawnUnit(11, 4, 7);

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
