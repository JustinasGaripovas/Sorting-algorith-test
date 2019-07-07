using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace BucketSortArray_D
{
    class MainClass
    {

        public static void Main(string[] args)
        {
            int seed = (int)DateTime.Now.Ticks & 0x0000FFFF;

            Console.WriteLine("ARRAY DISK Bucket sort  \n    N");
            Test_Array_List(seed, 400);
            Test_Array_List(seed, 800);
            Test_Array_List(seed, 1600);
            Test_Array_List(seed, 3200);
            Test_Array_List(seed, 6400);
            Test_Array_List(seed, 12800);
            Test_Array_List(seed, 25600);
            Test_Array_List(seed, 51200);
        }

        public static void Test_Array_List(int seed, int n)
        {
            Stopwatch sw = new Stopwatch();
            string filename = @"mydataarray.dat";
            MyFileArray myarray = new MyFileArray(filename,n, seed);
         
            sw.Start();

            List<SortableObject> array = BucketSort_D.BucketSort(myarray, n);
                 
            sw.Stop();
            Console.WriteLine("{1,9} took => {0}", sw.Elapsed, n);
        }
    }
}
