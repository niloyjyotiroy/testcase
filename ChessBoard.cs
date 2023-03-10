using ChessGame;

class ChessBoard
{
    private const int BoardSize = 8;
    private Piece[,] pieces;
    private ConsoleColor backgroundColor1;
    private ConsoleColor backgroundColor2;

    public ChessBoard()
    {
        pieces = new Piece[8, 8];
        InitializePieces();
        backgroundColor1 = ConsoleColor.DarkGray;
        backgroundColor2 = ConsoleColor.Gray;
    }

    public Piece GetPiece(int row, int col)
    {
        if (row < 0 || row > 7 || col < 0 || col > 7)
            return null;
        return pieces[row, col];
    }

    public void SetPiece(int row, int col, Piece piece)
    {
        pieces[row, col] = piece;
    }

    private void InitializePieces()
    {
        // White pieces
        SetPiece(0, 0, new Rook(ChessColor.White));
        SetPiece(0, 1, new Knight(ChessColor.White));
        SetPiece(0, 2, new Bishop(ChessColor.White));
        SetPiece(0, 3, new Queen(ChessColor.White));
        SetPiece(0, 4, new King(ChessColor.White));
        SetPiece(0, 5, new Bishop(ChessColor.White));
        SetPiece(0, 6, new Knight(ChessColor.White));
        SetPiece(0, 7, new Rook(ChessColor.White));
        for (int i = 0; i < 8; i++)
        {
            SetPiece(1, i, new Pawn(ChessColor.White));
        }

        // Black pieces
        SetPiece(7, 0, new Rook(ChessColor.Black));
        SetPiece(7, 1, new Knight(ChessColor.Black));
        SetPiece(7, 2, new Bishop(ChessColor.Black));
        SetPiece(7, 3, new Queen(ChessColor.Black));
        SetPiece(7, 4, new King(ChessColor.Black));
        SetPiece(7, 5, new Bishop(ChessColor.Black));
        SetPiece(7, 6, new Knight(ChessColor.Black));
        SetPiece(7, 7, new Rook(ChessColor.Black));
        for (int i = 0; i < 8; i++)
        {
            SetPiece(6, i, new Pawn(ChessColor.Black));
        }
    }

    public void Draw()
    {
        Console.Clear();

        // Draw column labels
        Console.Write("");
        for (int col = 0; col < BoardSize; col++)
        {
            Console.Write($" {col + 1} ");
        }
        Console.WriteLine();

        // Draw board and row labels
        for (int row = 0; row < BoardSize; row++)
        {
            Console.Write($"{row + 1} ");
            for (int col = 0; col < BoardSize; col++)
            {
                ConsoleColor bgColor = (row + col) % 2 == 0 ? backgroundColor1 : backgroundColor2;
                Console.BackgroundColor = bgColor;

                Piece piece = GetPiece(row, col);
                if (piece != null)
                {
                    ConsoleColor fgColor = piece.Color == ChessColor.White ? ConsoleColor.White : ConsoleColor.Black;
                    Console.ForegroundColor = fgColor;
                    Console.Write($" {piece.Symbol} ");
                }
                else
                {
                    Console.Write("   ");
                }
            }
            Console.ResetColor();
            Console.WriteLine();
        }
    }

    public void MovePiece(Move move)
    {
        Piece piece = GetPiece(move.From.Row, move.From.Col);
        SetPiece(move.From.Row, move.From.Col, null);
        SetPiece(move.To.Row, move.To.Col, piece);
    }

    public bool IsCheck(ChessColor color)
    {
        // TODO: Implement checking for whether the given color is in check
        return false;
    }

    public bool IsCheckmate(ChessColor color)
    {
        // TODO: Implement checking for whether the given color is in checkmate
        return false;
    }

    public bool IsStalemate(ChessColor color)
    {
        // TODO: Implement checking for whether the given color is in stalemate
        return false;
    }
}

