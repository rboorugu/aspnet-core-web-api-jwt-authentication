namespace WebApi.Helpers
{
    public class JwtSettings
    {
        public string Site { get; set; }
        public string SigningKey { get; set; }
        public int ExpiryInMinutes { get; set; }
    }
}