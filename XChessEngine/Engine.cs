using System;

namespace XChessEngine
{
    public class Engine
    {
        public string name = "XChess engine";
        public string version = "0.1.a";
        public string author = "Martin Kašpar";

        public const int pawn = 100, knight = 320, bishop = 320, rook = 500, queen = 900, king = 1000000, pawnMove = 2;
        public static int toDepth = 5;
        public static UInt64 nodes = 0;

        public static Board BoardGen()
        {
            Board chessBoard = new Board(new int[8, 8] {
                { rook, knight, bishop, queen, king, bishop, knight, rook },
                { pawn, pawn, pawn, pawn, pawn, pawn, pawn, pawn },
                { 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0 },
                { -pawn, -pawn, -pawn, -pawn, -pawn, -pawn, -pawn, -pawn },
                { -rook, -knight, -bishop, -queen, -king, -bishop, -knight, -rook }}, 0, true, true, true);
            return chessBoard;
        }

        public static Board MoveToBoard(int[] move, Board board)
        {
            int[,] newBoard = new int[8, 8];
            Array.Copy(board.Pieces(), newBoard, 64);
            newBoard[move[3], move[2]] = newBoard[move[1], move[0]];
            newBoard[move[1], move[0]] = 0;
            if (Math.Abs(newBoard[move[3], move[2]]) == king)
            {
                if (move[0] == 4)
                {
                    if (move[2] == 2)
                    {
                        if (Math.Sign(newBoard[move[3], move[2]]) == 1)
                        {
                            newBoard[0, 3] = rook;
                            newBoard[0, 0] = 0;
                        }
                        else
                        {
                            newBoard[7, 3] = -rook;
                            newBoard[7, 0] = 0;
                        }
                    }
                    if (move[2] == 6)
                    {
                        if (Math.Sign(newBoard[move[3], move[2]]) == 1)
                        {
                            newBoard[0, 5] = rook;
                            newBoard[0, 7] = 0;
                        }
                        else
                        {
                            newBoard[7, 5] = -rook;
                            newBoard[7, 7] = 0;
                        }
                    }
                }
                //Console.WriteLine("break");
            }
            if (newBoard[move[3], move[2]] == pawn && move[3] == 7) newBoard[move[3], move[2]] = queen;
            if (newBoard[move[3], move[2]] == -pawn && move[3] == 0) newBoard[move[3], move[2]] = -queen;
            return new Board(newBoard, board.Depth() + 1, !board.IsTurn(), true, true);
        }

    }
}
