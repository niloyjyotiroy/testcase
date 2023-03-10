using System;
using System.Drawing;

namespace ChessGame
{
    class King : Piece
    {
        public King(ChessColor color) : base(color)
        {
            Symbol = color == ChessColor.White ? '\u2654' : '\u265A';
        }

        public override bool IsValidMove(Move move, ChessBoard board)
        {
            // Check if move is one square away in any direction
            if (Math.Abs(move.RowDelta) > 1 || Math.Abs(move.ColDelta) > 1)
                return false;

            // Check if destination square is empty or has opponent's piece
            Piece destPiece = board.GetPiece(move.To.Row, move.To.Col);
            return destPiece == null || destPiece.Color != Color;
        }
    }
}
