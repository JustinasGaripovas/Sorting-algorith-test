using System;
using System.Diagnostics;
using System.IO;
using HeapSort;

namespace HeapSort
{
    class MainClass
    {

        const int n = 400;

        public static void Main(string[] args)
        {
            int seed = (int)DateTime.Now.Ticks & 0x0000FFFF;

            Console.WriteLine("Heapsort ARRAY OP\n    N");
            Test_OP(seed, 400);
            Test_OP(seed, 800);
            Test_OP(seed, 1600);
            Test_OP(seed, 3200);
            Test_OP(seed, 6400);
            Test_OP(seed, 12800);
            Test_OP(seed, 25600);
            Test_OP(seed, 51200);

            Console.WriteLine("\nHeapsort ARRAY D\n    N");
            Test_D(seed, 400);
            Test_D(seed, 800);
            Test_D(seed, 1600);
            Test_D(seed, 3200);
            Test_D(seed, 6400);
            Test_D(seed, 12800);
            Test_D(seed, 25600);
            Test_D(seed, 51200);
        }

        public static void Test_OP(int seed, int n)
        {
            Stopwatch sw = new Stopwatch();

            MyDataArray myarray = new MyDataArray(n, seed);

            sw.Start();

            Heapsort_OP.HeapSort(myarray, n);

            sw.Stop();

    


            Console.WriteLine("{1,9} took => {0}", sw.Elapsed, n);


        }


        public static void Test_D(int seed, int n)
        {
          
            Stopwatch sw = new Stopwatch();

            string filename = @"/home/justin/Projects/HeapSort_OP/HeapSort_OP/mydataarray.dat";
            MyFileArray myfilearray = new MyFileArray(filename, n, seed);

            sw.Start();

            using (myfilearray.fs = new FileStream(filename, FileMode.Open,
            FileAccess.ReadWrite))
            {
                Heapsort_D.HeapSort(myfilearray, n);
                
            }
            sw.Stop();

            Console.WriteLine("{1,9} took => {0}", sw.Elapsed, n);
        }
    }
}
