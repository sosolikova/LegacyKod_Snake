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
        static void Main(string[] args)
        {
            WindowHeight = 16;
            WindowWidth = 32;

            var screenWidth = WindowWidth;
            var screenHeight = WindowHeight;

            var rand = new Random();

            var score = 5;
            var gameover = 0;

            var head = new Pixel(screenWidth / 2, screenHeight / 2, ConsoleColor.Red);

            var xPosBody = new List<int>();
            var yPosBody = new List<int>();

            var xPosBerry = rand.Next(0, screenWidth);
            var yPosBerry = rand.Next(0, screenHeight);

            var time = DateTime.Now;
            var time2 = DateTime.Now;

            var movement = "RIGHT";
            var buttonPressed = "no";

            while (true)
            {
                Clear();
                if (head.XPos == screenWidth - 1 || head.XPos == 0 || head.YPos == screenHeight - 1 || head.YPos == 0)
                {
                    gameover = 1;
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
                    SetCursorPosition(xPosBody[i], yPosBody[i]);
                    Write("■");
                    if (xPosBody[i] == head.XPos && yPosBody[i] == head.YPos)
                    {
                        gameover = 1;
                    }
                }
                if (gameover == 1)
                {
                    break;
                }
                SetCursorPosition(head.XPos, head.YPos);
                ForegroundColor = head.ScreenColor;
                Write("■");

                SetCursorPosition(xPosBerry, yPosBerry);
                ForegroundColor = ConsoleColor.Cyan;
                Write("■");

                time = DateTime.Now;
                buttonPressed = "no";
                while (true)
                {
                    time2 = DateTime.Now;
                    if (time2.Subtract(time).TotalMilliseconds > 500) { break; }
                    if (KeyAvailable)
                    {
                        ConsoleKeyInfo toets = ReadKey(true);
                        //Console.WriteLine(toets.Key.ToString());
                        if (toets.Key.Equals(ConsoleKey.UpArrow) && movement != "DOWN" && buttonPressed == "no")
                        {
                            movement = "UP";
                            buttonPressed = "yes";
                        }
                        if (toets.Key.Equals(ConsoleKey.DownArrow) && movement != "UP" && buttonPressed == "no")
                        {
                            movement = "DOWN";
                            buttonPressed = "yes";
                        }
                        if (toets.Key.Equals(ConsoleKey.LeftArrow) && movement != "RIGHT" && buttonPressed == "no")
                        {
                            movement = "LEFT";
                            buttonPressed = "yes";
                        }
                        if (toets.Key.Equals(ConsoleKey.RightArrow) && movement != "LEFT" && buttonPressed == "no")
                        {
                            movement = "RIGHT";
                            buttonPressed = "yes";
                        }
                    }
                }
                xPosBody.Add(head.XPos);
                yPosBody.Add(head.YPos);
                switch (movement)
                {
                    case "UP":
                        head.YPos--;
                        break;
                    case "DOWN":
                        head.YPos++;
                        break;
                    case "LEFT":
                        head.XPos--;
                        break;
                    case "RIGHT":
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
