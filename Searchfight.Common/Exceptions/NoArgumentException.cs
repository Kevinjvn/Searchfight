using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searchfight.Common.Exceptions
{
    public class NoArgumentException : Exception
    {
        public NoArgumentException() : base()
        {

        }

        public NoArgumentException(string message) : base(message)
        {

        }

        public NoArgumentException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
