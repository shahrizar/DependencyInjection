using System.Threading.Tasks;

namespace DI.Services
{
    public interface IShortenURL
    {
        Task<string> TinyURL(string URL);
    }
}