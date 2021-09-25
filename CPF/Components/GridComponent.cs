using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace CPF.Components
{
    public class GridComponent
    {
        public List<int> ColumnDefinitions = new List<int>();
        public List<int> RowDefinitions = new List<int>();
        public List<int> ColumnPositions = new List<int>();
        public List<int> RowPositions = new List<int>();

        private int currentWidth = 0;
        private int currentHeight = 0;

        public void AddColumn(int width)
        {
            ColumnDefinitions.Add(width);
            ColumnPositions.Add(currentWidth);
            currentWidth += width;
        }
        public void AddRow(int height)
        {
            RowDefinitions.Add(height);
            RowPositions.Add(currentHeight);
            currentHeight += height;
        }
    }
}