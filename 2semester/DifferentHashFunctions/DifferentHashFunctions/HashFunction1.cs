using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifferentHashFunctions
{
    public class HashFunction1 : AbstractHashFunction
    {
        public int HashCode(string key, int hashTableSize)
        {
            int result = 0;
            for (int i = 0; i < key.Length; ++i)
            {
                result += Convert.ToInt32(key[i]);
            }
            return Math.Abs(result) % hashTableSize;
        }
    }
}
