using System;

namespace ChessGame
{
    class Knight : Piece
    {
        public Knight(ChessColor color) : base(color)
        {
            Symbol = color == ChessColor.White ? '\u2658' : '\u265E';
        }

        public override bool IsValidMove(Move move, ChessBoard board)
        {
            // Check if move is L-shaped
            return (Math.Abs(move.RowDelta) == 2 && Math.Abs(move.ColDelta) == 1) ||
                   (Math.Abs(move.RowDelta) == 1 && Math.Abs(move.ColDelta) == 2);
        }
    }
}
