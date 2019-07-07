using System;
using System.Collections;
using System.Collections.Generic;

namespace HashTableNew
{
    public class HashTableWithLinkedList
    {
        private int Size { get; set; }
        private int Count { get; set; }
        private LinkedList<SortableObject>[] Storage { get; set; }

        public HashTableWithLinkedList(int size)
        {
            this.Size = size;
            this.Storage = new LinkedList<SortableObject>[this.Size];
            this.Count = 0;
        }

        public void Print()
        {    
            foreach (LinkedList<SortableObject> item in Storage)
            {
                if (item != null)
                {
                    foreach (SortableObject obj in item)
                    {
                        Console.WriteLine(obj.ToString());
                    }
                }
            }
        }

        public int BranchCount()
        {
            int sum = 0;

            foreach (LinkedList<SortableObject> item in Storage)
            {
                if (item != null)
                {
                    sum++;
                }
            }

            return sum;
        }

        public int LeafCount()
        {
            int sum = 0;

            foreach (LinkedList<SortableObject> item in Storage)
            {
                if (item != null)
                {
                    foreach (SortableObject obj in item)
                    {
                        sum++;
                    }
                }
            }

            return sum;
        }

        public bool Add(SortableObject value)
        {
            if (this.Count >= this.Size)
            {
                this.Rebuild();
            }

            var index = this.GetHash(value.Number);

            if (this.Storage[index] == null)
            {
                this.Storage[index] = new LinkedList<SortableObject>();
            }

            this.Storage[index].AddLast(value);
            this.Count++;
            return true;
        }

        public bool Contains(SortableObject value)
        {
            var index = this.GetHash(value.Number);

            if (this.Storage[index] == null)
            {
                return false;
            }

            return this.Storage[index].Contains(value);
        }

        public bool Remove(SortableObject value)
        {
            var index = this.GetHash(value.Number);
            if (this.Storage[index] == null)
            {
                return false;
            }

            this.Count--;
            return this.Storage[index].Remove(value);
        }

        public void Clear()
        {
            foreach (var list in this.Storage)
            {
                if (list != null && list.Count > 0)
                {
                    list.Clear();
                }
            }
        }

        private void Rebuild()
        {
            this.Size = this.Size * 2;
            var newStorageItems = new List<SortableObject>();
     

            foreach (var item in this)
            {
                newStorageItems.Add(item);
            }


            this.Count = 0;
            this.Storage = new LinkedList<SortableObject>[this.Size];
            foreach (SortableObject item in newStorageItems)
            {
                this.Add(item);
            }
        }

        private int GetHash(int value)
        {
            return value % this.Size;
        }


        public IEnumerator<SortableObject> GetEnumerator()
        {
            foreach (var list in this.Storage)
            {
                if (list != null)
                {
                    foreach (var item in list)
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}