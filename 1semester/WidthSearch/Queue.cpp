#include <iostream>

using namespace std;

#include <iostream>
#include <string>

using namespace std;

struct ListElement
{
	int value;
	int quantity;
	ListElement *next;
};

struct List
{
	ListElement *head;
	ListElement *last;
	int size;
};

List *createList()
{
	List *list = new List();
	list->head = nullptr;
	list->last = nullptr;
	list->size = 0;
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
		list->last = list->head;
	}
	else
	{
		list->last->next = newElement;
		list->last = list->last->next;
	}
	++list->size;
}

int deleteFirst(List *list)
{
	int result = -1;
	if (list->head != nullptr)
	{
		result = list->head->value;
		ListElement *temp = list->head;
		list->head = temp->next;
		delete temp;
		list->size--;
	}
	return result;
}

bool isEmpty(List *list)
{
	if (list->head == nullptr)
	{
		return true;
	}
	return false;
}

void deleteList(List *list)
{
	if (list->head == nullptr)
	{
		delete list;
	}
}