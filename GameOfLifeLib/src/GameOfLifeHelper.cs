using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLifeLib
{
    public class GameOfLifeHelper
    {
        public static bool[,] CreatePattern(int[] size, int[] positions = null)
        {
            try
            {
                if (size.Length < 2)
                    return null;

                bool[,] pattern = new bool[size[0], size[1]];

                int max = size[0] * size[1];

                if (positions != null)
                {
                    for (int i = 0; i < positions.Length; i++)
                        if (positions[i] >= 0 && positions[i] < max)
                            pattern[positions[i] / size[1], positions[i] % size[1]] = true;
                }

                return pattern;
            }
            catch (NullReferenceException e)
            {
                throw e;
            }
        }
    }
}
