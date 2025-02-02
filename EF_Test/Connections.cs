using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Test
{
    internal static class Connections
    {
        public const string sqlConStr = """
               Server=DESKTOP-7VJ1824;
               Database=dbEfTest;
               Integrated Security=True;
               TrustServerCertificate=True;
            """;
    }
}