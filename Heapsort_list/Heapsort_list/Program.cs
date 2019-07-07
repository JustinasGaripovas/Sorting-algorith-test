using System;
using System.Diagnostics;

namespace Heapsort_list
{
    class MainClass
    {

       // const int n = 100000;

        public static void Main(string[] args)
        {
            int seed = (int)DateTime.Now.Ticks & 0x0000FFFF;
            Console.WriteLine("LIST Heap sort  OP\n    N");

            Test_OP(seed, 400);
          
        }

        public static void Test_OP(int seed, int n)
        {
            ListObject data = new ListObject();

            Stopwatch sw = new Stopwatch();

            Random rand = new Random(seed);
            for (int i = 0; i < n; i++)
            {
                SortableObject temp = new SortableObject();
                temp.Number = rand.Next(1,100);

                for (int j = 0; j < 8; j++)
                {
                    temp.Text += (char)rand.Next(65, 90);
                }

                data.Insert(temp, i);
            }

            sw.Start();

            data.Print();

            Heapsort_list_OP.HeapSort(data, n);

            data.Print();

            sw.Stop();

            Console.WriteLine("{1,9} took => {0}", sw.Elapsed, n);
        }
    }
}
