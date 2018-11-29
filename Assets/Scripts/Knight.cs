using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Chessman {
    public override bool[,] PossibleMoves() {
        bool[,] rm = new bool [8, 8];

        // Up then Left -----------------------------------------------------
        KnightMove(CurrentX - 1, CurrentZ + 2, ref rm);

        // Up then Right ----------------------------------------------------
        KnightMove(CurrentX + 1, CurrentZ + 2, ref rm);

        // Right then Up ----------------------------------------------------
        KnightMove(CurrentX + 2, CurrentZ + 1, ref rm);

        // Right then Down --------------------------------------------------
        KnightMove(CurrentX + 2, CurrentZ - 1, ref rm);

        // Down then Right --------------------------------------------------
        KnightMove(CurrentX + 1, CurrentZ - 2, ref rm);

        // Down then Left ---------------------------------------------------
        KnightMove(CurrentX - 1, CurrentZ - 2, ref rm);
        
        // Left then Down ---------------------------------------------------
        KnightMove(CurrentX - 2, CurrentZ + 1, ref rm);

        // Left then Up -----------------------------------------------------
        KnightMove(CurrentX - 2, CurrentZ - 1, ref rm);


        return rm;
    }

    public void KnightMove(int x, int z, ref bool[,] rm) {
        Chessman c1;

        if (x >= 0 && x < 8 && z >= 0 && z < 8) {
            c1 = BoardManager.Instance.armyField[x, z];
            if (c1 == null) {
                rm[x, z] = true;
            } else if (this.isWhite != c1.isWhite) {
                rm[x, z] = true;
            }
        }
    }
}
