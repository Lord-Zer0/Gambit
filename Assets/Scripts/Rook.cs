using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : Chessman {
	public override bool[,] PossibleMoves() {
        bool[,] rVal = new bool[8, 8];
        Chessman c1;
        int i;

        // Right Movement ---------------------------------------------------
        for (i = CurrentX; i < 8; i++) {
            c1 = BoardManager.Instance.armyField[i, CurrentZ];
            if (c1 == null) {
                rVal[i, CurrentZ] = true;
            } else {
                if (c1.isWhite != this.isWhite) {
                    rVal[i, CurrentZ] = true;
                }
                break;
            }
        }

        // Left Movement ----------------------------------------------------
        for (i = CurrentX; i >= 0; i--) {
            c1 = BoardManager.Instance.armyField[i, CurrentZ];
            if (c1 == null) {
                rVal[i, CurrentZ] = true;
            } else {
                if (c1.isWhite != this.isWhite) {
                    rVal[i, CurrentZ] = true;
                }
                break;
            }
        }

        // Upwards Movement -------------------------------------------------
        for (i = CurrentZ; i < 8; i++) {
            c1 = BoardManager.Instance.armyField[CurrentX, i];
            if (c1 == null) {
                rVal[CurrentX, i] = true;
            } else {
                if (c1.isWhite != this.isWhite) {
                    rVal[CurrentX, i] = true;
                }
                break;
            }
        }

        // Downwards Movement -----------------------------------------------
        for (i = CurrentZ; i >= 0; i--) {
            c1 = BoardManager.Instance.armyField[CurrentX, i];
            if (c1 == null) {
                rVal[CurrentX, i] = true;
            } else {
                if (c1.isWhite != this.isWhite) {
                    rVal[CurrentX, i] = true;
                }
                break;
            }
        }

        return rVal;
    }
}
