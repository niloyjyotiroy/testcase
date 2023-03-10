using System;

namespace ChessGame
{
    class Player
    {
        public ChessColor Color { get; }

        public Player(ChessColor color)
        {
            Color = color;
        }

        public Move GetMove()
        {
            Console.Write($"{Color} player's turn. Enter move (e.g. a2a4): ");
            string input = Console.ReadLine();
            if (input == null || input.Length != 4)
            {
                Console.WriteLine("Invalid move. Please enter a move in the format 'a2a4'.");
                return null;
            }

            int fromRow = 8 - int.Parse(input[1].ToString());
            int fromCol = input[0] - 'a';
            int toRow = 8 - int.Parse(input[3].ToString());
            int toCol = input[2] - 'a';

            return new Move(new BoardSquare(fromRow, fromCol, ConsoleColor.White), new BoardSquare(toRow, toCol, ConsoleColor.White));
        }
    }
}
