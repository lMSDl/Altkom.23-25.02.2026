using System;
using System.Collections.Generic;
using System.Text;

namespace Delegates
{
    internal class BuildInDelegates
    {
        void Add(int a, int b)
        {
            Console.WriteLine(a + b);
        }

        bool SubstractAndCopare(int a, int b)
        {
            var result = a - b;
            Console.WriteLine(result);
            return a == b;
        }


        //delegate void Method1Delegate(int a, int b);
        //delegate bool Method2Delegate(int a, int b);
        //void Method(Method1Delegate method1, Method2Delegate method2)

        void Method(Action<int, int> method1, Func<int,int, bool> method2)
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    method1.Invoke(i, j);
                    bool result = method2.Invoke(i, j);
                    Console.WriteLine(result);
                }
        }

        public void Test()
        {
            Method(Add, SubstractAndCopare);
        }
    }
}
