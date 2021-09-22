using System;
using System.Linq;

namespace CPF.Components
{
    public class TextBoxComponent : MouseInput
    {
        private ConsoleColor Color { get; set; }

        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
                Data.OutPutBuffer();
            }
        }

        private string text;

        private int Height { get; set; }

        private int PosY { get; set; }

        private int Width { get; set; }

        private int PosX { get; set; }
        private int TempTextLength { get; set; }
        
        public TextBoxComponent(int posX, int posY, int width, int height, ConsoleColor color, string text)
        {
            PosX = posX;
            PosY = posY;
            Width = width;
            Height = height;
            Color = color;
            Text = text;

            Draw();
        }

        public void Draw()
        {
            for (int y = PosY; y < Height + PosY; y++)
            {
                for (int x = PosX; x < Width + PosX; x++)
                {
                    Data.ColorBuffer[x, y] = Color;
                }
            }

            for (int i = PosX + 2; i < TempTextLength + PosX + 2; i++)
                Data.Buffer[i, PosY] = ' ';
            
            for (int i = PosX + 2; i < Text.Length + PosX + 2; i++)
                Data.Buffer[i, PosY] = Text[i - PosX - 2];

            TempTextLength = Text.Length;
        }

        public override void OnComponentClicked(NativeMethods.MOUSE_EVENT_RECORD r)
        {
            if (PositionCheck(PosX, PosY, r.dwMousePosition.X, r.dwMousePosition.Y, Width, Height))
            {
                Text = "";
                while (true)
                {
                    var input = Console.ReadKey(true);
                    char character = input.KeyChar;
                    if (input.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                    else if (input.Key == ConsoleKey.Backspace)
                    {
                        var remove = Text.Remove(Text.Length - 1);
                        Text = remove;
                        Draw();
                    }
                    else
                    {
                        Text += character;
                        Draw();
                    }
                }
            }
        }
    }
}