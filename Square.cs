namespace ChessGame
{
    class Square
    {
        public BoardSquare BoardSquare { get; }
        public Piece Piece { get; set; }

        public Square(int row, int col, ConsoleColor color)
        {
            BoardSquare = new BoardSquare(row, col, color);
        }
    }
}
