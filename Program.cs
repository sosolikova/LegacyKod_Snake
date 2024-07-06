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

            int berryx = rand.Next(0, screenWidth);
            int berryy = rand.Next(0, screenHeight);

            var time = DateTime.Now;
            var time2 = DateTime.Now;

            var movement = "RIGHT";
            string buttonpressed = "no";


            while (true)
            {
                Clear();
                if (hoofd.xPos == screenWidth - 1 || hoofd.xPos == 0 || hoofd.yPos == screenHeight - 1 || hoofd.yPos == 0)
                {
                    gameover = 1;
                }
                for (int i = 0; i < screenWidth; i++)
                {
                    SetCursorPosition(i, 0);
                    Write("■");
                }
                for (int i = 0; i < screenWidth; i++)
                {
                    SetCursorPosition(i, screenHeight - 1);
                    Write("■");
                }
                for (int i = 0; i < screenHeight; i++)
                {
                    SetCursorPosition(0, i);
                    Write("■");
                }
                for (int i = 0; i < screenHeight; i++)
                {
                    SetCursorPosition(screenWidth - 1, i);
                    Write("■");
                }
                ForegroundColor = ConsoleColor.Green;
                if (berryx == hoofd.xPos && berryy == hoofd.yPos)
                {
                    score++;
                    berryx = rand.Next(1, screenWidth - 2);
                    berryy = rand.Next(1, screenHeight - 2);
                }
                for (int i = 0; i < xPosBody.Count(); i++)
                {
                    SetCursorPosition(xPosBody[i], yPosBody[i]);
                    Write("■");
                    if (xPosBody[i] == hoofd.xPos && yPosBody[i] == hoofd.yPos)
                    {
                        gameover = 1;
                    }
                }
                if (gameover == 1)
                {
                    break;
                }
                SetCursorPosition(hoofd.xPos, hoofd.yPos);
                ForegroundColor = hoofd.ScreenColor;
                Write("■");
                SetCursorPosition(berryx, berryy);
                ForegroundColor = ConsoleColor.Cyan;
                Write("■");
                tijd = DateTime.Now;
                buttonpressed = "no";
                while (true)
                {
                    tijd2 = DateTime.Now;
                    if (tijd2.Subtract(tijd).TotalMilliseconds > 500) { break; }
                    if (KeyAvailable)
                    {
                        ConsoleKeyInfo toets = ReadKey(true);
                        //Console.WriteLine(toets.Key.ToString());
                        if (toets.Key.Equals(ConsoleKey.UpArrow) && movement != "DOWN" && buttonpressed == "no")
                        {
                            movement = "UP";
                            buttonpressed = "yes";
                        }
                        if (toets.Key.Equals(ConsoleKey.DownArrow) && movement != "UP" && buttonpressed == "no")
                        {
                            movement = "DOWN";
                            buttonpressed = "yes";
                        }
                        if (toets.Key.Equals(ConsoleKey.LeftArrow) && movement != "RIGHT" && buttonpressed == "no")
                        {
                            movement = "LEFT";
                            buttonpressed = "yes";
                        }
                        if (toets.Key.Equals(ConsoleKey.RightArrow) && movement != "LEFT" && buttonpressed == "no")
                        {
                            movement = "RIGHT";
                            buttonpressed = "yes";
                        }
                    }
                }
                xPosBody.Add(hoofd.xPos);
                yPosBody.Add(hoofd.yPos);
                switch (movement)
                {
                    case "UP":
                        hoofd.yPos--;
                        break;
                    case "DOWN":
                        hoofd.yPos++;
                        break;
                    case "LEFT":
                        hoofd.xPos--;
                        break;
                    case "RIGHT":
                        hoofd.xPos++;
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
}
//¦
