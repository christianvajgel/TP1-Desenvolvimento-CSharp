using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace tp1_csharp
{
    public class Parsing
    {
        public static List<Decimal> StringToDecimal(string n)
        {
            List<Decimal> result = new List<Decimal>();
            try
            {
                var number = Decimal.Parse(n);
                result.Add(number);
                return result;
            }
            catch (FormatException)
            {
                return null;
            }
        }

        public static List<int> StringToInt(string n)
        {
            List<int> result = new List<int>();
            try
            {
                var number = Int32.Parse(n);
                result.Add(number);
                return result;
            }
            catch (FormatException)
            {
                return null;
            }
        }

        public static bool ValidateNumber(string possibleNumber)
        {
            return Regex.IsMatch(possibleNumber, @"^[0-9+-.]+$");
        }
    }
}
