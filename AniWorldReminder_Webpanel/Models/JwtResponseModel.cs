namespace AniWorldReminder_Webpanel.Models
{
    public class JwtResponseModel
    {
        public JwtResponseModel(string token)
        {
            Token = token;
        }

        public string Token { get; init; }
    }
}
