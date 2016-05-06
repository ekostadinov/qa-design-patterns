using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponcibility.DomainObjects
{
    class BasicUser : IUser
    {
        public string UserName{get; set; }
        public string PlayerId { get; set; }

    }
}
