
using Chorizo.Models;

namespace Chorizo.Interfaces
{
    public interface ITokenService
    {
        public IEnumerable<Token> ShowAll();
        public Guid New(string address);
    }
}