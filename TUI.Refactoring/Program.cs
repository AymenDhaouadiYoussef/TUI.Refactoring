using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUI.Refactoring
{
    class Program
    {
        //
        // The problem is that the variable message 
        // is accessed twice in every condition statement. 
        // the first for type check
        // and the second for type cast.
        // So there's a small performance hit
        //
        // Solution
        // Starting with c# 7 we can use pattern matching with the type pattern
        // for example if(message is MessageA msg)  
        //
        // or
        // 
        // we can use the following statement
        static void Main(string[] args)
        {
            var message = new MessageC();

            RefactoredMethod(message);

            Console.ReadKey();
        }

        static void RefactoredMethod<T>(T message)
        {
            var msgA= message as MessageA;
            if(msgA != null)
            {
                msgA.MyCustomMethodOnA();
            }
            else
            {
                var msgB = message as MessageB;
                if(msgB != null)
                {
                    msgB.MyCustomMethodOnB();
                    msgB.SomeAdditionalMethodOnB();
                }
                else
                {
                    var msgC = message as MessageC;
                    msgC?.MyCustomMethodOnC();
                }
            }
        }
    }
}
