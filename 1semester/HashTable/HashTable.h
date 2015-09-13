#pragma once
#include <vector>

using namespace std;

// Hash table structure
struct HashTable;

// Creates empty hash table
HashTable *createHashTable();

// get key and hash function from string
int hashFunction(string value);

// Add element to hash table
void addElement(HashTable *, string);

// print all hash table to console
void printHashTable(HashTable *);

// Delete all hash table
void deleteHashTable(HashTable *);