using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace FinalProject.ViewModel
{
    public class HashingClass
    {
        static string Hashing(string password)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] inArray = HashAlgorithm.Create("SHA256").ComputeHash(bytes);
            return Convert.ToBase64String(inArray);
        }
    }
}
