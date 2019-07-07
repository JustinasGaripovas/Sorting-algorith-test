using System;
namespace Heapsort_list
{
    public class SortableObject : IComparable<SortableObject>
    {
        public int Number { get; set; }
        public string Text { get; set; }

        public override string ToString()
        {
            return String.Format("{0,2} {1}", Number, Text);
        }

        public int CompareTo(SortableObject obj)
        {
            if (Number < obj.Number) return 1;
            if (Number > obj.Number) return -1;

            if (String.Compare(Text, obj.Text) == 1) return 1; if (String.Compare(Text, obj.Text) == -1) return 1;

            return 0;
        }

        public static bool operator >(SortableObject x, SortableObject y)
        {
            if (x.Number < y.Number) return false;
            if (x.Number > y.Number) return true;

            if (String.Compare(x.Text, y.Text) == 1) return true;
            if (String.Compare(x.Text, y.Text) == -1) return false;

            return false;
        }

        public static bool operator <(SortableObject x, SortableObject y)
        {
            if (x.Number < y.Number) return true;
            if (x.Number > y.Number) return false;

            if (String.Compare(x.Text, y.Text) == 1) return false;
            if (String.Compare(x.Text, y.Text) == -1) return true;

            return false;
        }
    }
}
