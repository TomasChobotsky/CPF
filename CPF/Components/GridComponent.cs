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

        private int gridPosX = 0;
        private int gridPosY = 0;
        

        public GridComponent()
        {
            
        }
        
        /// <summary>
        /// Constructs grid in another grid (if you want grid only in a row/column, put the value you dont want to -1
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="column"></param>
        /// <param name="row"></param>
        public GridComponent(GridComponent grid, int column, int row)
        {
            if (column < 0)
            {
                gridPosY += grid.RowPositions[row];
            }
            else if (row < 0)
            {
                gridPosX += grid.ColumnPositions[column];
            }
            else
            {
                gridPosX += grid.ColumnPositions[column];
                gridPosY += grid.RowPositions[row];
            }
        }

        public void AddColumn(int width)
        {
            ColumnDefinitions.Add(width);
            ColumnPositions.Add(currentWidth + gridPosX);
            currentWidth += width;
        }
        public void AddRow(int height)
        {
            RowDefinitions.Add(height);
            RowPositions.Add(currentHeight + gridPosY);
            currentHeight += height;
        }
    }
}