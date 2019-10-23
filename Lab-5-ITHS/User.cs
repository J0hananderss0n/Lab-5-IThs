using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5_ITHS
{
    class User
    {
        public string name;
        public string email;

        public User(string name, string email)
        {
            this.name = name;
            this.email = email;
        }
        public override string ToString()
        {
            return name;
        }
    }
}
