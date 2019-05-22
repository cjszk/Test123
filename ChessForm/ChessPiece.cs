using System.Collections.Generic;
using System.Windows.Forms;

namespace Chess
{
    /// <summary>
    /// Abstract class representing a chess piece.
    /// </summary>
    public abstract class ChessPiece
    {
        ///// <summary>
        ///// Icon to use for display.
        ///// </summary>
        //public PieceIcon Icon { get; protected set; }
        ///// <summary>
        ///// Row piece is on
        ///// </summary>
        //public int Row { get; private set; }
        ///// <summary>
        ///// Column piece is on
        ///// </summary>
        //public int Column { get; private set; }
        ///// <summary>
        ///// Who the piece belongs to
        ///// </summary>
        //public PlayerColor Color { get; private set; }

        ///// <summary>
        ///// List of valid moves for the piece.
        ///// Row, Column, isCapture
        ///// </summary>
        //public List<(int, int, bool)> validMoves = new List<(int, int, bool)>();

        ///// <summary>
        ///// Constructor for Chess piece.
        ///// </summary>
        ///// <param name="row"></param>
        ///// <param name="column"></param>
        ///// <param name="color"></param>
        //public ChessPiece(int row, int column, PlayerColor color)
        //{
        //    Row = row;
        //    Column = column;
        //    Color = color;
        //    Icon = PieceIcon.None;
        //}
        ///// <summary>
        ///// Updates valid moves for the piece.
        ///// </summary>
        ///// <param name="board">Board to check valid moves against</param>
        ///// <remarks>Implement this in derived classes.</remarks>
        //public abstract void UpdateValidMoves(Board board);

        ///// <summary>
        ///// Checks if given move is valid.
        ///// </summary>
        ///// <param name="row"></param>
        ///// <param name="column"></param>
        ///// <returns>true if move is valid, false otherwise </returns>
        //public virtual bool IsValidMove(int row, int column)
        //{
        //    return validMoves.Contains((row, column, true)) || validMoves.Contains((row, column, false));
        //}

        ///// <summary>
        ///// Creates an int array for the form to display highlights.
        ///// </summary>
        ///// <returns></returns>
        //public virtual int[,] ShowAllPieceMoves(Board board)
        //{
        //    // update valid moves before display
        //    UpdateValidMoves(board);
        //    // empty display board
        //    int[,] boardOut = new int[9, 9];
        //    // highlight selected piece
        //    boardOut[Row, Column + 1] = (int)PieceHighlight.Highlight;
        //    // highlight possible moves
        //    foreach ((int, int, bool) move in validMoves)
        //    {
        //        if (move.Item3)
        //        {
        //            boardOut[move.Item1, move.Item2 + 1] = (int)PieceHighlight.ValidCapture;
        //        } else
        //        {
        //            boardOut[move.Item1, move.Item2 + 1] = (int)PieceHighlight.ValidMove;
        //        }
        //    }
        //    MessageBox.Show($"{boardOut}");
        //    return boardOut;
        //}

        //public virtual void Reposition(Board board, int row, int column)
        //{
        //    Row = row;
        //    Column = column;
        //}

        //protected bool IsOpponent(ChessPiece opp)
        //{
        //    if (opp == null) return false;
        //    return Color != opp.Color;
        //}
    }
}
