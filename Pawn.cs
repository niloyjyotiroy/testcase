using System;
using System.Drawing;

namespace ChessGame
{
    class Pawn : Piece
    {
        public Pawn(ChessColor color) : base(color)
        {
            Symbol = color == ChessColor.White ? '\u2659' : '\u265F';
        }

        public override bool IsValidMove(Move move, ChessBoard board)
        {
            // Check if move is forward one or two squares
            int rowDir = Color == ChessColor.White ? -1 : 1;
            if (move.RowDelta != rowDir && !(move.RowDelta == 2 * rowDir && move.From.Row == (Color == ChessColor.White ? 6 : 1)))
                return false;

            // Check if move is straight ahead or diagonal one square
            if (move.ColDelta != 0 && Math.Abs(move.ColDelta) != 1)
                return false;

            // Check if destination square is empty or has opponent's piece
            Piece destPiece = board.GetPiece(move.To.Row, move.To.Col);
            if (move.ColDelta == 0)
            {
                // Move is straight ahead
                return destPiece == null;
            }
            else
            {
                // Move is diagonal
                return destPiece != null && destPiece.Color != Color;
            }
        }
    }
}
