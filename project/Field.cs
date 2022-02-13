using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellAutoDesigner
{
    public static class Field
    {
        private static bool isFieldEndless = default;
        private static int hight = default;
        private static int width = default;
        private static Cell[,] cells = new Cell[hight, width];

        public static void Construct(int inputHight, int inputWidth, bool inputIsEndless)
        {
            hight = inputHight;
            width = inputWidth;
            isFieldEndless = inputIsEndless;
        }

        public static ref Cell GetCell(int i, int j)
        {
            int _i = i;
            int _j = j;

            if (i < 0)
            {
                _i = width - 1;
            }
            else if (i > width)
            {
                _i = 1;
            }
            if (j < 0)
            {
                _j = hight - 1;
            }
            else if (j > width)
            {
                _j = 1;
            }

            return ref cells[_i, _j];
        }

        private static Environment GetEnvironment(int i, int j)
        {
            Environment environment = new Environment();

            environment.TOP_left = GetCell(i - 1, j - 1).GetState();
            environment.TOP_cent = GetCell(i, j - 1).GetState();
            environment.TOP_right = GetCell(i + 1, j - 1).GetState();

            environment.MID_left = GetCell(i - 1, j).GetState();
            environment.MID_right = GetCell(i + 1, j).GetState();

            environment.BOT_left = GetCell(i - 1, j + 1).GetState();
            environment.BOT_cent = GetCell(i, j + 1).GetState();
            environment.BOT_right = GetCell(i + 1, j + 1).GetState();

            return environment;
        }

        public static void SetCellStateNaive(Rule rule)
        {
            for (int j = 0; j <= hight; j++)
            {
                for (int i = 0; i <= width; i++)
                {
                    rule.SetCellState(ref cells[i, j], GetEnvironment(i, j));
                }
            }
        }
    }
}
