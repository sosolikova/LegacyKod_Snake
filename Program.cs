﻿using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using System.Diagnostics;
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

            var berry = new Pixel(rand.Next(1, WindowWidth - 2), rand.Next(1, WindowHeight - 2), ConsoleColor.Cyan);

            var movement = Direction.Right;

            while (true)
            {
                Clear();

                if (head.XPos == WindowWidth - 1 || head.XPos == 0 || head.YPos == WindowHeight - 1 || head.YPos == 0)
                {
                    gameover = true;
                }

                DrawBorder();

                if (berry.XPos == head.XPos && berry.YPos == head.YPos)
                {
                    score++;
                    berry = new Pixel(rand.Next(1, WindowWidth - 2), rand.Next(1, WindowHeight - 2), ConsoleColor.Cyan);
                }

                for (int i = 0; i < body.Count(); i++)
                {
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

                var sw = Stopwatch.StartNew();
                while (sw.ElapsedMilliseconds <= 500)
                {
                    movement = ReadMovement(movement);
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
            WriteLine($"Game over, Score: {score - 5}");
            SetCursorPosition(WindowWidth / 5, WindowHeight / 2 + 1);
            ReadKey();
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

        static Direction ReadMovement(Direction movement)
        {
            if (Console.KeyAvailable)
            {
                var key = ReadKey(true).Key;

                if (key == ConsoleKey.UpArrow && movement !=Direction.Down)
                {
                    movement = Direction.Up;
                }
                if (key == ConsoleKey.DownArrow && movement !=Direction.Up)
                {
                    movement = Direction.Down;
                }
                if (key == ConsoleKey.LeftArrow && movement !=Direction.Right)
                {
                    movement = Direction.Left;
                }
                if (key == ConsoleKey.RightArrow && movement !=Direction.Left)
                {
                    movement = Direction.Right;
                }
            }
            return movement;
        }
    }  
}

