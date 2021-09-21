using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF
{
    public class ButtonComponent : MouseInput
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }

        private delegate void ButtonOperation();

        private ButtonOperation _buttonOperation;

        public ButtonComponent(int width, int height, int posX, int posY, Action buttonMethod)
        {
            Width = width;
            Height = height;
            PosX = posX;
            PosY = posY;
            
            _buttonOperation = new ButtonOperation(buttonMethod);

            Draw();
        }

        public void Draw()
        {
            for (int y = PosY; y < Height; y++)
            {
                for (int x = PosX; x < Width; x++)
                {
                    Data.Buffer[x, y] = 'X';
                }
            }
        }
        public override void OnButtonClicked(NativeMethods.MOUSE_EVENT_RECORD r)
        {
            if (r.dwMousePosition.X == PosX && r.dwMousePosition.Y == PosY)
            {
                _buttonOperation?.Invoke();
            }
        }
    }
}
