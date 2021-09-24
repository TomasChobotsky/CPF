using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using CPF.Components;

namespace CPF
{
    public static class Data
    {
        public static List<ButtonComponent> Buttons { get; set; } = new List<ButtonComponent>();
        public static List<TextBoxComponent> TextBoxes { get; set; } = new List<TextBoxComponent>();

        public static int UIBufferWidth 
        {
            get { return uiBufferWidth;}
            set
            {
                uiBufferWidth = value;
                ColorBuffer = new ConsoleColor[UIBufferWidth, UIBufferHeight];
                Buffer = new char[UIBufferWidth, UIBufferHeight];
            }
        }

        public static int UIBufferHeight
        {
            get { return uiBufferHeight;}
            set
            {
                uiBufferHeight = value;
                ColorBuffer = new ConsoleColor[UIBufferWidth, UIBufferHeight];
                Buffer = new char[UIBufferWidth, UIBufferHeight];
            }
        }
        private static int uiBufferWidth;
        private static int uiBufferHeight;
        
        public static ConsoleColor[,] ColorBuffer { get; set; }
        public static char[,] Buffer { get; set; }

        public static void ChangeBuffer(char[,] buffer, ConsoleColor[,] colorBuffer, int posX, int posY)
        {
            for (int y = 0; y < buffer.GetLength(1); y++)
            {
                for (int x = 0; x < buffer.GetLength(0); x++)
                {
                    Buffer[x + posX, y + posY] = buffer[x, y];
                    ColorBuffer[x + posX, y + posY] = colorBuffer[x, y];
                }
            }
            DrawBuffer();
        }

        public static void DrawBuffer()
        {
            for (int y = 0; y < 30; y++)
            {
                for (int x = 0; x < 30; x++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(Buffer[x, y]);
                    Console.BackgroundColor = ColorBuffer[x, y];
                }
            }
        }

        static Data()
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
        }
    }
}
