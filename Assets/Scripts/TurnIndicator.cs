using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnIndicator : MonoBehaviour {
	public GameObject whiteTurnIcon;
	public GameObject blackTurnIcon;

	void Start() {

	}

	void Update() {
		if (BoardManager.Instance.isWhiteTurn) {
			whiteTurnIcon.SetActive(true);
			blackTurnIcon.SetActive(false);
		} else {
			whiteTurnIcon.SetActive(false);
			blackTurnIcon.SetActive(true);
		}
	}
}
