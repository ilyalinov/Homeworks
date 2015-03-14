using System;

namespace HashTable
{
    class HashTable
    {
        // Constructs empty hash table
        public HashTable(int size)
        {
            this.size = size;
            this.array = new List[size];
            for (int i = 0; i < size; ++i)
            {
                this.array[i] = new List();
            }
        }

        // Inserts an element in the hash table
        public void Insert(string key)
        {
            this.array[this.HashFunction(key)].Insert(key);
        }

        // Deletes an element form the hash table by its key
        public void Delete(string key)
        {
            this.array[this.HashFunction(key)].Delete(key);
        }

        // Searches an element in the hash table
        public bool Search(string key)
        {
            return this.array[this.HashFunction(key)].Search(key);
        }

        // Hash function for strings
        private int HashFunction(string key)
        {
            int powerOf128 = 1;
            int result = 0;
            for (int i = key.Length - 1; i >= 0; --i)
            {
                result += powerOf128 * Convert.ToInt32(key[i]);
                powerOf128 *= 128;
            }
            return result % this.size;
        }

        private List[] array;
        private int size;
    }
}
