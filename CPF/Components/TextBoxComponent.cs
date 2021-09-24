using System;
using System.Linq;
using System.Threading;

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
                Draw();
                Data.ChangeBuffer(TempBuffer, TempColorBuffer, PosX, PosY);
            }
        }

        private string text;
        private int TempTextLength { get; set; }
        
        public TextBoxComponent(int posX, int posY, int width, int height, ConsoleColor color, string text) : base(posX, posY, width, height)
        {
            Color = color;
            Text = text;
            TempTextLength = text.Length;
            
            Data.TextBoxes.Add(this);

            Draw();
        }

        public void Draw()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    TempColorBuffer[x, y] = Color;
                }
            }

            for (int i = 2; i < TempTextLength + 2; i++)
                TempBuffer[i, (int)Math.Ceiling((double)Height / 2) - 1] = ' ';
            
            for (int i = 2; i < Text.Length + 2; i++)
            {
                TempBuffer[i, (int)Math.Ceiling((double)Height / 2) - 1] = Text[i - 2];
            }

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
                    else if (input.Key == ConsoleKey.Backspace && Text.Length > 0)
                    {
                        var remove = Text.Remove(Text.Length - 1);
                        Text = remove;
                        Draw();
                    }
                    else
                    {
                        if (Text.Length < Width - 2)
                        {
                            Text += character;
                            Draw();
                        }
                    }
                }
            }
        }
    }
}