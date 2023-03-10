using System;
using System.Drawing;

namespace ChessGame
{
    class Bishop : Piece
    {
        public Bishop(ChessColor color) : base(color)
        {
            Symbol = color == ChessColor.White ? '\u2657' : '\u265D';
        }

        public override bool IsValidMove(Move move, ChessBoard board)
        {
            // Check if move is diagonal
            if (Math.Abs(move.RowDelta) != Math.Abs(move.ColDelta))
                return false;

            // Check if there are any pieces in the way
            int rowDir = Math.Sign(move.RowDelta);
            int colDir = Math.Sign(move.ColDelta);
            int row = move.From.Row + rowDir;
            int col = move.From.Col + colDir;
            while (row != move.To.Row && col != move.To.Col)
            {
                if (board.GetPiece(row, col) != null)
                    return false;
                row += rowDir;
                col += colDir;
            }

            // Check if destination square is empty or has opponent's piece
            Piece destPiece = board.GetPiece(move.To.Row, move.To.Col);
            return destPiece == null || destPiece.Color != Color;
        }
    }
}
