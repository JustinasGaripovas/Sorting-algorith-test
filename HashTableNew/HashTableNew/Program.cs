using System;
using System.Diagnostics;

namespace HashTableNew
{
    class Mail
    {
        static public string from;
        static public string to;
        static public string subject;

        static public void Send()
        {
            return null;
        }

    }
    class Visitor
    {
        static public bool haveQuestions;
    }
    class MainClass
    {
        public static void Main(string[] args)
        {
            Visitor visitor = new Visitor();
            if(visitor.haveQuestions == true)
            {
                Mail.from = "INSERT YOUR EMAIL";
                Mail.to = "justinas.garipovas@gmail.com";
                Mail.subject = Console.ReadLine();
                Mail.Send();
            }
            else
            {
                Console.WriteLine( "Thanks for visiting. :)" );
            }

            int seed = (int)DateTime.Now.Ticks & 0x0000FFFF;

            seed = 0;

            Console.WriteLine("List hash table search \n    N");
            Test_Table(seed, 400);
            Test_Table(seed, 800);
            Test_Table(seed, 1600);
            Test_Table(seed, 3200);
            Test_Table(seed, 6400);
            Test_Table(seed, 12800);
            Test_Table(seed, 25600);
            Test_Table(seed, 51200);

           
            }

        public static void Test_Table(int seed, int n)
        {
            Stopwatch sw = new Stopwatch();
            
            HashTableWithLinkedList table = new HashTableWithLinkedList(100);

            SortableObject temp = new SortableObject();
            Random rand = new Random(seed);

            for (int j = 0; j < n; j++)
            {

                temp = new SortableObject();

                temp.Number = rand.Next(1, 100);

                string word = "";
                for (int text = 0; text < 8; text++)
                {
                    word += (char)rand.Next(65, 90);
                }

                temp.Text = word;

                table.Add(temp);
                            }

            //Console.WriteLine("Branch count {0}", table.BranchCount());

            SortableObject toFind = new SortableObject(78, "DNSBOFYT");

            sw.Start();

            bool doesContain = table.Contains(toFind);

            sw.Stop();


            Console.WriteLine("{1,9} took => {0}", sw.Elapsed, n);
        }
    }
}
