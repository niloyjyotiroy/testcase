using System;

namespace ChessGame
{
    class Queen : Piece
    {
        public Queen(ChessColor color) : base(color)
        {
            Symbol = color == ChessColor.White ? '\u2655' : '\u265B';
        }

        public override bool IsValidMove(Move move, ChessBoard board)
        {
            // Check if move is horizontal, vertical, or diagonal
            return move.RowDelta == 0 || move.ColDelta == 0 || Math.Abs(move.RowDelta) == Math.Abs(move.ColDelta);
        }
    }
}
