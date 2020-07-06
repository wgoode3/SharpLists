using System;

namespace SharpLists
{
    class Program
    {
        static void Main(string[] args)
        {
            SLL<string> list = new SLL<string>();
            list.Add("hello");
            list.Push("world");
            list[0] = "jello";
            list.Add("wacky");
            Console.WriteLine(list);
            list.RemoveAt(2);
            foreach (var val in list)
            {
                Console.WriteLine(val);
            }
            SLL<int> numbers = new SLL<int> { 1, 2, 4, 5 };
            numbers.Reverse();
            Console.WriteLine(numbers);
            SLL<char> l1 = new SLL<char> { 'c', 'b', 'a' };
            SLL<char> l2 = new SLL<char> { 'f', 'e', 'd' };
            l1 += l2;
            Console.WriteLine(l1.ToString(""));
        }
    }
}