using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifferentHashFunctions
{
    public class HashFunction2 : AbstractHashFunction
    {
        public int HashCode(string key, int hashTableSize)
        {
            int powerOf128 = 1;
            int result = 0;
            for (int i = key.Length - 1; i >= 0; --i)
            {
                result += powerOf128 * Convert.ToInt32(key[i]);
                powerOf128 *= 128;
            }
            return Math.Abs(result) % hashTableSize;
        }
    }
}
