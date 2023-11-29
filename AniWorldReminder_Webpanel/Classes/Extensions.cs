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
    }
}
