using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    class MyGenClass<T>
    {
        T _value;
        public MyGenClass()
        {

        }
        public MyGenClass(T t)
        {
            // The field has the same type as the parameter.
            this._value = t;
        }

        public void Write()
        {
            Console.WriteLine(this._value);
        }

        public void ExecTest()
        {
            // Use the generic type Test with an int type parameter.
            MyGenClass<int> test1 = new MyGenClass<int>(5);
            // Call the Write method.
            test1.Write();

            // Use the generic type Test with a string type parameter.
            MyGenClass<string> test2 = new MyGenClass<string>("cat");
            test2.Write();
        }

        public static void GenericMethod<typeParamT>(typeParamT toDisplay)
        {
            Console.WriteLine("\r\nHere it is: {0}", toDisplay);
        }
    }

    //class C
    //{
    //    T N<T, U>(T t, U u) {...}
    //    public V M<V>(V v)
    //    {
    //        return N<V, int>(v, 42);
    //    }
    //}


}
