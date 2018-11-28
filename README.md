# Project Title: Gambit

## simple hotseat chess game

### Build specifications

* 16 pieces for each side
  * 8 pawns, 2 rook/knight/bishop, 1 queen, 1 king
  * Pawn promotion is allowed upon reaching the far side of the board
  * Promotion of pawns allows selection of piece type and replaces that object with an instance of it.
* Turn order alternates, beginning with white
  * During a turn, only the pieces of that type can be moved.
  * Game must end when a king piece is taken. Other player then wins.
* Each piece will be tagged with type, as a child of white or black pieces.
  * Movement is only allowed during that player’s turn and while
  * If a piece moves onto an enemy it will destroy it for the remainder of the round
  * Castling should be enabled under the proper rules
* When a piece is selected it will show where it can move
  * Only pieces which can move can be selected.
  * Clicking elsewhere will cancel the selection
  * Clicking a valid square will move the piece
  * Each square will be identified by its alphanumeric type: [a-h][0-8]
* Simple title screen with uGUI
  * Start
  * Settings
  * Exit
* Simple pause menu
  * Restart game
  * Return to menu
* Victory screen allows for rematch or return to menu
  * Game must gracefully restart when completed
* Board should rotate to the side of the current player
  * All pieces must retain position and function relative to the board
* (Extension Goal) Incorporate a simple chess clock
  * Time for each player will tick down during their turn. If their time reaches zero, the game ends.
  * In this case, score is used to determine the winner
* (Extension Goal) Keep a log of moves during each turn
  * Allow for said log to be saved or exported.
  * Using algebraic notation I.e e4, Bxc6, 0-0
