using System.Text;

namespace CarsFactory.Utilities.Extensions
{
    public static class StringExtensions
    {
        public static string DivideWordsByCapitalLetters(this string input)
        {
            var builder = new StringBuilder();

            foreach (var ch in input)
            {
                if (char.IsUpper(ch) && builder.Length > 0)
                {
                    builder.Append(" ");
                }

                builder.Append(ch);
            }

            return builder.ToString();
        }
    }
}
