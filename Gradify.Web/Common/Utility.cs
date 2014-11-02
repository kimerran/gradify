using System.Linq;

namespace Gradify.Web.Common
{
    public class Utility
    {
        private const string salt = "gradify. grade it to me gently.";
        private const int additive = 11282010;

        public static string GenerateHash(int id)
        {
            var hashIdGen = new HashidsNet.Hashids(salt);

            return hashIdGen.Encode(id + additive);
        }

        public static int ResolveId(string shortUrl)
        {
            var hashIdGen = new HashidsNet.Hashids(salt);
            var output = hashIdGen.Decode(shortUrl);

            if (output.Any())
            {
                return output.First() - additive;
            }

            return 0;
        }
    }
}