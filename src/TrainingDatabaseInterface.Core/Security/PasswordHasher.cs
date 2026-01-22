using System;
using System.Security.Cryptography;

namespace TrainingDatabaseInterface.Core.Security;

public static class PasswordHasher
{
    private const int Iterations = 10000;
    private const int KeySize = 32;

    public static byte[] CreateSalt(int size = 16)
    {
        var salt = new byte[size];
        RandomNumberGenerator.Fill(salt);
        return salt;
    }

    public static byte[] CreateHash(string password, byte[] salt)
    {
        using var deriveBytes = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256);
        return deriveBytes.GetBytes(KeySize);
    }
}
