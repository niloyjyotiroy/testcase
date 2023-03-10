namespace ChessGame
{
    class Move
    {
        public BoardSquare From { get; }
        public BoardSquare To { get; }
        public int RowDelta => To.Row - From.Row;
        public int ColDelta => To.Col - From.Col;

        public Move(BoardSquare from, BoardSquare to)
        {
            From = from;
            To = to;
        }
    }
}
