using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : Chessman {
	public override bool[,] PossibleMoves() {
        bool[,] rm = new bool[8, 8]; 
        Chessman c1, c2;

        // White team move
        if (isWhite) {
            // Diagonal Left ----------------------------------------------------
            if (CurrentX != 0 && CurrentZ != 7) {
                c1 = BoardManager.Instance.armyField[CurrentX - 1, CurrentZ + 1];
                if (c1 != null && !c1.isWhite) {
                    rm[CurrentX - 1, CurrentZ + 1] = true;
                }
            }

            // Diagonal Right ---------------------------------------------------
            if (CurrentX != 7 && CurrentZ != 7) {
                c1 = BoardManager.Instance.armyField[CurrentX + 1, CurrentZ + 1];
                if (c1 != null && !c1.isWhite) {
                    rm[CurrentX + 1, CurrentZ + 1] = true;
                }
            }

            // Forwards ---------------------------------------------------------
            if (CurrentZ != 7) {
                c1 = BoardManager.Instance.armyField[CurrentX, CurrentZ + 1];
                if (c1 == null ) {
                    rm[CurrentX, CurrentZ + 1] = true;
                }
            }

            // Forwards on First Move -------------------------------------------
            if (CurrentZ == 1) {
                c1 = BoardManager.Instance.armyField[CurrentX, CurrentZ + 1];
                c2 = BoardManager.Instance.armyField[CurrentX, CurrentZ + 2];
                if(c1 == null && c2 == null) {
                    rm[CurrentX, CurrentZ + 2] = true;
                }
            }

        // Black team move
        } else {
            // Diagonal Left ----------------------------------------------------
            if (CurrentX != 0 && CurrentZ != 0) {
                c1 = BoardManager.Instance.armyField[CurrentX - 1, CurrentZ - 1];
                if (c1 != null && c1.isWhite) {
                    rm[CurrentX - 1, CurrentZ - 1] = true;
                }
            }

            // Diagonal Right ---------------------------------------------------
            if (CurrentX != 7 && CurrentZ != 0) {
                c1 = BoardManager.Instance.armyField[CurrentX + 1, CurrentZ - 1];
                if (c1 != null && c1.isWhite) {
                    rm[CurrentX + 1, CurrentZ - 1] = true;
                }
            }

            // Forwards ---------------------------------------------------------
            if (CurrentZ != 0) {
                c1 = BoardManager.Instance.armyField[CurrentX, CurrentZ - 1];
                if (c1 == null ) {
                    rm[CurrentX, CurrentZ - 1] = true;
                }
            }

            // Forwards on First Move -------------------------------------------
            if (CurrentZ == 6) {
                c1 = BoardManager.Instance.armyField[CurrentX, CurrentZ - 1];
                c2 = BoardManager.Instance.armyField[CurrentX, CurrentZ - 2];
                if(c1 == null && c2 == null) {
                    rm[CurrentX, CurrentZ - 2] = true;
                }
            }

        }

        return rm;
    }
}
