using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellAutoDesigner
{
    public abstract class Rule
    {
        public string Name { get; set; }
        protected Environment Template { get; set; }

        public abstract bool CompareStates(Environment environment);
        public abstract void SetCellState(ref Cell cell, Environment environment);
    }

    public class ConvaysRule : Rule
    {
        public ConvaysRule(string name, Environment environment)
        {
            this.Name = name;
            this.Template = environment;
        }
        public override bool CompareStates(Environment environment)
        {
            throw new NotImplementedException();
        }

        public override void SetCellState(ref Cell cell, Environment cellEnvironment)
        {
            throw new NotImplementedException();
        }
    }
}
