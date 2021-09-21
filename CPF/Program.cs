using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace CPF
{
    public class Program
    {
        public static void Main()
        {
            Console.CursorVisible = false;
            IntPtr inHandle = NativeMethods.GetStdHandle(NativeMethods.STD_INPUT_HANDLE);
            uint mode = 0;
            NativeMethods.GetConsoleMode(inHandle, ref mode);
            mode &= ~NativeMethods.ENABLE_QUICK_EDIT_MODE; //disable
            mode |= NativeMethods.ENABLE_WINDOW_INPUT; //enable (if you want)
            mode |= NativeMethods.ENABLE_MOUSE_INPUT; //enable
            NativeMethods.SetConsoleMode(inHandle, mode);

            ConsoleListener.Start();

            MouseInput mainWindow = new MainWindow();
        }
    }
}