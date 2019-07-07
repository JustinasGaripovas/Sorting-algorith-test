using System;
using System.Collections;
using System.Collections.Generic;

namespace Heapsort_list
{
    public class ListObject: IEnumerable<SortableObject>
    {
        public Entity Root;
        public Entity End;
        public Entity Conn;
        
        public ListObject()
        {
            this.Root = null;
            this.End = null;
            this.Conn = null;
        }

        public int Count()
        {
            int k = 0;
            Entity current = Root;
            while (current != null)
            {
                k++;
                current = current.Left;
            }
            return k;
        }

        public void Insert(SortableObject x, int index)
        {
            var new_entity = new Entity(x, End, null,index);
            if (Root != null)
            {
                End.Right = new_entity;
                new_entity.Left = End;
            }
            else
            {
                Root = new_entity;
            }
            End = new_entity;
        }

        public void Print()
        {

            for (Entity current = Root; current != null; current = current.Right)
            {
               // Console.WriteLine("{1,2}   |{0}", current.Object.ToString(), current.index);

            }
        }

        public bool IsLeftBigger(int a, int b)
        {
           // Console.WriteLine("WE ARE IN THERE");


            SortableObject aObj = null;
            SortableObject bObj = null;

            bool aFound = false;
            bool bFound = false;


            for (Entity current = Root; current != null; current = current.Right)
            {
                //Console.WriteLine("IMPORTANT {0}| a->{1}  b->{2}",current.Object.ToString(),a,b);

                if (current.index == a)
                { aObj = current.Object; aFound = true; }

                if (current.index == b)
                { bObj = current.Object; bFound = true; }
            }

            if (!bFound || !aFound)
            {
               // Console.WriteLine("-");

                return false;
            }



           // Console.WriteLine("DU OBIJEKTAI");
           // Console.WriteLine("{0}   {1}", aObj.ToString(), bObj.ToString());


            return aObj > bObj;
        }

        public void Swap(int a, int b)
        {
            Entity aObj = null;
            Entity bObj = null;

            bool aFound = false;
            bool bFound = false;

            for (Entity current = Root; current != null; current = current.Right)
            {
                if (current.index == a)
                { aObj = current; aFound = true; }

                if (current.index == b)
                { bObj = current; bFound = true; }
            }

            if (!bFound || !aFound)
            {
                throw new Exception();
            }

            aObj.ToString();
            bObj.ToString();

            SortableObject temp = aObj.Object;
            aObj.Object = bObj.Object;
            bObj.Object = temp;

        }

        IEnumerator<SortableObject> IEnumerable<SortableObject>.GetEnumerator()
        {
            for (Entity current = Root; current != null; current = current.Right)
            {
                yield return current.Object;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    public class Entity
    {
        public Entity Left { get; set; }
        public Entity Right { get; set; }

        public int index { get; set; }

        public SortableObject Object { get; set; }

        public Entity(SortableObject data, Entity left, Entity right,int index)
        {
            Object = data;
            this.Right = right;
            this.Left = left;
            this.index = index;
        }
    }
}
