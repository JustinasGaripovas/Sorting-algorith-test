using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace BucketSortList_D
{
    class MainClass
    {
        public static void Main(string[] args)
        {

            int seed = (int)DateTime.Now.Ticks & 0x0000FFFF;

            Console.WriteLine("LIST Bucket sort D \n    N");
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
            string filename = @"mydataarray.dat";

            ListObject data = new ListObject(filename, n, seed);
            Stopwatch sw = new Stopwatch();

            sw.Start();


            List<SortableObject> SortableList = BucketSortList.BucketSort(data, n);


            sw.Stop();
            /*
            foreach(SortableObject a in SortableList)
            {
                Console.WriteLine(a.ToString());
            }*/

            Console.WriteLine("{1,9} took => {0}", sw.Elapsed, n);
        }
    }
}
