// See https://aka.ms/new-console-template for more information
using System;

namespace ChessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create players
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            
            ChessBoard board = new ChessBoard();

            Player whitePlayer = new Player(ChessColor.White);
            Player blackPlayer = new Player(ChessColor.Black);

            // Create chess board
            

            //             // Initialize console colors
            ConsoleColor lightSquareColor = ConsoleColor.Gray;
            ConsoleColor darkSquareColor = ConsoleColor.DarkGray;
            ConsoleColor selectedSquareColor = ConsoleColor.Blue;
            ConsoleColor validMoveSquareColor = ConsoleColor.Green;
            ConsoleColor invalidMoveSquareColor = ConsoleColor.Red;

            // Game loop
            Player currentPlayer = whitePlayer;
            while (true)
            {
                // Draw board
                DrawBoard(board, lightSquareColor, darkSquareColor, selectedSquareColor, validMoveSquareColor, invalidMoveSquareColor);

                // Get player move
                Console.WriteLine($"{currentPlayer.Color} player's turn:");
                Move move = currentPlayer.GetMove();

                // Check if move is valid and apply it if it is
                bool isValidMove = false;
                if (move != null)
                {
                    if (board.GetPiece(move.From.Row, move.From.Col)?.Color == currentPlayer.Color &&
                        board.GetPiece(move.To.Row, move.To.Col)?.Color != currentPlayer.Color &&
                        board.GetPiece(move.From.Row, move.From.Col)?.IsValidMove(move, board) == true)
                    {
                        board.MovePiece(move);
                        isValidMove = true;
                    }
                }

                // Check if game is over
                if (board.IsCheckmate(currentPlayer.Color))
                {
                    Console.WriteLine($"{currentPlayer.Color} player is checkmated. Game over.");
                    break;
                }
                else if (board.IsStalemate(currentPlayer.Color))
                {
                    Console.WriteLine("Stalemate. Game over.");
                    break;
                }

                // Switch to other player if move was valid
                if (isValidMove)
                {
                    currentPlayer = currentPlayer == whitePlayer ? blackPlayer : whitePlayer;
                }
                else
                {
                    Console.WriteLine("Invalid move.");
                }
            }
        }

        static void DrawBoard(ChessBoard board, ConsoleColor lightSquareColor, ConsoleColor darkSquareColor,
                              ConsoleColor selectedSquareColor, ConsoleColor validMoveSquareColor,
                              ConsoleColor invalidMoveSquareColor)
        {
            Console.Clear();
            Console.WriteLine("  a b c d e f g h");
            for (int row = 0; row < 8; row++)
            {
                Console.Write($"{8 - row} ");
                for (int col = 0; col < 8; col++)
                {
                    ConsoleColor bgColor = (row + col) % 2 == 0 ? lightSquareColor : darkSquareColor;
                    Console.BackgroundColor = bgColor;

                    Piece piece = board.GetPiece(row, col);
                    if (piece != null)
                    {
                        Console.ForegroundColor = piece.Color == ChessColor.White ? ConsoleColor.White : ConsoleColor.Black;
                        Console.Write($" {piece.Symbol} ");
                    }
                    else
                    {
                        Console.Write("   ");
                    }

                    Console.ResetColor();
                }
                Console.WriteLine($" {8 - row}");
            }
            Console.WriteLine("  a b c d e f g h");
        }
    }
}


