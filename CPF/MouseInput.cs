using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF
{
    public class MouseInput
    {
        public MouseInput()
        {
            ConsoleListener.LeftMouseClickEvent += OnLeftMouseClicked;
            ConsoleListener.OnButtonClicked += OnButtonClicked;
            Data.PropertyChanged += OnPropertyChanged;
        }
        private void DrawWindow()
        {
            for (int y = 0; y < Console.WindowHeight - 1; y++)
            {
                for (int x = 0; x < Console.WindowWidth - 1; x++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(Data.Buffer[x,y]);
                }
            }
        }

        //Could be made virtual in future
        private void OnPropertyChanged()
        {
            DrawWindow();
        }

        public virtual void OnLeftMouseClicked(NativeMethods.MOUSE_EVENT_RECORD r)
        {
        }
        public virtual void OnRightMouseClicked(NativeMethods.MOUSE_EVENT_RECORD r)
        {
        }
        public virtual void OnButtonClicked(NativeMethods.MOUSE_EVENT_RECORD r)
        {
        }
    }
}
