using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellAutoDesigner
{
    public class Environment
    {
        public bool TOP_left;
        public bool TOP_cent;
        public bool TOP_right;
        public bool MID_left;
        public bool MID_right;
        public bool BOT_left;
        public bool BOT_cent;
        public bool BOT_right;

        /// <summary>
        /// Count the number of living cells.
        /// </summary>
        /// <returns>Number of living</returns>
        public int GetAlivesNum()
        {
            return
                (this.TOP_left ? 1 : 0) +
                (this.MID_left ? 1 : 0) +
                (this.BOT_left ? 1 : 0) +
                (this.TOP_cent ? 1 : 0) +
                (this.BOT_cent ? 1 : 0) +
                (this.TOP_right ? 1 : 0) +
                (this.MID_right ? 1 : 0) +
                (this.BOT_right ? 1 : 0);
        }
    }

    public struct Cell
    {
        private bool currState;
        private bool prevState;

        public Cell(bool init)
        {
            currState = init;
            prevState = init;
        }

        public Cell(bool currInit, bool prevInit)
        {
            currState = currInit;
            prevState = prevInit;
        }

        /// <summary>
        /// Get the current state of this cell.
        /// </summary>
        /// <returns>True if cell is alive, otherwise False</returns>
        public bool GetState() => currState;

        /// <summary>
        /// Revive this cell.
        /// </summary>
        public void Revive()
        {
            prevState = currState;
            currState = true;
        }

        /// <summary>
        /// Kill this cell.
        /// </summary>
        public void Kill()
        {
            prevState = currState;
            currState = false;
        }

        /// <summary>
        /// Revive or kill this cell due to input parameter.
        /// </summary>
        /// <param name="isAlive">Send True if cell should live, otherwise False</param>
        public void ToBeOrNotToBe(bool isAlive)
        {
            if (isAlive)
            {
                Revive();
            }
            else
            {
                Kill();
            }
        }
    }
}
