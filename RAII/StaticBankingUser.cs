using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAII
{
    /// <summary>
    /// Such users are used in Shared context/fixture strategies
    /// https://xunit.github.io/docs/shared-context.html and http://xunitpatterns.com/Shared%20Fixture.html
    /// </summary>
    class StaticBankingUser
    {
        public string UserName { get; set; }
    }
}
