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
    class Ball 
    {
        public int X;
        public int Y;
        public Bitmap BallTexture = Resource1.Wall;
        public char Direct;
        public Ball(int x, int y, char d)
        {
            X = x;
            Y = y;
            Direct = d;
        }
        public void DrawSpace(Field Matrix, Ball MyBall)
        {
                    Field.Cell[MyBall.Y, MyBall.X].symbol = Resource1.Без_названия;
                
        }
        public void DrawBall(Ball MyBall)
        {
                    Field.Cell[MyBall.Y, MyBall.X].symbol = Resource1.ball;
        }

        public void Move(Field Matrix, Ball MyBall)
        {          
            if (Direct == 'R' && !Field.Cell[MyBall.Y, MyBall.X + 1].IsWall)
            {
                DrawSpace(Matrix, MyBall);
                MoveRight();
            }
            if (Direct == 'L' && !Field.Cell[MyBall.Y, MyBall.X - 1].IsWall)
            {
                DrawSpace(Matrix, MyBall);
                MoveLeft();
            }
            if (Direct == 'U' && !Field.Cell[MyBall.Y - 1, MyBall.X].IsWall)
            {
                DrawSpace(Matrix, MyBall);
                MoveUp();
            }
            if (Direct == 'D' && !Field.Cell[MyBall.Y + 1, MyBall.X].IsWall)
            {
                DrawSpace(Matrix, MyBall);
                MoveDown();
            }
            DrawBall(MyBall);
            WallBounce(MyBall);
        }
        public void MoveUp()
        {
            Y--;
        }
        public void MoveDown()
        {
            Y++;
        }
        public void MoveLeft()
        {
            X--;
        }
        public void MoveRight()
        {
            X++;
        }  
        public void WallBounce(Ball MyBall)
        {
            if (Direct == 'L' && Field.Cell[MyBall.Y, MyBall.X - 1].IsWall)
                Direct = 'R';
            if (Direct == 'R' && Field.Cell[MyBall.Y, MyBall.X + 1].IsWall)
                Direct = 'L';
            if (Direct == 'U' && Field.Cell[MyBall.Y - 1, MyBall.X].IsWall)
                Direct = 'D';
            if (Direct == 'D' && Field.Cell[MyBall.Y + 1, MyBall.X].IsWall)
                Direct = 'U';
        }     
    }
}