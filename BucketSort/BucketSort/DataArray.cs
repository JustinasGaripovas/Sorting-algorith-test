using System;
using System.IO;
using System.Text;

namespace BucketSort
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
                data[i].Number = rand.Next(1, 100);

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

            SortableObject[] data = new SortableObject[n];

            length = n;

            Random rand = new Random(seed);

            for (int i = 0; i < length; i++)
            {
                data[i] = new SortableObject();
                int x = rand.Next(1, 100);
                data[i].Number = x;


                for (int j = 0; j < 8; j++)
                {
                    data[i].Text += (char)rand.Next(65, 90);
                }

                Console.WriteLine("sk->{0,3} text->{1}", x, data[i].Text);
            }

            if (File.Exists(filename)) File.Delete(filename);

            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(filename,
                FileMode.Create)))
                {
                    for (int j = 0; j < length; j++)
                    {
                        writer.Write(data[j].Number);
                        writer.Write(data[j].Text);
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
                Array.Copy(data, 5, data_string, 0, 8);

                string utfString = Encoding.UTF8.GetString(data_string, 0, data_string.Length);
                result.Text = utfString;

                return result;
            }
        }

        public void PrintFromFile(int n)
        {
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
            Console.WriteLine(result);

            //Issisaugau B i data_b
            Byte[] data_b = new Byte[13];
            fs.Seek(13 * b, SeekOrigin.Begin);
            fs.Read(data_b, 0, 13);

            result = new SortableObject();
            result.Number = BitConverter.ToInt32(data_b, 0);
            data_string = new Byte[8];
            Array.Copy(data_b, 5, data_string, 0, 8);
            utfString = Encoding.UTF8.GetString(data_string, 0, data_string.Length);
            result.Text = utfString;
            Console.WriteLine(result);

            fs.Seek(13 * b, SeekOrigin.Begin);
            fs.Write(data_a, 0, data_a.Length);

            fs.Seek(13 * a, SeekOrigin.Begin);
            fs.Write(data_b, 0, data_b.Length);

            Console.WriteLine("------------");
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
}
