using System.Linq;
using System.Security.Cryptography;
using System.Text;
using UrlShortener.Services.Contracts;

namespace UrlShortener.Services
{
    public class HashGeneratorService: IHashGeneratorService
    {
        public string GetShortenedUrl(string input)
        {
            var hash = new SHA1Managed().ComputeHash(Encoding.UTF8.GetBytes(input));
            return string.Concat(hash.Select(b => b.ToString("x2")));
        }
    }
}