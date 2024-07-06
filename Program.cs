using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
///█ ■
////https://www.youtube.com/watch?v=SGZgvMwjq2U
namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowHeight = 16;
            Console.WindowWidth = 32;

            var screenWidth = Console.WindowWidth;
            var screenHeight = Console.WindowHeight;

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
                Console.Clear();
                if (hoofd.xPos == screenWidth - 1 || hoofd.xPos == 0 || hoofd.yPos == screenHeight - 1 || hoofd.yPos == 0)
                {
                    gameover = 1;
                }
                for (int i = 0; i < screenWidth; i++)
                {
                    Console.SetCursorPosition(i, 0);
                    Console.Write("■");
                }
                for (int i = 0; i < screenWidth; i++)
                {
                    Console.SetCursorPosition(i, screenHeight - 1);
                    Console.Write("■");
                }
                for (int i = 0; i < screenHeight; i++)
                {
                    Console.SetCursorPosition(0, i);
                    Console.Write("■");
                }
                for (int i = 0; i < screenHeight; i++)
                {
                    Console.SetCursorPosition(screenWidth - 1, i);
                    Console.Write("■");
                }
                Console.ForegroundColor = ConsoleColor.Green;
                if (berryx == hoofd.xPos && berryy == hoofd.yPos)
                {
                    score++;
                    berryx = rand.Next(1, screenWidth - 2);
                    berryy = rand.Next(1, screenHeight - 2);
                }
                for (int i = 0; i < xposlijf.Count(); i++)
                {
                    Console.SetCursorPosition(xposlijf[i], yposlijf[i]);
                    Console.Write("■");
                    if (xposlijf[i] == hoofd.xPos && yposlijf[i] == hoofd.yPos)
                    {
                        gameover = 1;
                    }
                }
                if (gameover == 1)
                {
                    break;
                }
                Console.SetCursorPosition(hoofd.xPos, hoofd.yPos);
                Console.ForegroundColor = hoofd.ScreenColor;
                Console.Write("■");
                Console.SetCursorPosition(berryx, berryy);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("■");
                tijd = DateTime.Now;
                buttonpressed = "no";
                while (true)
                {
                    tijd2 = DateTime.Now;
                    if (tijd2.Subtract(tijd).TotalMilliseconds > 500) { break; }
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo toets = Console.ReadKey(true);
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
                xposlijf.Add(hoofd.xPos);
                yposlijf.Add(hoofd.yPos);
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
                if (xposlijf.Count() > score)
                {
                    xposlijf.RemoveAt(0);
                    yposlijf.RemoveAt(0);
                }
            }
            Console.SetCursorPosition(screenWidth / 5, screenHeight / 2);
            Console.WriteLine("Game over, Score: " + score);
            Console.SetCursorPosition(screenWidth / 5, screenHeight / 2 + 1);
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
