using System;
namespace HeapsortList_D
{
    public class HeapSort_list_D
    {
    
        public static void HeapSort(ListObject list, int n)
        {
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(list, n, i);
            }
          //  Console.WriteLine("\n\nSTART OF PHASE 2\n\n");

            for (int i = n - 1; i >= 0; i--)
            {
                list.Swap(0, i);

                Heapify(list, i, 0);
            }
        }

        static void Heapify(ListObject arr, int n, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

           // Console.WriteLine("i -> {2}  left-> {0} right-> {3} largest-> {1}", left, largest, i, right);

            arr.Print();

            bool isRightLarger = arr.IsLeftBigger(right, largest);
            if (right < n && isRightLarger)
            {
                largest = right;
               // Console.WriteLine("***right is largest");
            }

            bool isLeftLarger = arr.IsLeftBigger(left, largest);
            if (left < n && isLeftLarger)
            {
                largest = left;
               // Console.WriteLine("***left is largest");
            }

            if (largest != i)
            {
               // Console.WriteLine("***i is NOT largest");

                arr.Swap(i, largest);

               // Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++");
               // arr.Print();
               // Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++");

                Heapify(arr, n, largest);
            }
          

        }
    }
}
