using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Chorizo.Interfaces;
using Chorizo.Models;

namespace Chorizo.Services
{
    public class TokenService : ITokenService
    {
        private List<Token> _tokens;

        public TokenService()
        {
            _tokens = new List<Token>();
        }

        public Guid New(string address = "")
        {
            Token token = new Token()
            {
                Value = Guid.NewGuid(),
                TokenAddress = address
            };
            _tokens.Add(token);
            return token.Value;
        }

        public IEnumerable<Token> ShowAll()
        {
            (bool Success, List<Token> Tokens) patata = TupleTest();
            if (patata.Success) Debug.WriteLine($"{nameof(patata.Tokens)} = {patata.Tokens}");
            System.Console.WriteLine(_tokens.ToJsonString());
            return _tokens;
        }

        private (bool, List<Token>) TupleTest()
        {
            return (true, _tokens);
        }
    }
}