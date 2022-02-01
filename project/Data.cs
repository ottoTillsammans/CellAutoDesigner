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
        public bool TOP_central;
        public bool TOP_right;
        public bool MID_left;
        public bool MID_right;
        public bool BOT_left;
        public bool BOT_central;
        public bool BOT_right;
        
        public int GetAlivesCount()
        {
            return
                (this.TOP_left? 1 : 0) +
                (this.TOP_central ? 1 : 0) +
                (this.TOP_right ? 1 : 0) +
                (this.MID_left ? 1 : 0) +
                (this.MID_left ? 1 : 0) +
                (this.BOT_left ? 1 : 0) +
                (this.BOT_central ? 1 : 0) +
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

        public bool GetState() => currState;

        public void Revive()
        {
            prevState = currState;
            currState = true;
        }

        public void Kill()
        {
            prevState = currState;
            currState = false;
        }

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
