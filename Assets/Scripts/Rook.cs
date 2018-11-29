using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : Chessman {
	public override bool[,] PossibleMoves() {
        bool[,] rm = new bool[8, 8];
        Chessman c1;
        int i;

        // Right Movement ---------------------------------------------------
        i = CurrentX;
        while (true) {
            i++;
            if (i >= 8) {
                break;
            }

            c1 = BoardManager.Instance.armyField[i, CurrentZ];
            if (c1 == null) {
                rm[i, CurrentZ] = true;
            } else {
                if (this.isWhite != c1.isWhite) {
                    rm[i, CurrentZ] = true;
                }
                break;
            }
        }

        // Left Movement ----------------------------------------------------
        i = CurrentX;
        while (true) {
            i--;
            if (i < 0) {
                break;
            }

            c1 = BoardManager.Instance.armyField[i, CurrentZ];
            if (c1 == null) {
                rm[i, CurrentZ] = true;
            } else {
                if (this.isWhite != c1.isWhite) {
                    rm[i, CurrentZ] = true;
                }
                break;
            }
        }

        // Upwards Movement -------------------------------------------------
        i = CurrentZ;
        while (true) {
            i++;
            if (i >= 8) {
                break;
            }

            c1 = BoardManager.Instance.armyField[CurrentX, i];
            if (c1 == null) {
                rm[CurrentX, i] = true;
            } else {
                if (this.isWhite != c1.isWhite) {
                    rm[CurrentX, i] = true;
                }
                break;
            }
        }

        // Downwards Movement -----------------------------------------------
        i = CurrentZ;
        while (true) {
            i--;
            if (i < 0) {
                break;
            }
            
            c1 = BoardManager.Instance.armyField[CurrentX, i];
            if (c1 == null) {
                rm[CurrentX, i] = true;
            } else {
                if (this.isWhite != c1.isWhite) {
                    rm[CurrentX, i] = true;
                }
                break;
            }
        }

        return rm;
    }
}
