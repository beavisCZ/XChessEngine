using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XChessUCI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Universal chess interface (UCI) for XChess Engine");
            Console.WriteLine("version: 0.1");
            Console.WriteLine("type uci for engine initialization");

            UCI engine = new UCI();
            Console.Title = "XChess Engine (C)2021 by Martin Kaspar";
            while (true)
            {
                engine.input(Console.ReadLine());
            }
        }
    }
}
