using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myexceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException() : base("User ID not found in the database.") { }

        public UserNotFoundException(string message) : base(message) { }

    }
}
