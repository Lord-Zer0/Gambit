using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : Chessman {
    public override bool[,] PossibleMoves() {
        bool[,] rm = new bool[8, 8];
        Chessman c1;
        int i, j;


        // ==================================================================
        // Linear Movement
        // ==================================================================

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
                if (c1.isWhite != this.isWhite) {
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
                if (c1.isWhite != this.isWhite) {
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
                if (c1.isWhite != this.isWhite) {
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
                if (c1.isWhite != this.isWhite) {
                    rm[CurrentX, i] = true;
                }
                break;
            }
        }


        // ==================================================================
        // Diagonal Movement
        // ==================================================================
        // Top Left Quadrant ------------------------------------------------
        i = CurrentX;
        j =  CurrentZ;
        while(true) {
            i--;
            j++;
            if (i < 0 || j >= 8){
                break;
            }

            c1 = BoardManager.Instance.armyField[i , j];
            if (c1 == null) {
                rm[i, j] = true;
            } else {
                if (this.isWhite != c1.isWhite) {
                    rm[i, j] = true;
                }
                break;
            }
        }

        // Top Right Quadrant ------------------------------------------------
        i = CurrentX;
        j =  CurrentZ;
        while(true) {
            i++;
            j++;
            if (i >= 8 || j >= 8){
                break;
            }

            c1 = BoardManager.Instance.armyField[i , j];
            if (c1 == null) {
                rm[i, j] = true;
            } else {
                if (this.isWhite != c1.isWhite) {
                    rm[i, j] = true;
                }
                break;
            }
        }

        // Bottom Right Quadrant ---------------------------------------------
        i = CurrentX;
        j =  CurrentZ;
        while(true) {
            i++;
            j--;
            if (i >= 8 || j < 0){
                break;
            }

            c1 = BoardManager.Instance.armyField[i , j];
            if (c1 == null) {
                rm[i, j] = true;
            } else {
                if (this.isWhite != c1.isWhite) {
                    rm[i, j] = true;
                }
                break;
            }
        }
        
        // Bottom Left Quadrant ----------------------------------------------
        i = CurrentX;
        j =  CurrentZ;
        while(true) {
            i--;
            j--;
            if (i < 0 || j < 0){
                break;
            }

            c1 = BoardManager.Instance.armyField[i , j];
            if (c1 == null) {
                rm[i, j] = true;
            } else {
                if (this.isWhite != c1.isWhite) {
                    rm[i, j] = true;
                }
                break;
            }
        }

        return rm;
    }
}
