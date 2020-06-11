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

        public int Size
        {
            get
            {
                return _size;
            }
        }

        IEnumerator IEnumerable.GetEnumerator ()
        {
            return (IEnumerator) GetEnumerator ();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator ()
        {
            return (IEnumerator<T>) GetEnumerator ();
        }

        public SLLEnumumerator<T> GetEnumerator ()
        {
            return new SLLEnumumerator<T> (Head);
        }

        /// <summary>Quickly adds a value to the start of the list</summary>
        public void AddFront (T value)
        {
            SLNode<T> node = new SLNode<T> (value);
            node.Next = Head;
            Head = node;
            _size++;
        }

        /// <summary>Slowly adds a value to the end of the list</summary>
        public void Add (T value)
        {
            var node = new SLNode<T> (value);
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
            if(runner.Value.Equals(val))
            {
                Head = Head.Next;
                _size--;
                return true;
            }
            while(runner.Next != null)
            {
                if(runner.Next.Value.Equals(val))
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
            if(index > _size)
            {
                throw new IndexException(index);
            }
            if(index == 0) 
            {
                temp = Head.Value;
                Head = Head.Next;
                _size--;
                return temp;
            }
            var runner = Head;
            for(int i=1; i<index; i++)
            {
                runner = runner.Next;
            }
            temp = runner.Next.Value;
            runner.Next = runner.Next.Next;
            _size--;
            return temp;
        }

        public T this [int index]
        {
            get
            {
                if (index >= _size)
                {
                    throw new IndexException (index);
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
                    throw new IndexException (index);
                }
                var runner = Head;
                for (int i = 0; i < index; i++)
                {
                    runner = runner.Next;
                }
                runner.Value = value;
            }
        }

        public override string ToString ()
        {
            string result = "[ ";
            var runner = Head;
            while (runner.Next != null)
            {
                result += $"{runner.Value}, ";
                runner = runner.Next;
            }
            result += $"{runner.Value} ]";
            return result;
        }

    }

}