using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLifeLib
{
    public class Generator
    {
        public bool IsCellLiveInNextGeneration(bool isCellAlive, int numberOfNeighbours)
        {
            return (numberOfNeighbours == 3) || (numberOfNeighbours == 2 && isCellAlive);
        }

        public int GetNumberOfNeighbours(bool[,] cells, int row, int column)
        {
            try
            {
                if (row < 0 || row >= cells.GetLength(0) || column < 0 || column >= cells.GetLength(1))
                    return 0;

                int numberOfNeighbours = 0;

                for (int i = row - 1; i <= row + 1; i++)
                    if (i >= 0 && i < cells.GetLength(0))
                    {
                        for (int j = column - 1; j <= column + 1; j++)
                            if ((j >= 0 && j < cells.GetLength(1)) && cells[i, j])
                                numberOfNeighbours++;
                    }

                return (cells[row, column]) ? numberOfNeighbours - 1 : numberOfNeighbours;
            }
            catch (NullReferenceException)
            {
                return 0;
            }
        }

        public bool CheckIfNeedsResize(bool[,] cells)
        {
            bool resize = false;

            for (int i = 0; i <= cells.GetLength(0) - 3; i++)
                if ((cells[i, 0] && cells[i + 1, 0] && cells[i + 2, 0]) || (cells[i, cells.GetLength(1) - 1] && cells[i + 1, cells.GetLength(1) - 1] && cells[i + 2, cells.GetLength(1) - 1]))
                {
                    resize = true;
                    break;
                }

            if (!resize)
            {
                for (int j = 0; j <= cells.GetLength(1) - 3; j++)
                    if ((cells[0, j] && cells[0, j + 1] && cells[0, j + 2]) || (cells[cells.GetLength(0) - 1, j] && cells[cells.GetLength(0) - 1, j+1] && cells[cells.GetLength(0) - 1, j+2]))
                    {
                        resize = true;
                        break;
                    }
            }

            return resize;
        }

        public bool[,] ResizeGrid(bool[,] cells)
        {
            if (!CheckIfNeedsResize(cells))
                return cells;

            bool[,] resizedCells = new bool[cells.GetLength(0) + 2, cells.GetLength(1) + 2];

            for (int i = 1; i < resizedCells.GetLength(0) - 1; i++)
                for (int j = 1; j < resizedCells.GetLength(1) - 1; j++)
                    resizedCells[i, j] = cells[i - 1, j - 1];

            return resizedCells;
        }

        public bool[,] NextGeneration(bool[,] cells)
        {
            try
            {
                bool[,] resizedCells = ResizeGrid(cells);
                bool[,] result = new bool[resizedCells.GetLength(0), resizedCells.GetLength(1)];

                for (int i = 0; i < resizedCells.GetLength(0); i++)
                    for (int j = 0; j < resizedCells.GetLength(1); j++)
                        result[i, j] = IsCellLiveInNextGeneration(resizedCells[i, j], GetNumberOfNeighbours(resizedCells, i, j));

                return result;
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }
    }
}