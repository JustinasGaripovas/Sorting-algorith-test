using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using BucketSort;
using BucketSortList;

namespace BucketSortList
{
    class MainClass
    {
        public static void Main(string[] args)
        {

            int seed = (int)DateTime.Now.Ticks & 0x0000FFFF;

            Console.WriteLine("LIST Bucket sort OP \n    N");
            Test_Array_List(seed, 400);
            Test_Array_List(seed, 800);
            Test_Array_List(seed, 1600);
            Test_Array_List(seed, 3200);
            Test_Array_List(seed, 6400);
            Test_Array_List(seed, 12800);
            Test_Array_List(seed, 25600);
            Test_Array_List(seed, 51200);
        }


        public static void Test_Array_List(int seed,int n)
        {
            ListObject data = new ListObject();
            Stopwatch sw = new Stopwatch();

            Random rand = new Random(seed);
            for (int i = 0; i < n; i++)
            {
                SortableObject temp = new SortableObject();
                temp.Number = rand.Next(1, 100);

                for (int j = 0; j < 8; j++)
                {
                    temp.Text += (char)rand.Next(65, 90);
                }

                data.Insert(temp, i);
            }


            sw.Start();


            List<SortableObject> SortableList = BucketSortMyFileList.BucketSort(data, n);


            sw.Stop();

            Console.WriteLine("{1,9} took => {0}", sw.Elapsed, n);
        }
    }
}
