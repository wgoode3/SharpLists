using System;

namespace SharpLists
{
    public class IndexError : Exception
    {
        public IndexError (int index) : base ($"List index `{index}` is out of bounds!") { }
    }
}