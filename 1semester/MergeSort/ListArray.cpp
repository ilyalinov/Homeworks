#include <iostream>
#include <vector>
#include <fstream>

using namespace std;

struct ListArray
{
	int first = 0;
	int last = 0;
	int size = 0;
	vector<int> key;
};

ListArray* createListArray()
{
	return new ListArray();
}

void addElementByValue(ListArray* list, int value)
{
	list->key.push_back(value);
	list->last++;
	list->size++;
}

void fileToList(ifstream &file, ListArray* list)
{
	while (!file.eof())
	{
		int value = 0;
		file >> value;
		addElementByValue(list, value);
	}
	file.close();
}

bool compare(ListArray* list1, int pointer1, ListArray* list2, int pointer2)
{
	return (list1->key[pointer1] > list2->key[pointer2]);
}

int getListSize(ListArray* list)
{
	return list->size;
}

int first(ListArray *list)
{
	return 0;
}

int getValue(ListArray* list, int pointer)
{
	return list->key[pointer];
}

ListArray* divideList(ListArray* list, int startPosition, int finishPosition)
{
	ListArray* newList = createListArray();
	int temp = 0;
	while (temp < list->size)
	{
		if (temp >= startPosition && temp <= finishPosition)
		{
			addElementByValue(newList, list->key[temp]);
		}
		temp++;
	}
	return newList;
}

int getNext(int pointer)
{
	return pointer + 1;
}

void deleteList(ListArray *list)
{
	delete list;
}

bool hasNext(ListArray* list, int pointer)
{
	return (pointer < list->size);
}

void printList(ListArray* list)
{
	cout << "printed list: " << endl;
	for (int i = 0; i < list->size; ++i)
	{
		cout << list->key[i] << " ";
	}
	cout << endl;
}