using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    static class GenericMethod
    {
        static void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp;
            temp = lhs;
            lhs = rhs;
            rhs = temp;
        }

        public static void TestSwap()
        {
            int a = 1;
            int b = 2;

            Swap<int>(ref a, ref b);
            System.Console.WriteLine(a + " " + b);

            //You can also omit the type argument and the compiler will infer it. The following call to Swap is equivalent to the previous call:
            Swap(ref a, ref b);

            

        }

        //Generic methods can be overloaded on several type parameters. For example, the following methods can all be located in the same class:
        static void  DoWork() { }
        static void  DoWork<T>() { }
        static void DoWork<T, U>() { }
    }

    //Within a generic class, non-generic methods can access the class-level type parameters, as follows:
    class SampleClass<T>
    {
        void Swap(ref T lhs, ref T rhs) { }
    }

    class GenericList<T>
    {
        // CS0693 
        void SampleMethod<T>() { }
    }

    class GenericList2<T>
    {
        //No warning 
        void SampleMethod<U>() { }
    }
}
