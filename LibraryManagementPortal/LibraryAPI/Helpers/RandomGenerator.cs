using System;

namespace LibraryAPI.Helpers
{
    public static class RandomGenerator
    {
        public static string GenerateToken()
        {
            return Convert.ToBase64String(Guid.NewGuid().ToByteArray());
        }
    }
}