namespace RasDoc.API.Extensions
{
    public class AppSettings
    {
        public string? Secret { get; set; } // chave de criptografia do token
        public int ExpiracaoHoras { get; set; }
        public string? Emissor { get; set; }
        public string? ValidoEm { get; set; }
    }
}
