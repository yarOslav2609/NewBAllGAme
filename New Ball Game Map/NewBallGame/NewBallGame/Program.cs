using System;

namespace NewBallGame
{
    class Program
    {
        struct Cell
        {
            public string sym { set; get; }
            public string color { set; get; }
            public Cell(string Sym = "  ", string Color = "none")
            {
                sym = Sym;

                switch (sym)
                {
                    case ". ":
                        color = "cyan";
                        break;
                    case "@ ":
                        color = "yellow";
                        break;
                    case "# ":
                        color = "red";
                        break;
                    case "/ ":
                    case "\\ ":
                        color = "blue";
                        break;
                    default:
                        color = "none";
                        break;
                }

                if (Color != "None")
                {
                    color = Color;
                }
            }            
            public void Draw()
            {
                switch (this.color)
                {
                    case "none":
                        break;
                    case "cyan":
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        break;
                    case "red":
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case "blue":
                        Console.ForegroundColor = ConsoleColor.Blue;
                        break;
                    case "yellow":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
                Console.Write(this.sym);
            }
        }

        class Map
        {
            public int Height { get; }
            public int Width { get; }
            public Cell[,] map = new Cell[30, 30];
            public Map(int height = 0, int width = 0)
            {
                Height = height;
                Width = width;
            }
            public Cell this[int i, int j]
            {
                set { map[i, j] = value; }
                get { return map[i, j]; }
            }
            public void GenerateMap()
            {
                Random rnd = new Random();
                for (int row = 0; row < Height; row++)
                {
                    for (int col = 0; col < Width; col++)
                    {
                        int ran = rnd.Next(100);
                        map[row, col].sym = "  ";
                        map[row, col].color = "none";
                        if (ran > 80)
                        {
                            map[row, col].sym = "# ";
                            map[row, col].color = "red";
                        }
                        if (ran > 90)
                        {
                            map[row, col].sym = "@ ";
                            map[row, col].color = "yellow";
                        }    
                    }
                }
                int xp = rnd.Next(this.Height);
                int yp = rnd.Next(this.Width);
                while (map[xp, yp].sym != "  ")
                {
                    xp = rnd.Next(this.Height);
                    yp = rnd.Next(this.Width);
                }
                map[xp, yp].sym = ". ";
                map[xp, yp].color = "cyan";
            }
            public void Draw()
            {
                for (int row = 0; row < Height; row++)
                {
                    for (int col = 0; col < Width; col++)
                    {
                        map[row, col].Draw();
                    }
                    Console.WriteLine();
                }
            }
        }

        static void Main(string[] args)
        {
            int height, width, counter1 = 0, counter2 = 0;
            string elemToCount;
            Console.WriteLine("Enter Height: ");
            height = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Width: ");
            width = Convert.ToInt32(Console.ReadLine());
            Map map = new Map(height, width);
            map.GenerateMap();
            map.Draw();
            Console.WriteLine("Enter the item you want to count: ");
            elemToCount = Console.ReadLine();
            switch (elemToCount)
            {
                case " ":
                    elemToCount = "  ";
                    break;
                case "#":
                    elemToCount = "# ";
                    break;
                case ".":
                    elemToCount = ". ";
                    break;
                case "@":
                    elemToCount = "@ ";
                    break;
                default:
                    break;
            }
            int col = 0, row = 0;
            for (row = 0; row < map.Height; row++)
            {
                if (map[row, col].sym == elemToCount)
                    counter1++;
            }
            col = map.Height - 1;            
            for (row = 0; row < map.Height; row++)
            {
                if (map[row, col].sym == elemToCount)
                    counter2++;
            }
            Console.WriteLine("In \"\\\" diagonal: {0} elements \"{2}\",\nIn \"/\" diagonal: {1} elements \"{2}\"", counter1, counter2, elemToCount);
            Console.ReadKey();
        }
    }
}
