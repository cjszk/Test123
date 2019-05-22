using System;
using System.Collections.Generic;

namespace Chess
{
    class PawnPiece : ChessPiece
    {
        //public PawnPiece(int row, int column, PlayerColor color) : base(row, column, color)
        //{
        //    if (color == PlayerColor.White)
        //    {
        //        Icon = PieceIcon.WhitePawn;
        //    } else
        //    {
        //        Icon = PieceIcon.BlackPawn;
        //    }
        //}

        //public override void UpdateValidMoves(Board board)
        //{
        //    validMoves = new List<(int, int, bool)>();
        //    // get next row forwards
        //    int rowForward = Row + RowForward();
        //    // if next row forwards is out of bounds, no valid moves
        //    if (rowForward > 7 || rowForward < 0) return;
        //    // check spot in front of me, if empty I can move there
        //    if (board.PieceAt(rowForward, Column) == null)
        //    {
        //        validMoves.Add((rowForward, Column, false));
        //        // if on original row and unblocked, I can move forward 2 spaces as well
        //        if (Row == InitialRow() && board.PieceAt(rowForward + RowForward(), Column) == null)
        //        {
        //            validMoves.Add((rowForward + RowForward(), Column, false));
        //        }
        //    }
        //    // check spots diagonally adjacent, if either has a piece, I can capture there
        //    if (Column > 0)
        //    {
        //        ChessPiece tempPiece = board.PieceAt(rowForward, Column - 1);
        //        if (tempPiece != null && IsOpponent(tempPiece))
        //        {
        //            validMoves.Add((rowForward, Column - 1, true));
        //        }
        //    }
        //    if (Column < 7)
        //    {
        //        ChessPiece tempPiece = board.PieceAt(rowForward, Column + 1);
        //        if (tempPiece != null && IsOpponent(tempPiece))
        //        {
        //            validMoves.Add((rowForward, Column + 1, true));
        //        }
        //    }
        //}

        //private int RowForward()
        //{
        //    return (Color == PlayerColor.White ? 1 : -1);
        //}
        //private int InitialRow()
        //{
        //    return (Color == PlayerColor.White ? 1 : 6);
        //}
    }
}
