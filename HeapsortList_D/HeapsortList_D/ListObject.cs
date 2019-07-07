using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HeapsortList_D
{
    public class ListObject : IEnumerable<SortableObject>
    {
        int currentNode;
        SortableObject currentObject;
        string Filename;
        int length;

        public FileStream fs { get; set; }

        public ListObject(string filename, int n, int seed)
        {
            this.length = n;
            this.Filename = filename;
            Random rand = new Random(1);
            if (File.Exists(filename)) File.Delete(filename);
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(filename,
               FileMode.Create), Encoding.Unicode))
                {
                    for (int j = 0; j < n; j++)
                    {
                        writer.Write(j);
                        writer.Write(rand.Next(1, 100));

                        string word = String.Empty;
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

            //*********************************************

            fs = new FileStream(Filename, FileMode.Open);
            /*
            Byte[] data = new Byte[26];
            fs.Seek(0, SeekOrigin.Begin);
            fs.Read(data, 0, 26);
            int next = BitConverter.ToInt32(data, 0);
            int number = BitConverter.ToInt32(data, 4);

            Byte[] data_string = new Byte[16];
            Array.Copy(data, 9, data_string, 0, 16);

            string utfString = Encoding.UTF8.GetString(data_string, 0, data_string.Length);

            Console.WriteLine("INIT {0} {1} {2}", next, number, utfString);
            */
            //********************************************

          
        }

        public void Print()
        {
           // foreach (SortableObject current in this)
          //  {
                //Console.WriteLine(current.ToString());
          //  }
        }

        public bool IsLeftBigger(int a, int b)
        {
          // Console.WriteLine("WE ARE IN THERE");

            SortableObject aObj = null;
            SortableObject bObj = null;

            bool aFound = false;
            bool bFound = false;

            foreach (SortableObject current in this)
            {
                if (currentNode == a)
                { aObj = currentObject; aFound = true; }

                if (currentNode == b)
                { bObj = currentObject; bFound = true; }
            }

            if (!bFound || !aFound)
            {
               // Console.WriteLine("fak");

                return true;
            }

        //    Console.WriteLine("DU OBIJEKTAI");
         //   Console.WriteLine("{0} {1}", aObj.ToString(), bObj.ToString());

            return aObj > bObj;
        }

        public void Swap(int a, int b)
        {
            //Issisaugau A i data_a
            Byte[] data_a = new Byte[26];
            fs.Seek(25 * a, SeekOrigin.Begin);
            fs.Read(data_a, 0, 26);

            //Issisaugau B i data_b
            Byte[] data_b = new Byte[26];
            fs.Seek(25 * b, SeekOrigin.Begin);
            fs.Read(data_b, 0, 26);

            fs.Seek(25 * b, SeekOrigin.Begin);
            fs.Write(data_a, 0, data_a.Length);

            fs.Seek(25 * a, SeekOrigin.Begin);
            fs.Write(data_b, 0, data_b.Length);
        }

        public void Next()
        {
            Byte[] data = new Byte[26];
            fs.Seek(25 * currentNode, SeekOrigin.Begin);
            fs.Read(data, 0, 26);
            int next = BitConverter.ToInt32(data, 0);
            int number = BitConverter.ToInt32(data, 4);

            Byte[] data_string = new Byte[16];
            Array.Copy(data, 9, data_string, 0, 16);
            string utfString = Encoding.UTF8.GetString(data_string, 0, data_string.Length);

           // Console.WriteLine("THIS IS HEAD {0} {1} {2}", next, number, utfString);

            this.currentObject = new SortableObject(next, number, utfString);
        }

        IEnumerator<SortableObject> IEnumerable<SortableObject>.GetEnumerator()
        {
            currentNode = 0;
            while (currentNode < length)
            {
                //Console.WriteLine(currentNode);
                Next();
                yield return currentObject;
                this.currentNode++;

            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
