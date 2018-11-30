using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : Chessman {
    public override bool[,] PossibleMoves() {
        bool[,] rm = new bool[8, 8];
        Chessman c1;
        int i, j;

        // Top Side ---------------------------------------------------------
        i = CurrentX - 1;
        j = CurrentZ + 1;
        if (CurrentZ != 7) {
            for (int k = 0; k < 3; k++) {
                if (i >= 0 || i < 8) {
                    c1 = BoardManager.Instance.armyField[i, j];
                    if (c1 == null) {
                        rm[i, j] = true;
                    } else if (this.isWhite != c1.isWhite) {
                        rm[i, j] = true;
                    }
                }
                i++;
            }
        }

        // Middle Left ------------------------------------------------------
        if (CurrentX != 0) {
            c1 = BoardManager.Instance.armyField[CurrentX - 1, CurrentZ];
            if (c1 == null) {
                rm[CurrentX - 1, CurrentZ] = true;
            } else if (this.isWhite != c1.isWhite) {
                rm[CurrentX - 1, CurrentZ] = true;
            }
        }

        // Bottom Side ------------------------------------------------------
        i = CurrentX - 1;
        j = CurrentZ - 1;
        if (CurrentZ != 0) {
            for (int k = 0; k < 3; k++) {
                if (i >= 0 || i < 8) {
                    c1 = BoardManager.Instance.armyField[i, j];
                    if (c1 == null) {
                        rm[i, j] = true;
                    } else if (this.isWhite != c1.isWhite) {
                        rm[i, j] = true;
                    }
                }
                i++;
            }
        }

        // Middle Right -----------------------------------------------------
        if (CurrentX != 7) {
            c1 = BoardManager.Instance.armyField[CurrentX + 1, CurrentZ];
            if (c1 == null) {
                rm[CurrentX + 1, CurrentZ] = true;
            } else if (this.isWhite != c1.isWhite) {
                rm[CurrentX + 1, CurrentZ] = true;
            }
        }

        CastleCheck(ref rm);

        return rm;
    }

    public void CastleCheck(ref bool[,] rm) {
        Chessman c;
        int i;
        // Kingside Castle
        if (CurrentX == 4 && (CurrentZ == 0 || CurrentZ == 7)) {
            i = CurrentX;
            while(true) {
                i++;
                if (i >= 8) {
                    break;
                }
                c = BoardManager.Instance.armyField[i, CurrentZ];
                if (i == 7) {
                    if (this.isWhite == c.isWhite && c.GetType() == typeof(Rook)) {
                        // A rook exists in the right corner
                        rm[CurrentX + 2, CurrentZ] = true;
                    } 
                } else if (c != null) {
                    break;
                }
                
            }
        }
        // Queenside Castle
        if (CurrentX == 4 && (CurrentZ == 0 || CurrentZ == 7)) {
            i = CurrentX;
            while(true) {
                i--;
                if (i < 0) {
                    break;
                }
                c = BoardManager.Instance.armyField[i, CurrentZ];
                if (i == 0) {
                    if (this.isWhite == c.isWhite && c.GetType() == typeof(Rook)) {
                        // A rook exists in the left corner
                        rm[CurrentX - 2, CurrentZ] = true;
                    } 
                } else if (c != null) {
                    break;
                }
                
            }
        }
    }
}
