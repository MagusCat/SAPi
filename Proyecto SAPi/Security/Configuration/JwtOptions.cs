namespace Proyecto_SAPi.Security.Configuration
{
    public class JwtOptions
    {
        public string Key { get; set; } = string.Empty;

        public byte[] GetKey()
        {
            return Convert.FromBase64String(Key);
        }
    }
}
