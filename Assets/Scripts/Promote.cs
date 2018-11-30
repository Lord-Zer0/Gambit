using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Promote : MonoBehaviour {
	public int PromoteSelected(string target) {
		int id;
		switch (target)
		{
			case "Rook":
				id = 1;
				break;

			case "Knight":
				id = 2;
				break;

			case "Bishop":
				id = 2;
				break;

			default:
				id = 4;
				break;
		}
		if (!BoardManager.Instance.isWhiteTurn){
			id += 6;
		}

		BoardManager.Instance.promotionUI.SetActive(false);

		return id;
	}
}
