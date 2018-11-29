using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour {

	public Chessman[,] armyField { set; get;}
	private Chessman selectedUnit;
	private const float TILE_SIZE = 1.0f;
	private const float TILE_OFFSET = 0.5f;
	private int selectX;
	private int SelectZ;
	private Quaternion orientation = Quaternion.Euler(0, 180, 0);
	public List<GameObject> unitPrefabs;
	public List<GameObject> activeUnits;
	public bool isWhiteTurn = true;

	private Vector3 offsetFix = new Vector3(-0.5f, 0f, -0.5f);

	private void Start() {
		SpawnFullBoard();
	}

	private void Update() {
		UpdateSelection();
		DrawChessBoard();

		if (Input.GetMouseButtonDown(0)) {
			if (selectX >= 0 && SelectZ >= 0) {
				// Select the target unit
				SelectUnit(selectX, SelectZ);
			} else {
				// Move to a valid space
				MoveUnit(selectX, SelectZ);
			}
		}
	}

	private void SelectUnit(int x, int z) {
		if (armyField[x, z] == null)
			return; 
		if (armyField[x, z].isWhite != isWhiteTurn)
			return;

		selectedUnit = armyField[x, z];
	}

	private void MoveUnit(int x, int z) {
		if (selectedUnit.PossibleMove(x, z)) {
			armyField[selectedUnit.CurrentX, selectedUnit.CurrentZ] = null;
			selectedUnit.transform.position = AlignTile(x, z);
			armyField[x, z] = selectedUnit;
			// Toggle turn order
			isWhiteTurn = !isWhiteTurn;
		}

		selectedUnit = null;
	}

	private void UpdateSelection() {
		if (!Camera.main) {
			return;
		}

		RaycastHit hit;

		if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 25.0f, LayerMask.GetMask("BoardLevel"))) {
			selectX = (int)hit.point.x;
			SelectZ = (int)hit.point.z;
		} else {
			selectX = -1;
			SelectZ = -1;
		}

		print(selectX + SelectZ);
	}

	private void SpawnUnit(int index, int x, int z) {
		Quaternion quat = Quaternion.identity;
		if (index > 5) {
			quat = orientation;
		}
		GameObject go = Instantiate(unitPrefabs[index], AlignTile(x, z), quat) as GameObject;
		go.transform.SetParent(transform);
		armyField[x, z] = go.GetComponent<Chessman> ();
		armyField[x, z].SetPosition(x, z);
		activeUnits.Add(go);
	}

	private Vector3 AlignTile(int x, int z) {
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
		if (selectX >= 0 && SelectZ >= 0) {
			Debug.DrawLine(
				Vector3.forward * SelectZ + Vector3.right * selectX,
				Vector3.forward * (SelectZ + 1) + Vector3.right * (selectX + 1)
			);

			Debug.DrawLine(
				Vector3.forward * (SelectZ + 1) + Vector3.right * (selectX + 1),
				Vector3.forward * SelectZ + Vector3.right * selectX
			);
		}
	}
}
