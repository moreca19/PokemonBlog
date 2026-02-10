using Microsoft.AspNetCore.Authentication;
using System.Security.Cryptography;
using PokemonBlog.Interfaces;
using PokemonBlog.Models;
using PokemonBlog.Dto;
using Microsoft.EntityFrameworkCore;
using PokemonBlog.Data;
using System;
using System.Security.Cryptography.X509Certificates;

namespace PokemonBlog.Services
{
    public class PasswordService : IPasswordService
    {
        


        private const int SaltSize = 16;
        private const int HashSize = 32;
        private const int Iterations = 100000;

        private static readonly HashAlgorithmName Algorithm = HashAlgorithmName.SHA512;


        public string Hash(string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, Algorithm, HashSize);

            return $"{Convert.ToHexString(hash)}-{Convert.ToHexString(salt)}";

        }

        public bool Verify(string password, string passwordhash) 
        {
            string[] Parts = passwordhash.Split('-');
            byte[] Hash = Convert.FromHexString(Parts[0]);
            byte[] Salt = Convert.FromHexString(Parts[1]);

            byte[] InputHash = Rfc2898DeriveBytes.Pbkdf2(password, Salt,Iterations,Algorithm, HashSize);
            return CryptographicOperations.FixedTimeEquals(Hash, InputHash);
        }

       

    }
}
