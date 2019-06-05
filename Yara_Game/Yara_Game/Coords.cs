using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yara_Game
{
  abstract class Coords
        {
            public static object locker = new object();
            public int X;
            public int Y;
            public static bool GameStatus { get; set; }
            public virtual void Draw()
            {
                Console.Write("");
            }
            public Coords(int x, int y)
            {
                X = x;
                Y = y;
            }     
    }

}
