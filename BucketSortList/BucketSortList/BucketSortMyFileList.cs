using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BucketSortList;

namespace BucketSort
{
    class BucketSortMyFileList
    {
        public static List<SortableObject> BucketSort(ListObject x, int n)
        {
            List<SortableObject> result = new List<SortableObject>();

            int numOfBuckets = 10;

            List<SortableObject>[] buckets = new List<SortableObject>[numOfBuckets];

            for (int i = 0; i < numOfBuckets; i++)

                buckets[i] = new List<SortableObject>();

            for (int i = 0; i < n; i++)
            {          
                int buckitChoice = (x.GetIndex(i).Number / numOfBuckets);
                buckets[buckitChoice].Add(x.GetIndex(i));
            }

            for (int i = 0; i < numOfBuckets; i++)
            {
                SortableObject[] temp = BubbleSortList(buckets[i], x);
                result.AddRange(temp);
            }
            return result;
        }

        public static SortableObject[] BubbleSortList(List<SortableObject> input, ListObject x)
        {
            for (int i = 0; i < input.Count; i++)
            {
                for (int j = i; j < input.Count; j++)
                {
                    if (input[i] > input[j])
                    {
                        SortableObject temp = input[i];
                        input[i] = input[j];
                        input[j] = temp;
                    }
                }
            }
            return input.ToArray();
        }
    }
}
