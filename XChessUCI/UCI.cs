using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XChessEngine;

namespace XChessUCI
{
    class UCI
    {
        Board gameBoard;
        Engine engine = new Engine();
        public void input(string inString)
        {
            string[] inCommand = inString.Split(' ');
            switch (inCommand[0])
            {
                case "uci":
                    Console.WriteLine("id name "+engine.name+" "+engine.version);
                    Console.WriteLine("id author "+engine.author);
                    Console.WriteLine("uciok");
                    break;
                case "isready":
                    Console.WriteLine("readyok");
                    break;
                case "ucinewgame":
                    gameBoard = Engine.BoardGen();
                    Console.WriteLine("readyok");
                    break;
                case "position":
                    int f = 0;
                    if (inCommand[1] == "startpos")
                    {
                        gameBoard = Engine.BoardGen();
                    }
                    else if (inCommand[1] == "fen")
                    {
                        gameBoard = fenToBoard(inCommand[2], inCommand[3], inCommand[4], inCommand[5]);
                        f = 6;
                    }
                    if (inCommand.Count() > 2 + f)
                        if (inCommand[2 + f] == "moves")
                        {
                            for (int i = 3 + f; i < inCommand.Count(); i++)
                            {
                                gameBoard = Engine.MoveToBoard(coordToMove(inCommand[i]), gameBoard);
                            }
                            // add code for side detection
                            gameBoard.SetDepth(0);
                        }
                    break;
                default:
                    Console.WriteLine("unknown command "+inCommand[0]);
                    break;

            }
        }

        public static int[] coordToMove(string input)
        {
            int[] move = new int[5];
            for (int i = 0; i < 4; i++)
            {
                switch (input[i])
                {
                    case 'a':
                        move[i] = 0;
                        break;
                    case 'b':
                        move[i] = 1;
                        break;
                    case 'c':
                        move[i] = 2;
                        break;
                    case 'd':
                        move[i] = 3;
                        break;
                    case 'e':
                        move[i] = 4;
                        break;
                    case 'f':
                        move[i] = 5;
                        break;
                    case 'g':
                        move[i] = 6;
                        break;
                    case 'h':
                        move[i] = 7;
                        break;
                    case '1':
                        move[i] = 7;
                        break;
                    case '2':
                        move[i] = 6;
                        break;
                    case '3':
                        move[i] = 5;
                        break;
                    case '4':
                        move[i] = 4;
                        break;
                    case '5':
                        move[i] = 3;
                        break;
                    case '6':
                        move[i] = 2;
                        break;
                    case '7':
                        move[i] = 1;
                        break;
                    case '8':
                        move[i] = 0;
                        break;
                }
            }
            return move;
        }
        public static Board fenToBoard(string fen, string turn, string castle, string enPassant)
        {
            //string[] fenString = fen.Split('/');
            int x = 0;
            int y = 0;
            int[,] pieces = new int[8, 8];
            foreach (char piece in fen)
                switch (piece)
                {
                    case 'r':
                        pieces[y, x] = Engine.rook;
                        x++;
                        break;
                    case 'n':
                        pieces[y, x] = Engine.knight;
                        x++;
                        break;
                    case 'b':
                        pieces[y, x] = Engine.bishop;
                        x++;
                        break;
                    case 'q':
                        pieces[y, x] = Engine.queen;
                        x++;
                        break;
                    case 'k':
                        pieces[y, x] = Engine.king;
                        x++;
                        break;
                    case 'p':
                        pieces[y, x] = Engine.pawn;
                        x++;
                        break;
                    case 'R':
                        pieces[y, x] = -Engine.rook;
                        x++;
                        break;
                    case 'N':
                        pieces[y, x] = -Engine.knight;
                        x++;
                        break;
                    case 'B':
                        pieces[y, x] = -Engine.bishop;
                        x++;
                        break;
                    case 'Q':
                        pieces[y, x] = -Engine.queen;
                        x++;
                        break;
                    case 'K':
                        pieces[y, x] = -Engine.king;
                        x++;
                        break;
                    case 'P':
                        pieces[y, x] = -Engine.pawn;
                        x++;
                        break;
                    case '/':
                        y++;
                        x = 0;
                        break;
                    default:
                        x += Convert.ToInt32(piece.ToString());
                        break;
                }
            bool Bcastle = false, Wcastle = false;
            if (castle == "")
            {

            }
            else
            {

            }
            bool isTurn = (turn == "w");
            return new Board(pieces, 0, isTurn, Bcastle, Wcastle);
        }
    }
}
