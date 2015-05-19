using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    public static class CustomSequenceOperators
    {
        //Func in short is parameterized delegate. In C#, a delegate instance points towards a method. 
        //When a caller invokes the delegate, it calls its target method. This way, the caller is not 
        //invoking the target method rather invoking the delegate which can call the target method. 
        //We do it because it creates an abstraction on invoking the target method. We of course always 
        //can invoke a method directly but decoupling of the client and target method is sometimes a need or 
        //gives us more flexibility to make things clean and simple.
        //
        //We can use Func delegate to represent a method that can be passed as a parameter without explicitly declaring a custom delegate
        //Error	2	'System.Array' does not contain a definition for 'Combine' and no extension method 'Combine' accepting a first argument of type 'System.Array' could be found (are you missing a using directive or an assembly reference?)	C:\Users\sesa353278\Source\Repos\codeshow\ConsoleApplication1\ConsoleApplication1\CustomSequenceOperators.cs	55	38	ConsoleApplication1

        public static IEnumerable<int> Combine(this IEnumerable<int> first, IEnumerable<int> second, Func<int, int, int> func)
        {
            using (IEnumerator<int> e1 = first.GetEnumerator(), e2 = second.GetEnumerator())
            {
                while (e1.MoveNext() && e2.MoveNext())
                {
                    yield return func(e1.Current, e2.Current);
                }
            }
        }

        //https://social.msdn.microsoft.com/Forums/vstudio/en-US/27001314-4bf2-4456-b5ad-b1f43501593f/extension-methods-c?forum=csharpgeneral
        public static IEnumerable<TS> CombineList<TS>(this IEnumerable<DataRow> first, IEnumerable<DataRow> second,
            Func<DataRow, DataRow, TS> func)
        {
            using (IEnumerator<DataRow> e1 = first.GetEnumerator(), e2 = second.GetEnumerator())
            {
                while (e1.MoveNext() && e2.MoveNext())
                {
                    yield return func(e1.Current, e2.Current);
                }
            }
        }     


    }

    public class LinqSamples
    {
        public void Linq98()
        {
            int[] vectorA = { 0, 2, 4, 5, 6 };
            int[] vectorB = { 1, 3, 5, 7, 8 };

            int dotProduct = vectorA.Combine(vectorB, (a, b) => a * b).Sum();

            //DataSet testDS = TestHelper.CreateTestDataset();
            //var numbersA = testDS.Tables["NumbersA"].AsEnumerable();
            //var numbersB = testDS.Tables["NumbersB"].AsEnumerable();
            //int dotProduct2 = numbersA.CombineList(numbersB, (a, b) => a.Field<int>("number") * b.Field<int>("number")).Sum();

            Console.WriteLine("Dot product: {0}", dotProduct);
        }
    }

}
