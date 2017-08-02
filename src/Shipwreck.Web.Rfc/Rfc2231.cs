using System.Text;

namespace Shipwreck.Web.Rfc
{
    internal static class Rfc2231
    {
        private const string HEX = "0123456789ABCDEF";

        public static void AppendRfc2231OEncodedString(this StringBuilder sb, string value)
        {
            var bytes = new UTF8Encoding(false).GetBytes(value);

            foreach (var b in bytes)
            {
                var c = (char)b;
                if (c.IsRfc2616AsciiChar() && !c.IsRfc2616ControlChar() && c != ' ' && c != '*' && c != '\'' && c != '%' && !c.IsTSpecial())
                {
                    sb.Append(c);
                }
                else
                {
                    sb.Append('%');
                    sb.Append(HEX[b >> 4]);
                    sb.Append(HEX[b % 16]);
                }
            }
        }
    }
}