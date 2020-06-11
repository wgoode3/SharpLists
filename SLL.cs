using System;
using System.Collections;
using System.Collections.Generic;

namespace SharpLists
{
    public class SLL<T> : IEnumerable<T>
    {
        private SLNode<T> Head;
        private int _length = 0;
        IEnumerator IEnumerable.GetEnumerator ()
        {
            return (IEnumerator) GetEnumerator ();
        }
        IEnumerator<T> IEnumerable<T>.GetEnumerator ()
        {
            return (IEnumerator<T>) GetEnumerator ();
        }
        public SLLEnum<T> GetEnumerator ()
        {
            return new SLLEnum<T> (Head);
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
            _length++;
        }

        public T this [int index]
        {
            get
            {
                if (index >= _length)
                {
                    throw new IndexError (index);
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
                if (index >= _length)
                {
                    throw new IndexError (index);
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

    public class SLLEnum<T> : IEnumerator<T>
    {
        public SLNode<T> Head;
        public SLNode<T> Runner;
        public SLLEnum (SLNode<T> head)
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