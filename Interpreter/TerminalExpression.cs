using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    /// <summary>
    /// Only one terminal expression class is defined in this example
    /// and it returns true if a token was found there.
    /// </summary>
    class TerminalExpression : Expression
    {
        private string _literal = String.Empty;

        public TerminalExpression(string input)
        {
            _literal = input;
        }

        public override bool Interpret(string sentence)
        {
            string[] words = sentence.Split(' ');

            return words.Any(word => word.Equals(_literal));
        }
    }
}
