using System;

namespace SharpLists
{
    class Program
    {
        static void Main (string[] args)
        {
            SLL<string> list = new SLL<string> ();
            list.Add ("hello");
            list.Add ("world");
            Console.WriteLine (list);
            list[0] = "jello";
            list.AddFront ("wacky");
            foreach (var val in list)
            {
                Console.WriteLine (val);
            }
        }
    }
}