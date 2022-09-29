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
        private List<Token> tokenList = new();

        public Guid New(string address = "")
        {
            Token token = new Token()
            {
                Value = Guid.NewGuid(),
                TokenAddress = address
            };
            tokenList.Add(token);
            return token.Value;
        }

        public IEnumerable<Token> ShowAll()
        {
            (bool Success, List<Token> Tokens) patata = TupleTest();
            if (patata.Success) Debug.WriteLine($"{nameof(patata.Tokens)} = {patata.Tokens}");
            System.Console.WriteLine(tokenList.ToJsonString());
            return tokenList;
        }

        private (bool, List<Token>) TupleTest()
        {
            return (true, tokenList);
        }
    }
}