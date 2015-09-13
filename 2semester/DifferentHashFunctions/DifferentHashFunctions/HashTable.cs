using System;

namespace DifferentHashFunctions
{
    public class HashTable
    {
        // Constructs empty hash table
        public HashTable(int size, AbstractHashFunction hashFunction)
        {
            this.hashFunction = hashFunction;
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
            this.array[this.hashFunction.HashCode(key, this.size)].Insert(key);
        }

        // Deletes an element form the hash table by its key
        public void Delete(string key)
        {
            this.array[this.hashFunction.HashCode(key, size)].Delete(key);
        }

        // Searches an element in the hash table
        public bool Search(string key)
        {
            return this.array[this.hashFunction.HashCode(key, size)].Search(key);
        }

        private AbstractHashFunction hashFunction = null;
        private List[] array = null;
        private int size = 0;
    }
}
