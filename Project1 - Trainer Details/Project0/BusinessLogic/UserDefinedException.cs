using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    class UserDefinedException:Exception
    {
        public UserDefinedException()
        {
            throw new InvalidDataException("Please enter correct format");
        }
        public UserDefinedException(string s)
        {
            throw new InvalidDataException(s);
        }
    }
}
