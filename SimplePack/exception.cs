using System;


namespace simplepack{
    public class InvalidSimplePackHeader : Exception
    {
        public InvalidSimplePackHeader()
        {
        }

        public InvalidSimplePackHeader(string message)
            : base(message)
        {
        }

        public InvalidSimplePackHeader(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}

