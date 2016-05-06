using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    /// <summary>
    /// One of the Design Patterns published in the GoF which is not really used. Ussualy the Interpreter Pattern 
    /// is described in terms of formal grammars, like it was described in the original form in the GoF but 
    /// the area where this design pattern can be applied can be extended.
    /// A specific area where Interpreter can be used are the rules engines.
    /// This class is the Client participant, that builds the abstract tree and call the interpret method of the Interpreter tree.
    /// </summary>
    class MainProgram
    {
        // Build the interpreter and then interpret a specific sequence
        static void Main(string[] args)
        {
            // String object is used as a context. The string that has to be interpreted is parsed.
            string context = "Site1 User2";
            Expression define = BuildInterpreterTree();
            Console.WriteLine("Can this user claim Bonus1: ");
            Console.WriteLine(context + " is " + define.Interpret(context));

            context = "Site2 User2";
            define = BuildInterpreterTree();
            Console.WriteLine("Can this user claim Bonus1: ");
            Console.WriteLine(context + " is " + define.Interpret(context));

            Console.ReadKey();
        }

        //builds the interpreter tree and defines the rule "Site1 and (Bonus1 or (User1 or User2))"
        static Expression BuildInterpreterTree()
        {
            // Literal
            Expression terminal1 = new TerminalExpression("Bonus1");
            Expression terminal2 = new TerminalExpression("User1");
            Expression terminal3 = new TerminalExpression("User2");
            Expression terminal4 = new TerminalExpression("Site1");

            Expression alternation1 = new OrExpression(terminal2, terminal3);
            Expression alternation2 = new OrExpression(terminal1, alternation1);

            return new AndExpression(terminal4, alternation2);
        }
    }
}
