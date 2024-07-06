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

            var screenWidth = WindowWidth;
            var screenHeight = WindowHeight;

            var rand = new Random();

            var score = 5;
            var gameover = false;

            var head = new Pixel(screenWidth / 2, screenHeight / 2, ConsoleColor.Red);

            var xPosBody = new List<int>();
            var yPosBody = new List<int>();

            var xPosBerry = rand.Next(0, screenWidth);
            var yPosBerry = rand.Next(0, screenHeight);
            var berry = new Pixel(xPosBerry, yPosBerry, ConsoleColor.Cyan);

            var time = DateTime.Now;
            var time2 = DateTime.Now;

            var movement = Direction.Right;
            var buttonPressed = false;

            while (true)
            {
                Clear();
                if (head.XPos == screenWidth - 1 || head.XPos == 0 || head.YPos == screenHeight - 1 || head.YPos == 0)
                {
                    gameover = true;
                }

                DrawBorder(screenWidth, screenHeight);

                ForegroundColor = ConsoleColor.Green;
                if (xPosBerry == head.XPos && yPosBerry == head.YPos)
                {
                    score++;
                    xPosBerry = rand.Next(1, screenWidth - 2);
                    yPosBerry = rand.Next(1, screenHeight - 2); 
                }
                for (int i = 0; i < xPosBody.Count(); i++)
                {
                    var bodyPixel = new Pixel(xPosBody[i], yPosBody[i], ConsoleColor.Green);
                    DrawPixel(bodyPixel);
                    if (xPosBody[i] == head.XPos && yPosBody[i] == head.YPos)
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
                xPosBody.Add(head.XPos);
                yPosBody.Add(head.YPos);
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
                if (xPosBody.Count() > score)
                {
                    xPosBody.RemoveAt(0);
                    yPosBody.RemoveAt(0);
                }
            }
            SetCursorPosition(screenWidth / 5, screenHeight / 2);
            WriteLine("Game over, Score: " + score);
            SetCursorPosition(screenWidth / 5, screenHeight / 2 + 1);
        }

        static void DrawBorder(int screenWidth, int screenHeight)
        {
            for (int i = 0; i < screenWidth; i++)
            {
                SetCursorPosition(i, 0);
                Write("■");

                SetCursorPosition(i, screenHeight - 1);
                Write("■");

            }

            for (int i = 0; i < screenHeight; i++)
            {
                SetCursorPosition(0, i);
                Write("■");

                SetCursorPosition(screenWidth - 1, i);
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
