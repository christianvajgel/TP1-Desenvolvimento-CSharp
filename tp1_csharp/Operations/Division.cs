using System;
using System.Collections.Generic;
using System.Text;

namespace tp1_csharp
{
    public class Division
    {
        public static string Calculate(Decimal n1, Decimal n2)
        {
            if (n2 == 0)
            {
                return "0";
            }
            else
            {
                return (n1 / n2).ToString();
            }
        }
    }
}
