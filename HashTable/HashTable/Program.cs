using System;
using HashTable;

namespace HashTable
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            HashTableWithLinkedList table = new HashTableWithLinkedList();


            table.Add(100);


            Console.WriteLine(table.ToString());
        }
    }
}
