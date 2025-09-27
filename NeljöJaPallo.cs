using System;
using System.Numerics;
using Raylib_cs;

namespace NeljöjaPallo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Raylib.InitWindow(800, 450, "Boxes and Collision");
            Raylib.SetTargetFPS(60);

            Vector2 rectPos = new Vector2(300, 150);
            Vector2 rectSize = new Vector2(300, 200);

            Vector2 circlePos = new Vector2(0, 0);
            Vector2 circleDir = new Vector2(1, 1);
            float circleSpeed = 200;
            float circleRadius = 10;

            while (!Raylib.WindowShouldClose())
            {
                float delta = Raylib.GetFrameTime();

                circlePos += circleDir * circleSpeed * delta;

                Rectangle rect = new Rectangle(rectPos.X, rectPos.Y, rectSize.X, rectSize.Y);

                if (Raylib.CheckCollisionPointRec(circlePos, rect))
                {
                    circleDir *= -1;
                }

                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.Black);

                Raylib.DrawRectangleV(rectPos, rectSize, Color.Yellow);

                Raylib.DrawCircleV(circlePos, circleRadius, Color.Red);

                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }
    }
}