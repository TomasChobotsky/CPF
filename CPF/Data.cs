using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPF.Components;

namespace CPF
{
    public static class Data
    {
        public static List<ButtonComponent> Buttons { get; set; } = new List<ButtonComponent>();
        public static event PropertyChangedEvent PropertyChanged;
        public delegate void PropertyChangedEvent();

        //Change [30, 30] to properties
        public static ConsoleColor[,] ColorBuffer = new ConsoleColor[30, 30];
        public static char[,] Buffer { get; set; } = new char[30, 30];

        public static void BufferChanged()
        {
            for (int y = 0; y < 30; y++)
            {
                for (int x = 0; x < 30; x++)
                {
                    ColorBuffer[x, y] = ConsoleColor.Black;
                }
            }

            foreach (var button in Buttons)
            {
                button.Draw();
            }
            
            PropertyChanged?.Invoke();
        }
    }
}
