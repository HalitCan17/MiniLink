using MiniLink.Contracts; 

namespace MiniLink.Services
{
    
    public class UrlShorteningService : IUrlShorteningService
    {
        
        private const string Alphabet = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private readonly Random _random = new();

        public string GenerateUniqueCode()
        {
            var codeChars = new char[6];
            for (int i = 0; i < codeChars.Length; i++)
            {
                var randomIndex = _random.Next(Alphabet.Length);
                codeChars[i] = Alphabet[randomIndex];
            }
            return new string(codeChars);
        }
    }
}