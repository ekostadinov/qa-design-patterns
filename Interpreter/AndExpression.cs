using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    /// <summary>
    /// part of NonTerminalExpressions - Implements logical operator(AND) between 2 terminal or non terminal expressions
    /// </summary>
    class AndExpression: Expression
    {
        private Expression _expression1 = null;
        private Expression _expression2 = null;

        public AndExpression(Expression expression1, Expression expression2)
        {
            _expression1 = expression1;
            _expression2 = expression2;
        }

        public override bool Interpret(string sentence)
        {
            return _expression1.Interpret(sentence) && _expression2.Interpret(sentence);
        }
    }
}
