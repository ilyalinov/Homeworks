#include <iostream>
#include <fstream>

using namespace std;

struct ListElement
{
	int value;
	ListElement *next;
};

struct List
{
	ListElement *head;
	int size = 0;
};

List *createList()
{
	List *list = new List();
	list->head = nullptr;
	return list;
}

ListElement *createListElement(int value)
{
	ListElement *newElement = new ListElement();
	newElement->next = nullptr;
	newElement->value = value;
	return newElement;
}

void listInsert(List *list, ListElement *newElement)
{
	if (list->head == nullptr)
	{
		list->head = newElement;
	}
	else
	{
		ListElement *temp = list->head;
		while (temp->next != nullptr)
		{
			temp = temp->next;
		}
		temp->next = newElement;
	}
	list->size++;
}

void deleteList(List *list)
{
	ListElement *temp = list->head;
	while (list->head != nullptr)
	{
		ListElement *temp = list->head;
		list->head = temp->next;
		delete temp;
	}
	delete list;
	cout << "List deleted" << endl;
}

void printList(List *list)
{
	if (list->head == nullptr)
	{
		//cout << "Your list is empty" << endl;
		return;
	}
	ListElement *temp = list->head;
	cout << "Printed increasing list: " << endl;
	while (temp != nullptr)
	{
		cout << temp->value << " ";
		temp = temp->next;
	}
	cout << endl;
}

int getListSize(List *list)
{
	return list->size;
}

int getValue(ListElement *listElement)
{
	return listElement->value;
}

ListElement* getNext(ListElement *listElement)
{
	return listElement->next;
}

ListElement *getHead(List *list)
{
	return list->head;
}