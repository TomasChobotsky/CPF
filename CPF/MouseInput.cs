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
        protected int PosX { get; set; }
        protected int PosY { get; set; }
        protected int Width 
        {
            get { return width;}
            set
            {
                width = value;
                TempBuffer = new char[Width, Height];
                TempColorBuffer = new ConsoleColor[Width, Height];
            }}

        protected int Height
        {
            get { return height;}
            set
            {
                height = value;
                TempBuffer = new char[Width, Height];
                TempColorBuffer = new ConsoleColor[Width, Height];
            }
        }

        private int width;
        private int height;
        protected char[,] TempBuffer { get; set; }
        protected ConsoleColor[,] TempColorBuffer { get; set; }
        
        public MouseInput(int posX, int posY, int width, int height)
        {
            PosX = posX;
            PosY = posY;
            Width = width;
            Height = height;
            
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
