#include <iostream>
#include <string>
#include <fstream>

using namespace std;

struct ListElement
{
	int value = 0;
	int position = 0;
	ListElement *next = nullptr;
};

struct List
{
	ListElement *first = nullptr;
	int size = 0;
	ListElement *last = nullptr;
};

List* createList()
{
	return new List();
}

ListElement* createListElement(int value)
{
	ListElement *newElement = new ListElement();
	newElement->value = value;
	return newElement;
}

void addElementByValue(List *list, int value)
{
	if (list->first == nullptr)
	{
		ListElement *newElement = new ListElement();
		newElement->value = value;
		newElement->position = list->size;
		list->first = newElement;
		list->last = list->first;
	}
	else
	{
		ListElement *newElement = new ListElement();
		newElement->value = value;
		newElement->position = list->size;
		list->last->next = newElement;
		list->last = list->last->next;
	}
	list->size++;
}

void addElement(List *list, ListElement *listElement)
{
	if (list->first == nullptr)
	{
		list->first = new ListElement();
		list->first->value = listElement->value;
		list->first->position = list->size;
		list->first->next = nullptr;
		list->last = list->first;
	}
	else
	{
		list->last->next = new ListElement();
		list->last->next->value = listElement->value;
		list->last->next->position = list->size;
		list->last = list->last->next;
		list->last->next = nullptr;
	}
	list->size++;
}

void fileToList(ifstream &file, List *list)
{
	while (!file.eof())
	{
		int value = 0;
		file >> value;
		addElementByValue(list, value);
	}
	file.close();
}

void printList(List *list)
{
	if (list->first == nullptr)
	{
		cout << "Your list is empty" << endl;
		return;
	}
	ListElement *temp = list->first;
	cout << "Printed list : " << endl;
	while (temp != nullptr)
	{
		cout << temp->value << " ";
		temp = temp->next;
	}
}

bool compare(List* list1, ListElement *listElement1, List *list2, ListElement *listElement2)
{
	return (listElement1->value > listElement2->value);
}

int getListSize(List *list)
{
	return list->size;
}

int getValue(List* list, ListElement *listElement)
{
	return listElement->value;
}

ListElement* first(List *list)
{
	return list->first;
}

List* divideList(List *list, int startPosition, int finishPosition)
{
	List* newList = createList();
	ListElement *temp = list->first;
	while (temp != nullptr)
	{
		if (temp->position >= startPosition && temp->position <= finishPosition)
		{
			addElementByValue(newList, temp->value);
		}
		temp = temp->next;
	}
	return  newList;
}

ListElement* getNext(ListElement *listElement)
{
	return listElement->next;
}

void deleteList(List *list)
{
	while (list->first != nullptr)
	{
		ListElement *temp = list->first;
		list->first = list->first->next;
		delete temp;
	}
	delete list;
}

bool hasNext(List* list, ListElement* listElement)
{
	return (listElement != nullptr);
}