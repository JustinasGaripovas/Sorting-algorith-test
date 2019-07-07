using System;
using System.Collections.Generic;
using BucketSort;

//Nuo nulio iki vieno del blogiausiu ir geriausiu variantu 
//Keitimo funkcija
//Rodykles bucket pradzioje kur byloje yra
//Bucket kisenes turetu buti diske
//
//AutoInc 
namespace BucketSort
{
    public class BucketSort_OP
    {
        public static List<SortableObject> BucketSort(DataArray x, int n)
        {
            List<SortableObject> result = new List<SortableObject>();

            int numOfBuckets = 10;

            List<SortableObject>[] buckets = new List<SortableObject>[numOfBuckets];

            for (int i = 0; i < numOfBuckets; i++)

            buckets[i] = new List<SortableObject>();

            for (int i = 0; i < n; i++)
            {
                int buckitChoice = (x[i].Number/ numOfBuckets);
                buckets[buckitChoice].Add(x[i]);
            }

            for (int i = 0; i < numOfBuckets; i++)
            {
                SortableObject[] temp = BubbleSortList(buckets[i], x);
                result.AddRange(temp);
            }
            return result;
        }

        public static SortableObject[] BubbleSortList(List<SortableObject> input, DataArray x)
        {
            for (int i = 0; i < input.Count; i++)
            {
                for (int j = 0; j < input.Count; j++)
                {
                    if (input[i] < input[j])
                    {
                        x.Swap(i, j);/*
                        SortableObject temp = input[i];
                        input[i] = input[j];
                        input[j] = temp;*/
                    }
                }
            }
            return input.ToArray();
        }
    }
}
