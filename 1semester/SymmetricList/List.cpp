#include <iostream>

using namespace std;

struct ListElement
{
	int value;
	ListElement *next;
	ListElement *prev;
};

struct List
{
	ListElement *head;
	ListElement *last;
};

List *createList()
{
	List *list = new List();
	list->head = nullptr;
	list->last = nullptr;
	return list;
}

ListElement *createListElement(int value)
{
	ListElement *newElement = new ListElement();
	newElement->next = nullptr;
	newElement->prev = nullptr;
	newElement->value = value;
	return newElement;
}

void listInsert(List *list, ListElement *newElement)
{
	if (list->head == nullptr)
	{
		list->head = newElement;
		list->last = newElement;
	}
	else
	{
		list->last->next = newElement;
		newElement->prev = list->last;
		list->last = newElement;
	}
	list->last->next = nullptr;
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
		cout << "Your list is empty" << endl;
		return;
	}
	ListElement *temp = list->head;
	cout << "Printed list: " << endl;
	while (temp != nullptr)
	{
		cout << temp->value << "; ";
		temp = temp->next;
	}
	cout << endl;
}

bool isListSymmetric(List *list)
{
	ListElement *left = list->head;
	ListElement *right = list->last;
	while (left != right)
	{
		if (left->prev == right)
		{
			break;
		}
		if (left->value != right->value)
		{
			return false;
		}
		left = left->next; 
		right = right->prev;
	}
	return true;
}