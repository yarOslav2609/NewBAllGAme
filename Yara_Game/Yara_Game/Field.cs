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
    class Field 
    {
        public static Cell[,] Cell;
        public static int Size_ { get; set; }
        public Field()
        {
            Cell = new Cell[12, 22];
        }
        public void SetBorder()
        {
            for (int i = 0; i <12; i++)
            {
                for (int j = 0; j < 22; j++)
                {
                    if (i == 0 || i == 11 || j == 0 || j == 21)
                    {
                        Cell[i, j].IsWall = true;
                        Cell[i, j].symbol = Resource1.Wall;
                    }
                }
            }
        }
        public void SetSpaces()
        {
            for (int y = 0; y < 12; y++)
            {
                for (int x = 0; x < 22; x++)
                {
                    if (!Cell[y, x].IsWall)
                    {
                        Cell[y, x].symbol = Resource1.Без_названия;
                        Cell[y, x].IsWall = false;
                        Cell[y, x].IsFree = true;
                    }
                }
            }
        }
        public Bitmap this[int x, int y]
        {
            get
            {
                return Cell[y, x].symbol;
            }
        }

        public void generate()
        {
            SetBorder();
            SetSpaces();
        }
    }
}