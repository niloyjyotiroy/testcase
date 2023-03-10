using System;

namespace ChessGame
{
    class BoardSquare
    {
        public int Row { get; }
        public int Col { get; }
        public ConsoleColor Color { get; }

        public BoardSquare(int row, int col, ConsoleColor color)
        {
            Row = row;
            Col = col;
            Color = color;
        }
    }
}
