using System;
using System.Diagnostics;
using HeapSort;

namespace HeapSort
{
    class Heapsort_D
    {
        public static void HeapSort(DataArray arr, int n)
        {
            for (int i = n / 2 - 1; i >= 0; i--)
                Heapify(arr, n, i);
            for (int i = n - 1; i >= 0; i--)
            {
                arr.Swap(0, i);

                Heapify(arr, i, 0);
            }
        }

        static void Heapify(DataArray arr, int n, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if (left < n && arr[left] > arr[largest])
                largest = left;
            if (right < n && arr[right] > arr[largest])
                largest = right;
            if (largest != i)
            {
                arr.Swap(i, largest);
                Heapify(arr, n, largest);
            }
        }
    }
}
