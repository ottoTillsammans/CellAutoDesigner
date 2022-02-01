using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellAutoDesigner
{
    public class Field
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

        private static Environment GetEnvironment(int i, int j)
        {
            Environment environment = new Environment();
            var isOnLeftEdge = i == 0;
            var isOnRightEdge = i == width;
            var isOnTopEdge = j == 0;
            var isOnBottomEdge = j == hight;

            environment.TOP_left = cells[i - 1, j - 1].GetState();
            environment.TOP_central = cells[i, j - 1].GetState();
            environment.TOP_right = cells[i + 1, j - 1].GetState();

            environment.MID_left = cells[i - 1, j].GetState();
            environment.MID_right = cells[i + 1, j].GetState();

            environment.BOT_left = cells[i - 1, j + 1].GetState();
            environment.BOT_central = cells[i, j + 1].GetState();
            environment.BOT_right = cells[i + 1, j + 1].GetState();

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
