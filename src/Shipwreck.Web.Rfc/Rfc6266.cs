using System.Text;

namespace Shipwreck.Web.Rfc
{
    internal static class Rfc6266
    {
        public static string GetContentDispositionHeader(string fileName)
        {
            if (fileName.IsRfc2616Token())
            {
                return "attachment;filename=" + fileName;
            }
            if (fileName.IsRfc2616AsciiChars())
            {
                var sb = new StringBuilder(32 + fileName.Length);
                sb.Append("attachment;filename=\"");
                foreach (var c in fileName)
                {
                    if (c == '\\' || c == '"')
                    {
                        sb.Append('\\');
                    }
                    sb.Append(c);
                }
                sb.Append('"');
                return sb.ToString();
            }
            else
            {
                var sb = new StringBuilder(64 + fileName.Length * 4);

                sb.Append("attachment;filename=\"");
                foreach (var c in fileName)
                {
                    if (c == '\\' || c == '"')
                    {
                        sb.Append('\\');
                    }
                    sb.Append(c);
                }
                sb.Append("\";filename*=utf-8''");

                sb.AppendRfc2231OEncodedString(fileName);

                return sb.ToString();
            }
        }
    }
}