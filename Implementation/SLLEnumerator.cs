using System;
using System.Collections;
using System.Collections.Generic;

namespace SharpLists
{
    public class SLLEnumumerator<T> : IEnumerator<T>
    {

        public SLNode<T> Head;
        public SLNode<T> Runner;

        public SLLEnumumerator(SLNode<T> head)
        {
            Head = head;
        }

        public bool MoveNext()
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

        public void Reset()
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
                    throw new InvalidOperationException();
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

        public void Dispose() { }

    }
}