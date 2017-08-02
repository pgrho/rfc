namespace Shipwreck.Web.Rfc
{
    internal static class Rfc1521
    {
        public static bool IsTSpecial(this char c)
        {
            switch (c)
            {
                case '(':
                case ')':
                case '<':
                case '>':
                case '@':
                case ',':
                case ';':
                case ':':
                case '\\':
                case '"':
                case '/':
                case '[':
                case ']':
                case '?':
                case '=':
                    return true;
            }
            return false;
        }
    }
}