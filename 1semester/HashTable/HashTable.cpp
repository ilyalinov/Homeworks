#include <iostream>
#include <vector>
#include <string>

using namespace std;

#include "List.h"

struct HashTable
{
	vector<List *> array;
	int size;
};

HashTable *createHashTable()
{
	vector<List *> myVector;
	const unsigned int size = 100;
	myVector.resize(size);
	for (unsigned i = 0; i < size; ++i)
	{
		myVector[i] = createList();
	}
	HashTable *hashTable = new HashTable();
	hashTable->array = myVector;
	hashTable->size = size;
	return hashTable;
}

int hashFunction(string value)
{
	const unsigned int size = 100;
	unsigned long int result = 0;
	unsigned long int temp = 1;
	unsigned int power = 2;
	for (unsigned i = value.length() - 1; i > 0; --i)
	{
		int charToInt = int(value[i]);
		result = result + charToInt * temp;
		temp = temp * power;
	}
	return result % size;
}

void addElement(HashTable *hashTable, string value)
{
	ListElement *newElement = createListElement(value);
	listInsert(hashTable->array[hashFunction(value)], newElement);
}

void printHashTable(HashTable *hashTable)
{
	cout << "Printed hash table: " << endl;
	for (unsigned i = 0; i < hashTable->size; i++)
	{
		printList(hashTable->array[i]);
	}
}

void deleteHashTable(HashTable *hashTable)
{
	for (unsigned i = 0; i < hashTable->size; i++)
	{
		deleteList(hashTable->array[i]);
	}
	delete hashTable;
	cout << "Hash table deleted" << endl;
}