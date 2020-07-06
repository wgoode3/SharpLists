using System;
using System.Collections;
using System.Collections.Generic;
using SharpLists.Exceptions;

namespace SharpLists
{
    /// <summary>Singly Linked List Class with Indexing and IEnumerable</summary>
    public class SLL<T> : IEnumerable<T>
    {

        private SLNode<T> Head;
        private int _size = 0;

        /// <summary>Returns the number of values stored in the SLL</summary>
        public int Size
        {
            get
            {
                return _size;
            }
        }

        public SLLEnumumerator<T> GetEnumerator() => new SLLEnumumerator<T>(Head);

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator) GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return (IEnumerator<T>) GetEnumerator();
        }

        /// <summary>Quickly adds a value to the start of the list</summary>
        public void Add(T value)
        {
            SLNode<T> node = new SLNode<T>(value);
            node.Next = Head;
            Head = node;
            _size++;
        }

        /// <summary>Slowly adds a value to the end of the list</summary>
        public void Push(T value)
        {
            var node = new SLNode<T>(value);
            if (Head == null)
            {
                Head = node;
                return;
            }
            var runner = Head;
            while (runner.Next != null)
            {
                runner = runner.Next;
            }
            runner.Next = node;
            _size++;
        }

        /// <summary><para>Removes the first instance of the value from the list</para>
        /// <para>returns true if a value is removed false otherwise</para></summary>
        public bool Remove(T val)
        {
            var runner = Head;
            if (runner.Value.Equals(val))
            {
                Head = Head.Next;
                _size--;
                return true;
            }
            while (runner.Next != null)
            {
                if (runner.Next.Value.Equals(val))
                {
                    runner.Next = runner.Next.Next;
                    _size--;
                    return true;
                }
                runner = runner.Next;
            }
            return false;
        }

        /// <summary><para>Removes the value at the provided index</para>
        /// <para>returns the value removed</para></summary>
        public T RemoveAt(int index)
        {
            T temp = default(T);
            if (index > _size)
            {
                throw new IndexException(index);
            }
            if (index == 0)
            {
                temp = Head.Value;
                Head = Head.Next;
                _size--;
                return temp;
            }
            var runner = Head;
            for (int i = 1; i < index; i++)
            {
                runner = runner.Next;
            }
            temp = runner.Next.Value;
            runner.Next = runner.Next.Next;
            _size--;
            return temp;
        }

        /// <summary>Reverse the order of values in the SLL</summary>
        public void Reverse()
        {
            SLNode<T> prev = null, curr = Head, next = null;
            while (curr != null)
            {
                next = curr.Next;
                curr.Next = prev;
                prev = curr;
                curr = next;
            }
            Head = prev;
        }

        public T this [int index]
        {
            get
            {
                if (index >= _size)
                {
                    throw new IndexException(index);
                }
                var runner = Head;
                for (int i = 0; i < index; i++)
                {
                    runner = runner.Next;
                }
                return runner.Value;
            }
            set
            {
                if (index >= _size)
                {
                    throw new IndexException(index);
                }
                var runner = Head;
                for (int i = 0; i < index; i++)
                {
                    runner = runner.Next;
                }
                runner.Value = value;
            }
        }

        public static SLL<T> operator +(SLL<T> list1, SLL<T> list2)
        {
            var runner = list1.Head;
            while (runner.Next != null)
            {
                runner = runner.Next;
            }
            runner.Next = list2.Head;
            list1._size += list2._size;
            return list1;
        }

        public static SLL<T> operator +(SLL<T> list, T value)
        {
            var runner = list.Head;
            while (runner.Next != null)
            {
                runner = runner.Next;
            }
            runner.Next = new SLNode<T>(value);
            list._size++;
            return list;
        }

        // overloaded so a user can add a value to the beginning of the list like so
        // SLL<int> list1 = new SLL<int>(){ 1, 2, 3};
        // list1 = 4 + list1;
        public static SLL<T> operator +(T value, SLL<T> list)
        {
            SLNode<T> node = new SLNode<T>(value);
            node.Next = list.Head;
            list.Head = node;
            list._size++;
            return list;
        }

        /// <summary>default string representation using String.Join</summary>
        public override string ToString() => "[ " + String.Join(", ", this) + " ]";

        /// <summary>specify the string seperator</summary>
        public string ToString(string separator) => "[ " + String.Join(separator, this) + " ]";

        /// <summary>specify the string seperator, string prefix, and string suffix</summary>
        public string ToString(string separator, string prefix, string suffix) => prefix + String.Join(separator, this) + suffix;

        public List<T> ToList()
        {
            List<T> list = new List<T>();
            var runner = Head;
            while (runner != null)
            {
                list.Add(runner.Value);
                runner = runner.Next;
            }
            return list;
        }

        public T[] ToArray()
        {
            T[] array = new T[_size];
            var runner = Head;
            for (int i = 0; i < _size; i++)
            {
                array[i] = runner.Value;
                runner = runner.Next;
            }
            return array;
        }

    }
}