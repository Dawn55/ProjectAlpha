using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
   public class HashingHelper
    {
        public static void CreatePasswordHash(string passworld,out byte[] passwordHash,out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(passworld));
            }
        } 
        public static bool VerifyPasswordHash(string passworld, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedhash = hmac.ComputeHash(Encoding.UTF8.GetBytes(passworld));
                for (int i = 0; i < computedhash.Length; i++)
                {
                    if (computedhash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}
