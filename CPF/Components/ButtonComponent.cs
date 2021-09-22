using System;

namespace CPF.Components
{
    public class ButtonComponent : MouseInput
    {
        private int Width { get; set; }
        private int Height { get; set; }
        private int PosX { get; set; }
        private int PosY { get; set; }
        private int MousePosX { get; set; }
        private int MousePosY { get; set; }
        private ConsoleColor Color { get; set; }
        private ConsoleColor HoverColor { get; set; }
        private ConsoleColor CurrentColor { get; set; }
        private string Text { get; set; }
        private delegate void ButtonOperation();

        private ButtonOperation _buttonClickOperation;
        private ButtonOperation _buttonHoverOperation;
        private bool breakLoop = false;

        public ButtonComponent(int posX, int posY, int width, int height, ConsoleColor color, string text, Action buttonClickMethod, ConsoleColor hoverColor)
        {
            Width = width;
            Height = height;
            PosX = posX - 1;
            PosY = posY;
            HoverColor = hoverColor;
            Color = color;
            CurrentColor = color;
            Text = text;
            
            _buttonClickOperation = new ButtonOperation(buttonClickMethod);

            Draw();
        }

        public void Draw()
        {
            for (int y = PosY; y < Height + PosY; y++)
            {
                for (int x = PosX; x < Width + PosX; x++)
                {
                    Data.ColorBuffer[x, y] = CurrentColor;
                }
            }

            for (int i = PosX + 2; i < Text.Length + PosX + 2; i++)
                Data.Buffer[i, PosY + 1] = Text[i - PosX - 2];
        }
        public override void OnButtonClicked(NativeMethods.MOUSE_EVENT_RECORD r)
        {
            MousePosX = r.dwMousePosition.X;
            MousePosY = r.dwMousePosition.Y;

            if (PositionCheck(MousePosX, MousePosY)) 
                _buttonClickOperation?.Invoke();
        }

        public override void OnButtonHover(NativeMethods.MOUSE_EVENT_RECORD r)
        {
            MousePosX = r.dwMousePosition.X;
            MousePosY = r.dwMousePosition.Y;

            if (PositionCheck(MousePosX, MousePosY))
            {
                CurrentColor = HoverColor;
            }
            else
            {
                CurrentColor = Color;
            }
            
            Draw();
            
            Data.OutPutBuffer();
        }

        private bool PositionCheck(int posX, int posY)
        {
            for (int y = PosY; y < Height + PosY; y++)
            {
                for (int x = PosX + 1; x < Width + PosX + 1; x++)
                {
                    if (posX == x && posY == y)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
