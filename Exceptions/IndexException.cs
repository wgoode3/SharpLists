using System;

namespace SharpLists.Exceptions
{
    public class IndexException : Exception
    {
        public IndexException (int index) : base ($"List index `{index}` is out of bounds!") { }
    }
}