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
            ConsoleListener.ButtonClickEvent += OnButtonClicked;
            ConsoleListener.ButtonHoverEvent += OnButtonHover;


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
        public virtual void OnButtonHover(NativeMethods.MOUSE_EVENT_RECORD r)
        {
        }
    }
}
