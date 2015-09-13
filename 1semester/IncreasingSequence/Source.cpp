#include <iostream>
#include "List.h"

using namespace std;

void main()
{
	List *list = createList();
	int size = 0;
	cout << "Enter number of list elements: " << endl;
	cin >> size;
	cout << "Enter your elements: " << endl;
	for (int i = 0; i < size; i++)
	{
		int temp = 0;
		cin >> temp;
		listInsert(list, createListElement(temp));
	}
	int startPosition = 0;
	int maxStartPosition = 0;
	int length = 1;
	int maxLength = 1;
	ListElement* temp = getHead(list);
	for (int i = 1; i < getListSize(list); ++i)
	{
		if (getValue(getNext(temp)) > getValue(temp))
		{
			length++;
			if (length > maxLength)
			{
				maxLength = length;
				maxStartPosition = startPosition;
			}
		}
		else
		{
			length = 1;
			startPosition = i;
		}
		temp = getNext(temp);
	}
	List *list1 = createList();
	temp = getHead(list);
	for (int j = 0; j < getListSize(list); ++j)
	{
		if (j == maxStartPosition)
		{
			for (j = 0; j < maxLength; j++)
			{
				listInsert(list1, createListElement(getValue(temp)));
				temp = getNext(temp);
			}
			break;
		}
		temp = getNext(temp);
	}
	printList(list1);
	deleteList(list);
	deleteList(list1);
}