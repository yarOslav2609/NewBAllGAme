using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;
using System.Media;

namespace Yara_Game
{
    public struct Cell
    {
        public Bitmap symbol { get; set; }
        public bool IsWall { get; set; }
        public bool IsBall { get; set; }
        public bool IsFree { get; set; }
        public Cell(Bitmap Symbol, bool iswall, bool isball, bool isfree)
        {
            symbol = Symbol;
            IsWall = iswall;
            IsBall = isball;
            IsFree = isfree;
        }
        public void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Blue;     
            if (IsFree)
            {
                Console.Write(symbol);
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }

    }
}
