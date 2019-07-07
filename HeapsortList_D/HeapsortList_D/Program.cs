using System;
using System.Diagnostics;

namespace HeapsortList_D
{
    class MainClass
    {

        const int n = 100000;

        public static void Main(string[] args)
        {
            int seed = (int)DateTime.Now.Ticks & 0x0000FFFF;

            Console.WriteLine("List  Heap sort  D \n    N");
            Test_OP(seed, 400);
            Test_OP(seed, 800);
            Test_OP(seed, 1600);
            Test_OP(seed, 1700);
            Test_OP(seed, 1800);
            Test_OP(seed, 1900);
         
        }

        public static void Test_OP(int seed, int n)
        {
            string filename = @"mydataarray.dat";

            ListObject data = new ListObject(filename,n,seed);
        
            Stopwatch sw = new Stopwatch();

            sw.Start();


            data.Print();

            HeapSort_list_D.HeapSort(data, n);

            data.Print();


            sw.Stop();

            Console.WriteLine("{1,9} took => {0}", sw.Elapsed, n);


        }
    }
}
