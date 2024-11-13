using System.Web;

namespace AniWorldReminder_Webpanel.Classes
{
    public static class Extensions
    {
        public static string UrlSanitize(this string text)
        {
            return text.Replace(' ', '-')
                .Replace(":", "")
                .Replace("~", "")
                .Replace("'", "")
                .Replace(",", "")
                .Replace("’", "");
        }
        public static IEnumerable<T> GetFlags<T>(this Enum input, Enum? ignore = default)
        {
            foreach (T value in Enum.GetValues(input.GetType()))
            {
                Enum? enumVal = (Enum)Convert.ChangeType(value, typeof(Enum));
                if (!enumVal.Equals(ignore) && input.HasFlag(enumVal))
                    yield return value;
            }
        }

        public static string? HtmlDecode(this string? text)
        {
            return ( string.IsNullOrEmpty(text) ? default : HttpUtility.HtmlDecode(text) );
        }
    }
}
