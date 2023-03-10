using System;

namespace ChessGame
{
    class Rook : Piece
    {
        public Rook(ChessColor color) : base(color)
        {
            Symbol = color == ChessColor.White ? '\u2656' : '\u265C';
        }

        public override bool IsValidMove(Move move, ChessBoard board)
        {
            // Check if move is horizontal or vertical
            return move.RowDelta == 0 || move.ColDelta == 0;
        }
    }
}
