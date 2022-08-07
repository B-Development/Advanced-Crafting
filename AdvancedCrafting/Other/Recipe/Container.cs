using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedCrafting.Other.Recipe
{
    public class Container
    {
        public string Value { get; set; }

        public Container()
        {

        }

        public Container(string value)
        {
            Value = value;
        }

        public static implicit operator string(Container p)
            => p.Value;

        public static implicit operator Container(string value)
            => new Container(value);
    }
}
