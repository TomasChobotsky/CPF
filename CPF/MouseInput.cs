using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CPF
{
    public class MouseInput
    {
        public MouseInput()
        {
            Console.CursorVisible = false;
            IntPtr inHandle = NativeMethods.GetStdHandle(NativeMethods.STD_INPUT_HANDLE);
            uint mode = 0;
            NativeMethods.GetConsoleMode(inHandle, ref mode);
            mode &= ~NativeMethods.ENABLE_QUICK_EDIT_MODE;
            mode |= NativeMethods.ENABLE_WINDOW_INPUT;
            mode |= NativeMethods.ENABLE_MOUSE_INPUT;
            NativeMethods.SetConsoleMode(inHandle, mode);
            ConsoleListener.Start();

            ConsoleListener.LeftMouseClickEvent += OnLeftMouseClicked;
            ConsoleListener.ComponentClickEvent += OnComponentClicked;
            ConsoleListener.ButtonHoverEvent += OnButtonHover;


        }

        public virtual void OnLeftMouseClicked(NativeMethods.MOUSE_EVENT_RECORD r)
        {
        }
        public virtual void OnRightMouseClicked(NativeMethods.MOUSE_EVENT_RECORD r)
        {
        }
        public virtual void OnComponentClicked(NativeMethods.MOUSE_EVENT_RECORD r)
        {
        }
        public virtual void OnButtonHover(NativeMethods.MOUSE_EVENT_RECORD r)
        {
        }
        public bool PositionCheck(int posX, int posY, int mousePosX, int mousePosY, int width, int height)
        {
            for (int y = posY; y < height + posY; y++)
            {
                for (int x = posX + 1; x < width + posX + 1; x++)
                {
                    if (x == mousePosX && y == mousePosY)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
