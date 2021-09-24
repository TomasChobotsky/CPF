using System;

namespace CPF.Components
{
    public class ButtonComponent : MouseInput
    {
        private ConsoleColor Color { get; set; }
        private ConsoleColor HoverColor { get; set; }
        private ConsoleColor CurrentColor { get; set; }
        private string Text { get; set; }
        private delegate void ButtonOperation();

        private ButtonOperation _buttonClickOperation;
        private ButtonOperation _buttonHoverOperation;
        private bool breakLoop = false;
        private bool colorChanged = false;

        public ButtonComponent(int posX, int posY, int width, int height, ConsoleColor color, string text, Action buttonClickMethod, ConsoleColor hoverColor) 
            : base(posX, posY, width, height)
        {
            HoverColor = hoverColor;
            Color = color;
            CurrentColor = color;
            Text = text;
            
            _buttonClickOperation = new ButtonOperation(buttonClickMethod);
            
            Data.Buttons.Add(this);

            Draw();
            
            Data.ChangeBuffer(TempBuffer, TempColorBuffer, PosX, PosY);
        }

        public void Draw()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    TempColorBuffer[x, y] = CurrentColor;
                }
            }

            
            for (int i = 2; i < Text.Length + 2; i++)
            {
                TempBuffer[i, (int)Math.Ceiling((double)Height / 2) - 1] = Text[i - 2];
            }
        }
        public override void OnComponentClicked(NativeMethods.MOUSE_EVENT_RECORD r)
        {
            if (PositionCheck(PosX, PosY, r.dwMousePosition.X, r.dwMousePosition.Y, Width, Height)) 
                _buttonClickOperation?.Invoke();
        }

        public override void OnButtonHover(NativeMethods.MOUSE_EVENT_RECORD r)
        {
            if (PositionCheck(PosX, PosY, r.dwMousePosition.X, r.dwMousePosition.Y, Width, Height))
            {
                if (CurrentColor == Color)
                    colorChanged = true;
                CurrentColor = HoverColor;
            }
            else
            {
                if (CurrentColor == HoverColor)
                    colorChanged = true;
                CurrentColor = Color;
            }

            if (colorChanged)
            {
                Draw();
                Data.ChangeBuffer(TempBuffer, TempColorBuffer, PosX, PosY);
                colorChanged = false;
            }
        }
    }
}
