using Konscious.Security.Cryptography;
using MyRecipeBook.Domain.Security.PasswordHashing;
using System.Security.Cryptography;
using System.Text;

namespace MyRecipeBook.Infrastructure.Security.PasswordHashing;

internal sealed class Argon2PasswordHasher : IPasswordHashing
{
    private const int DREGREE_OF_PARALLELISM = 1; // Number of threads to use
    private const int INTERATIONS = 2;
    private const int MEMORY_SIZE = 20 * 1024; //20mb   
    private const int SALT_SIZE = 16;
    private const int HASH_SIZE = 32;
    public string HashPassword(string password)
    {
        var salt = RandomNumberGenerator.GetBytes(SALT_SIZE);

        var passwordBytes = Encoding.UTF8.GetBytes(password);
        var hashAlgorithm = new Argon2id(passwordBytes)
        {
            DegreeOfParallelism = DREGREE_OF_PARALLELISM,
            Iterations = INTERATIONS,
            MemorySize = MEMORY_SIZE,
            Salt = salt
        };

        var hash = HashPassword(password, salt);
        var combinedBytes = new byte[hash.Length * salt.Length];

        salt.CopyTo(combinedBytes);
        hash.CopyTo(combinedBytes, index: salt.Length);
        return Convert.ToBase64String(combinedBytes);
    } 
     
    public bool VerifyPassword(string password, string passwordHash)
    {
        var combinedBytes = Convert.FromBase64String(passwordHash);

        var salt = new byte[SALT_SIZE];
        var hash = new byte[HASH_SIZE];

        Array.Copy(combinedBytes, salt, SALT_SIZE);
        Array.Copy(combinedBytes, SALT_SIZE, hash, 0, HASH_SIZE);

        var newHash = HashPassword(password, salt);

        return CryptographicOperations.FixedTimeEquals(hash, newHash);

    }

     private byte[] HashPassword(string password, byte[] salt)
    {
        var passwordBytes = Encoding.UTF8.GetBytes(password);
        var hashAlgorithm = new Argon2id(passwordBytes)
        {
            DegreeOfParallelism = DREGREE_OF_PARALLELISM,
            Iterations = INTERATIONS,
            MemorySize = MEMORY_SIZE,
            Salt = salt
        };
        return hashAlgorithm.GetBytes(HASH_SIZE);
    }
}
