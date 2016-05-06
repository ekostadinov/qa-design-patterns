using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    /// <summary>
    /// This class is the actual abstract Interpret object
    /// </summary>
    abstract class Expression
    {
        abstract public bool Interpret(String str); 
    }
}
