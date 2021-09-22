using System;

namespace CPF.Components
{
    public class ButtonComponent : MouseInput
    {
        private int Width { get; set; }
        private int Height { get; set; }
        private int PosX { get; set; }
        private int PosY { get; set; }
        private ConsoleColor Color { get; set; }
        private string Text { get; set; }
        private delegate void ButtonOperation();

        private ButtonOperation _buttonOperation;
        private bool breakLoop = false;

        public ButtonComponent(int posX, int posY, int width, int height, ConsoleColor color, string text, Action buttonMethod)
        {
            Width = width;
            Height = height;
            PosX = posX - 1;
            PosY = posY;
            Color = color;
            Text = text;
            
            _buttonOperation = new ButtonOperation(buttonMethod);

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

            for (int i = PosX + 2; i < Text.Length + PosX + 2; i++)
                Data.Buffer[i, PosY + 1] = Text[i - PosX - 2];
        }
        public override void OnButtonClicked(NativeMethods.MOUSE_EVENT_RECORD r)
        {
            for (int y = PosY; y < Height + PosY; y++)
            {
                for (int x = PosX; x < Width + PosX; x++)
                {
                    if (r.dwMousePosition.X == x && r.dwMousePosition.Y == y)
                    {
                        _buttonOperation?.Invoke();
                    }
                }
            }
        }
    }
}
