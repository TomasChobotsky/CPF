using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPF
{
    class MainWindow : MouseInput
    {
        public MainWindow ()
        {
            for (int y = 0; y < Console.WindowHeight - 1; y++)
            {
                for (int x = 0; x < Console.WindowWidth - 1; x++)
                {
                    Data.Buffer[x, y] = ' ';
                }
            }
            
            Data.Buttons.Add(new ButtonComponent(10, 5, 1, 1, SusButtonOperation));
            Data.Buttons.Add(new ButtonComponent(10, 5, 20, 1, HelloButtonOperation));
        }

        public void SusButtonOperation()
        {
            Console.WriteLine("Sus");   
        }

        public void HelloButtonOperation()
        {
            Console.WriteLine("Hello");
        }
    }
}
