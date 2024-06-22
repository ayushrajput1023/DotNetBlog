using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWebAPI.Exceptions
{
    public class ZeroInputException : Exception
    {
        public ZeroInputException(string msg) : base(msg)
        {

        }
    }
}
