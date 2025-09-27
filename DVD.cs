using System;
using System.Numerics;
using Raylib_cs;

namespace dvd
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Raylib.InitWindow(800, 450, "DVD Bouncer");
            Raylib.SetTargetFPS(60);

            Vector2 position = new Vector2(100, 100);
            Vector2 direction = new Vector2(1, 1);   // start moving diagonally
            float speed = 200.0f;

            Font font = Raylib.GetFontDefault();
            string text = "DVD";
            float fontSize = 40.0f;
            float spacing = 2.0f;
            Vector2 textSize = Raylib.MeasureTextEx(font, text, fontSize, spacing);

            while (!Raylib.WindowShouldClose())
            {
                float delta = Raylib.GetFrameTime();

                // se liikkuu!!
                position += direction * speed * delta;

                int width = Raylib.GetScreenWidth();
                int height = Raylib.GetScreenHeight();

                // Bojojoing
                if (position.X + textSize.X >= width)
                {
                    position.X = width - textSize.X;
                    direction.X *= -1;
                }
                if (position.X <= 0)
                {
                    position.X = 0;
                    direction.X *= -1;
                }

                if (position.Y + textSize.Y >= height)
                {
                    position.Y = height - textSize.Y;
                    direction.Y *= -1;
                }
                if (position.Y <= 0)
                {
                    position.Y = 0;
                    direction.Y *= -1;
                }

                // OMG Värejä!?!
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.BLACK);
                Raylib.DrawTextEx(font, text, position, fontSize, spacing, Color.YELLOW);
                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }
    }
}