using System;
using System.Collections;
using System.Collections.Generic;
using SharpLists.Exceptions;

namespace SharpLists
{
    public class SLL<T> : IEnumerable<T>
    {

        private SLNode<T> Head;
        private int _size = 0;

        public int Size {
            get {
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
        public void AddFront (T value)
        {
            SLNode<T> node = new SLNode<T> (value);
            node.Next = Head;
            Head = node;
        }

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

    public class SLLEnumumerator<T> : IEnumerator<T>
    {

        public SLNode<T> Head;
        public SLNode<T> Runner;

        public SLLEnumumerator (SLNode<T> head)
        {
            Head = head;
        }

        public bool MoveNext ()
        {
            if (Runner == null)
            {
                Runner = Head;
            }
            else
            {
                Runner = Runner.Next;
            }
            return Runner != null;
        }

        public void Reset ()
        {
            Runner = null;
        }

        public T Current
        {
            get
            {
                try
                {
                    return Runner.Value;
                }
                catch (NullReferenceException)
                {
                    throw new InvalidOperationException ();
                }
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public void Dispose () { }

    }
}