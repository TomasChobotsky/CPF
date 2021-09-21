using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF
{
    public static class Data
    {
        public static List<ButtonComponent> Buttons { get; set; } = new List<ButtonComponent>();
        public static event PropertyChangedEvent PropertyChanged;
        public delegate void PropertyChangedEvent();

        public static char[,] Buffer
        {
            get
            {
                return buffer;
            }
            set
            {
                buffer = value;
                PropertyChanged?.Invoke();
            }
        }

        private static char[,] buffer;

        static Data()
        {
            Buffer = new char[Console.WindowWidth, Console.WindowHeight];
        }
    }
}
