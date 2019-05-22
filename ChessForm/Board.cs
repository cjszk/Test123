using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Chess
{
    public class Board
    {
        int[,] boardState = {
            { 0, 8, 9, 10, 12, 11, 10, 9, 8 },
            { 0, 7, 7, 7, 7, 7, 7, 7, 7 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 0, 2, 3, 4, 6, 5, 4, 3, 2 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        };
        string[] pieces =
            {
                "None",
                "WhitePawn", "Rook", "Knight", "Bishop", "King", "Queen",
                "BlackPawn", "Rook", "Knight", "Bishop", "King", "Queen"
            };
        // { row, column } these obviously need to be refactored. Currently hard coded.
        // Refactoring Notes:
        // Each piece should be its own class. make pieces var ~ ChessPiece[] pieces = { (ChessPieces) }
        // GetPieceMoves() should then be refactored to a more simplified version where it uses array of ChessPiece[].
        int[,] whitePawnMovesInitial = { { -1, 0 }, { -2, 0 } };
        int[,] whitePawnMoves = { { -1, 0 } };
        int[,] blackPawnMovesInitial = { { 1, 0 }, { 2, 0 } };
        int[,] blackPawnMoves = { { 1, 0 } };
        int[,] whitePawnCaptures = { { -1, 1 }, { -1, -1 } };
        int[,] blackPawnCaptures = { { 1, 1 }, { 1, -1 } };
        int[,] knightMoves =
        {
            { -1, -2 }, { 1, 2 }, { 1, -2 }, { -1, 2 },
            { -2, -1 }, { 2, 1 }, { 2, -1 }, { -2, 1 }
        };
        int[,] rookMoves = 
        { 
            { -1, 0 }, { -2, 0 }, { -3, 0 }, { -4, 0 }, { -5, 0 }, { -6, 0 }, { -7, 0 },
            { 1, 0 }, { 2, 0 }, { 3, 0 }, { 4, 0 }, { 5, 0 }, { 6, 0 }, { 7, 0 }, 
            { 0, -1 }, { 0, -2 }, { 0, -3 }, { 0, -4 }, { 0, -5 }, { 0, -6 }, { 0, -7 },
            { 0, 1 }, { 0, 2 }, { 0, 3 }, { 0, 4 }, { 0, 5 }, { 0, 6 }, { 0, 7 },
        };
        int[,] bishopMoves =
        {
            { -1, -1 }, { -2, -2 }, { -3, -3 }, { -4, -4 }, { -5, -5 }, { -6, -6 }, { -7, -7 },
            { 1, 1 }, { 2, 2 }, { 3, 3 }, { 4, 4 }, { 5, 5 }, { 6, 6 }, { 7, 7 },
            { 1, -1 }, { 2, -2 }, { 3, -3 }, { 4, -4 }, { 5, -5 }, { 6, -6 }, { 7, -7 },
            { -1, 1 }, { -2, 2 }, { -3, 3 }, { -4, 4 }, { -5, 5 }, { -6, 6 }, { -7, 7 },
        };
        int[,] queenMoves = {
            { -1, 0 }, { -2, 0 }, { -3, 0 }, { -4, 0 }, { -5, 0 }, { -6, 0 }, { -7, 0 },
            { 1, 0 }, { 2, 0 }, { 3, 0 }, { 4, 0 }, { 5, 0 }, { 6, 0 }, { 7, 0 }, 
            { 0, -1 }, { 0, -2 }, { 0, -3 }, { 0, -4 }, { 0, -5 }, { 0, -6 }, { 0, -7 },
            { 0, 1 }, { 0, 2 }, { 0, 3 }, { 0, 4 }, { 0, 5 }, { 0, 6 }, { 0, 7 },
            { -1, -1 }, { -2, -2 }, { -3, -3 }, { -4, -4 }, { -5, -5 }, { -6, -6 }, { -7, -7 },
            { 1, 1 }, { 2, 2 }, { 3, 3 }, { 4, 4 }, { 5, 5 }, { 6, 6 }, { 7, 7 },
            { 1, -1 }, { 2, -2 }, { 3, -3 }, { 4, -4 }, { 5, -5 }, { 6, -6 }, { 7, -7 },
            { -1, 1 }, { -2, 2 }, { -3, 3 }, { -4, 4 }, { -5, 5 }, { -6, 6 }, { -7, 7 },
        };
        int[,] kingMoves =
        {
            { 1, 0 }, { 1, 1 }, { 0 , 1 }, { -1, 0 }, { -1, -1 }, { 0 , -1 }, { 1, -1 }, { -1, 1 }
        };

        public int[,] ShowBoardState()
        {
            return boardState;
        }

        public string GetPiece(int row, int column)
        {
            return pieces[boardState[row, column]];
        }

        public int[,] GetPieceMoves(int row, int column)
        {
            int[,] potentialMoves = { };
            int[,] potentialCaptures = { };
            string piece = GetPiece(row, column);
            if (row == 6 && piece == "WhitePawn")
            {
                potentialMoves = whitePawnMovesInitial;
                potentialCaptures = whitePawnCaptures;
            }
            else if (piece == "WhitePawn")
            {
                potentialMoves = whitePawnMoves;
                potentialCaptures = whitePawnCaptures;
            }
            else if (row == 1 && piece == "BlackPawn")
            {
                potentialMoves = blackPawnMovesInitial;
                potentialCaptures = blackPawnCaptures;
            }
            else if (piece == "BlackPawn")
            {
                potentialMoves = blackPawnMoves;
                potentialCaptures = blackPawnCaptures;
            }
            else if (piece == "Knight")
            {
                potentialMoves = knightMoves;
                potentialCaptures = knightMoves;
            }
            else if (piece == "Rook")
            {
                potentialMoves = rookMoves;
                potentialCaptures = rookMoves;
            }
            else if (piece == "Bishop")
            {
                potentialMoves = bishopMoves;
                potentialCaptures = bishopMoves;
            }
            else if (piece == "Queen")
            {
                potentialMoves = queenMoves;
                potentialCaptures = queenMoves;
            }
            else if (piece == "King")
            {
                potentialMoves = kingMoves;
                potentialCaptures = kingMoves;
            }
            if (potentialMoves.Length == 0) return null;
            return ShowValidMoves(row, column, potentialMoves, potentialCaptures);
        }

        public int[,] ShowValidMoves(int row, int column, int[,] potentialMoves, int[,] potentialCaptures)
        {
            int[,] result = (int[,])boardState.Clone();
            int[,] mappedMoves = (int[,])potentialMoves.Clone();
            int[,] mappedCaptures = (int[,])potentialCaptures.Clone();
            for (int i = 0; i < mappedMoves.GetLength(0); i++)
            {
                mappedMoves[i, 0] += row;
                mappedMoves[i, 1] += column;
                // prevent off-board moves
                if (isOutOfBounds(mappedMoves, i) == true) continue;
                if (result[mappedMoves[i, 0], mappedMoves[i, 1]] == 0) result[mappedMoves[i, 0], mappedMoves[i, 1]] = -1;
                // else break;
            }
            for (int i = 0; i < mappedCaptures.GetLength(0); i++)
            {
                mappedCaptures[i, 0] += row;
                mappedCaptures[i, 1] += column;
                // prevent off-board captures
                if (isOutOfBounds(mappedCaptures, i) == true) continue;
                // prevent capture of own pieces
                int turn = ChessForm.turn;
                if (turn % 2 == 0 && boardState[mappedCaptures[i, 0], mappedCaptures[i, 1]] > 6 ||
                    turn % 2 == 1 && boardState[mappedCaptures[i, 0], mappedCaptures[i, 1]] < 7)
                    if (boardState[mappedCaptures[i, 0], mappedCaptures[i, 1]] > 0)
                        result[mappedCaptures[i, 0], mappedCaptures[i, 1]] = -2;
            }
            return result;
        }

        public bool isOutOfBounds(int[,] mappedMoves, int i)
        {
            if (mappedMoves[i, 0] < 0 ||
                mappedMoves[i, 0] > 7 ||
                mappedMoves[i, 1] > 8 ||
                mappedMoves[i, 1] < 1) return true;
            return false;
        }
        ///<summary>
        /// row = Origin Panel row, column = Origin Panel column, destination = Target Panel to move to
        ///</summary>
        public void movePiece(int row, int column, ChessPanel destination)
        {
            boardState[destination.row, destination.column] = boardState[row, column];
            boardState[row, column] = 0;
        }
    }
}
