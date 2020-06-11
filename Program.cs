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
            list[0] = "jello";
            list.AddFront ("wacky");
            Console.WriteLine (list);
            list.RemoveAt (2);
            foreach (var val in list)
            {
                Console.WriteLine (val);
            }
            SLL<int> numbers = new SLL<int> { 1, 2, 4, 5 };
            Console.WriteLine (numbers);
        }
    }
}