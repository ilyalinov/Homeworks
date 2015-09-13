#include <iostream>
#include <fstream>
#include <string>

using namespace std;

#include "HashTable.h"

void main()
{
	HashTable *hashTable = createHashTable();
	ifstream file("Text.txt", ios::in);
	while (!file.eof())
	{
		string buffer;
		file >> buffer;
		if (!buffer.empty())
		{
			addElement(hashTable, buffer);
		}
	}
	printHashTable(hashTable);
	deleteHashTable(hashTable);
}

// Size of hashTable is a constant. hashTable->size == 100.  