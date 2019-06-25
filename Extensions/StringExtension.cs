using System;
using System.Linq;

namespace ChoosingBot.Extensions
{
    public static class StringExtension
    {
        public static string FirstCharToUpper(this string input)
        {
            if (String.IsNullOrEmpty(input))
                return input;
            return input.First().ToString().ToUpper() + input.Substring(1);
        }
    }
}