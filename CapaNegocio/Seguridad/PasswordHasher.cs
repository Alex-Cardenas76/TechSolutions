using System;
using System.Security.Cryptography;
using System.Text;

namespace CapaNegocio.Seguridad
{
    public static class PasswordHasher
    {
        public static byte[] HashPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("La contraseña no puede estar vacía");

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                return sha256.ComputeHash(bytes);
            }
        }

        public static bool VerifyPassword(string password, byte[] hash)
        {
            if (string.IsNullOrWhiteSpace(password))
                return false;

            byte[] passwordHash = HashPassword(password);
            
            if (passwordHash.Length != hash.Length)
                return false;

            for (int i = 0; i < passwordHash.Length; i++)
            {
                if (passwordHash[i] != hash[i])
                    return false;
            }

            return true;
        }
    }
}
