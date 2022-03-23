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
        public Rule(string name, Environment environment)
        {
            this.Name = name;
            this.Template = environment;
        }
        public abstract bool CompareStates(Environment environment);
        public abstract bool SetCellState(in Cell cell, Environment environment);
    }

    public class StandardRule : Rule
    {
        public StandardRule(string name, Environment environment) : base(name, environment) { }

        public override bool CompareStates(Environment environment)
        {
            throw new NotImplementedException();
        }

        public override bool SetCellState(in Cell cell, Environment environment)
        {
            throw new NotImplementedException();
        }
    }
}
