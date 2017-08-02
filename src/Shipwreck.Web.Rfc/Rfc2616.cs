namespace Shipwreck.Web.Rfc
{
    internal static class Rfc2616
    {
        #region string functions

        public static bool IsRfc2616AsciiChars(this string s)
        {
            if (!(s?.Length > 0))
            {
                return false;
            }
            foreach (var c in s)
            {
                if (!c.IsRfc2616AsciiChar())
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsRfc2616Token(this string s)
        {
            if (!(s?.Length > 0))
            {
                return false;
            }
            foreach (var c in s)
            {
                if (!c.IsRfc2616AsciiChar() || c.IsRfc2616ControlChar() || c.IsRfc2616SeparatorChar())
                {
                    return false;
                }
            }
            return true;
        }

        #endregion string functions

        #region char functions

        public static bool IsRfc2616AsciiChar(this char c) => c <= '\x7f';

        public static bool IsRfc2616ControlChar(this char c) => c <= '\x1f';

        public static bool IsRfc2616SeparatorChar(this char c)
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
                case '{':
                case '}':
                case ' ':
                case '\t':
                    return true;
            }
            return false;
        }

        #endregion char functions
    }
}