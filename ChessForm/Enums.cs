namespace Chess
{
    /// <summary>
    /// Enum to store player as color.
    /// </summary>
    public enum PlayerColor { White, Black };

    public enum PieceIcon { None = 0,
        WhitePawn, WhiteRook, WhiteKnight, WhiteBishop, WhiteKing, WhiteQueen,
        BlackPawn, BlackRook, BlackKnight, BlackBishop, BlackKing, BlackQueen };

    public enum PieceHighlight { None = 0, Highlight=0, ValidMove=-1, ValidCapture=-2 };
}
