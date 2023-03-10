namespace ChessGame
{
    abstract class Piece
    {
        public ChessColor Color { get; }
        public char Symbol { get; protected set; }

        public Piece(ChessColor color)
        {
            Color = color;
        }

        public abstract bool IsValidMove(Move move, ChessBoard board);
    }
}
