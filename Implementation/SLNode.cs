namespace SharpLists
{
    public class SLNode<T>
    {

        public T Value;
        public SLNode<T> Next;

        public SLNode(T value)
        {
            Value = value;
        }

    }
}