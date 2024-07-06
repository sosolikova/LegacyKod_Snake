using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using static System.Console;
///█ ■
////https://www.youtube.com/watch?v=SGZgvMwjq2U
namespace Snake
{
    class Program
    {
        enum Direction
        {
            Up,
            Down,
            Right,
            Left
        }

        static void Main(string[] args)
        {
            WindowHeight = 16;
            WindowWidth = 32;

            var rand = new Random();

            var score = 5;
            var gameover = false;

            var head = new Pixel(WindowWidth / 2, WindowHeight / 2, ConsoleColor.Red);
            var body = new List<Pixel>();

            var berry = new Pixel(rand.Next(1, WindowWidth - 2),rand.Next(1,WindowHeight - 2), ConsoleColor.Cyan);

            var time = DateTime.Now;
            var time2 = DateTime.Now;

            var movement = Direction.Right;
            var buttonPressed = false;

            while (true)
            {
                Clear();
                if (head.XPos == WindowWidth - 1 || head.XPos == 0 || head.YPos == WindowHeight - 1 || head.YPos == 0)
                {
                    gameover = true;
                }

                DrawBorder();

                ForegroundColor = ConsoleColor.Green;
                if (berry.XPos == head.XPos && berry.YPos == head.YPos)
                {
                    score++;
                    berry = new Pixel(rand.Next(1, WindowWidth - 2), rand.Next(1, WindowHeight - 2), ConsoleColor.Cyan);
                }

                for (int i = 0; i < body.Count(); i++)
                {
                    //var bodyPixel = new Pixel(body[i].XPos, body[i].YPos, ConsoleColor.Green);
                    DrawPixel(body[i]);
                    if (body[i].XPos == head.XPos && body[i].YPos == head.YPos)
                    {
                        gameover = true;
                    }
                }
                if (gameover)
                {
                    break;
                }
                
                DrawPixel(head);
                DrawPixel(berry);

                time = DateTime.Now;
                buttonPressed = false;
                while (true)
                {
                    time2 = DateTime.Now;
                    if (time2.Subtract(time).TotalMilliseconds > 500) { break; }
                    if (KeyAvailable)
                    {
                        ConsoleKeyInfo toets = ReadKey(true);
                        //Console.WriteLine(toets.Key.ToString());
                        if (toets.Key.Equals(ConsoleKey.UpArrow) && movement != Direction.Down && !buttonPressed)
                        {
                            movement = Direction.Up;
                            buttonPressed = true;
                        }
                        if (toets.Key.Equals(ConsoleKey.DownArrow) && movement != Direction.Up && !buttonPressed)
                        {
                            movement = Direction.Down;
                            buttonPressed = true;
                        }
                        if (toets.Key.Equals(ConsoleKey.LeftArrow) && movement != Direction.Right && !buttonPressed)
                        {
                            movement = Direction.Left;
                            buttonPressed = true;
                        }
                        if (toets.Key.Equals(ConsoleKey.RightArrow) && movement != Direction.Left && !buttonPressed)
                        {
                            movement = Direction.Right;
                            buttonPressed = true;
                        }
                    }
                }
                body.Add(new Pixel(head.XPos, head.YPos, ConsoleColor.Green));
                switch (movement)
                {
                    case Direction.Up:
                        head.YPos--;
                        break;
                    case Direction.Down:
                        head.YPos++;
                        break;
                    case Direction.Left:
                        head.XPos--;
                        break;
                    case Direction.Right:
                        head.XPos++;
                        break;
                }
                if (body.Count() > score)
                {
                    body.RemoveAt(0);
                }
            }
            SetCursorPosition(WindowWidth / 5, WindowHeight / 2);
            WriteLine("Game over, Score: " + score);
            SetCursorPosition(WindowWidth / 5, WindowHeight / 2 + 1);
        }

        static void DrawBorder()
        {
            for (int i = 0; i < WindowWidth; i++)
            {
                SetCursorPosition(i, 0);
                Write("■");

                SetCursorPosition(i, WindowHeight - 1);
                Write("■");

            }

            for (int i = 0; i < WindowHeight; i++)
            {
                SetCursorPosition(0, i);
                Write("■");

                SetCursorPosition(WindowWidth - 1, i);
                Write("■");
            }
        }

        static void DrawPixel(Pixel pixel)
        {
            SetCursorPosition(pixel.XPos, pixel.YPos);
            ForegroundColor = pixel.ScreenColor;
            Write("■");
        }
    }

    class Pixel
    {
        public Pixel (int xPos, int yPos, ConsoleColor color)
        {
            XPos = xPos;
            YPos = yPos;
            ScreenColor = color;
        }

        public int XPos { get; set; }
        public int YPos { get; set; }
        public ConsoleColor ScreenColor { get; set; }
       
    }
}
//¦
