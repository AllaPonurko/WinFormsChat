using System;
using System.Collections.Generic;
using System.Text;

namespace Lib.Entities
{
    [Serializable]
    public class Auth
    {
       public string Email { get; set; }
       public string Pass { get; set; }
        public override string ToString()
        {
            return Email;
        }
    }
}
