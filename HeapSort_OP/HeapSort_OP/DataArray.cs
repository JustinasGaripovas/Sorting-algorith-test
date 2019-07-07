using System;
using System.IO;
using System.Text;

namespace HeapSort
{
    class MyDataArray : DataArray
    {
        SortableObject[] data;

        public MyDataArray(int n, int seed)
        {
            data = new SortableObject[n];

            Random rand = new Random(seed);
            for (int i = 0; i < n; i++)
            {
                data[i] = new SortableObject();
                data[i].Number = rand.Next(1, 85);

                for (int j = 0; j < 8; j++)
                {
                    data[i].Text += (char)rand.Next(65, 90);
                }
            }
        }

        public override SortableObject this[int index]
        {
            get { return data[index]; }
        }

        public override void Swap(int a, int b)
        {
            SortableObject swap = data[a];
            data[a] = data[b];
            data[b] = swap;
        }
    }

    class MyFileArray : DataArray
    {
        public MyFileArray(string filename, int n, int seed)
        {
            length = n;

            Random rand = new Random(seed);

            if (File.Exists(filename)) File.Delete(filename);

            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(filename,
                FileMode.Create)))
                {
                    for (int j = 0; j < length; j++)
                    {
                        writer.Write(rand.Next(1, 100));

                        string word = "";
                        for (int text = 0; text < 8; text++)
                        {
                            word += (char)rand.Next(65, 90);
                        }

                        writer.Write(word);
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public FileStream fs { get; set; }

        public override SortableObject this[int index]
        {
            get
            {
                Byte[] data = new Byte[13];

                fs.Seek(13 * index, SeekOrigin.Begin);
                fs.Read(data, 0, 13);
                
                SortableObject result = new SortableObject();

                result.Number = BitConverter.ToInt32(data, 0);

                Byte[] data_string = new Byte[8];
                Array.Copy(data,5, data_string,0,8);

                string utfString = Encoding.UTF8.GetString(data_string, 0, data_string.Length);
                result.Text = utfString;

                return result;
            }
        }

        public void PrintFromFile(int n)
        {
            Console.WriteLine();

            for (int index = 0; index < n; index += 1)
            {
                Byte[] data = new Byte[13];

                fs.Seek(13 * index, SeekOrigin.Begin);
                fs.Read(data, 0, 13);

                SortableObject result = new SortableObject();

                result.Number = BitConverter.ToInt32(data, 0);

                Byte[] data_string = new Byte[8];
                Array.Copy(data, 5, data_string, 0, 8);

                string utfString = Encoding.UTF8.GetString(data_string, 0, data_string.Length);
                result.Text = utfString;

               Console.WriteLine(result);
            }
        }

        public override void Swap(int a, int b)
        {
            //Issisaugau A i data_a
            Byte[] data_a = new Byte[13];
            fs.Seek(13 * a, SeekOrigin.Begin);
            fs.Read(data_a, 0, 13);

            SortableObject result = new SortableObject();
            result.Number = BitConverter.ToInt32(data_a, 0);
            Byte[] data_string = new Byte[8];
            Array.Copy(data_a, 5, data_string, 0, 8);
            string utfString = Encoding.UTF8.GetString(data_string, 0, data_string.Length);
            result.Text = utfString;
            // Console.WriteLine(result);

            //Issisaugau B i data_b
            Byte[] data_b = new Byte[13];
            fs.Seek(13 * b, SeekOrigin.Begin);
            fs.Read(data_b, 0, 13);

            /*
             * Isvedimas
             * 
            result = new SortableObject();
            result.Number = BitConverter.ToInt32(data_b, 0);
            data_string = new Byte[8];
            Array.Copy(data_b, 5, data_string, 0, 8);
            utfString = Encoding.UTF8.GetString(data_string, 0, data_string.Length);
            result.Text = utfString;
            Console.WriteLine(result);
            */           

            fs.Seek(13 * b, SeekOrigin.Begin);
            fs.Write(data_a, 0, data_a.Length);

            fs.Seek(13 * a, SeekOrigin.Begin);
            fs.Write(data_b, 0, data_b.Length);
        }
    }

    public abstract class DataArray
    {
        protected int length;
        public int Length { get { return length; } }
        public abstract SortableObject this[int index] { get; }
        public abstract void Swap(int a, int b);
        public void Print(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(" {0:F5} ", this[i]);
            }
            Console.WriteLine();
        }
    }

    public class SortableObject: IComparable<SortableObject>
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

            if (String.Compare(Text, obj.Text) == 1) return 1;
            if (String.Compare(Text, obj.Text) == -1) return 1;

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
