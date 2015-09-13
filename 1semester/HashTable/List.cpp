#include <iostream>
#include <string>

using namespace std;

struct ListElement
{
	string value;
	int quantity;
	ListElement *next;
};

struct List
{
	ListElement *head;
	int size;
};

List *createList()
{
	List *list = new List();
	list->head = nullptr;
	list->size = 0;
	return list;
}

ListElement *createListElement(string value)
{
	ListElement *newElement = new ListElement();
	newElement->next = nullptr;
	newElement->value = value;
	newElement->quantity = 1;
	return newElement;
}

void listInsert(List *list, ListElement *newElement)
{
	if (list->head == nullptr)
	{
		list->head = newElement;
		++list->size;
	}
	else
	{
		ListElement *temp = list->head;
		while (true)
		{
			if (temp->value == newElement->value)
			{
				temp->quantity++;
				delete newElement;
				return;
			}
			if (temp->next == nullptr)
			{
				break;
			}
			temp = temp->next;
		}
		temp->next = newElement;
		++list->size;
	}
}

bool findListElement(List *list, ListElement *listElement)
{
	ListElement *temp = list->head;
	while (temp != nullptr)
	{
		if (temp->value == listElement->value)
		{
			return true;
		}
		temp = temp->next;
	}
	return false;
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
	//cout << "List deleted" << endl;
}

void printList(List *list)
{
	if (list->head == nullptr)
	{
		//cout << "Your list is empty" << endl;
		return;
	}
	ListElement *temp = list->head;
	//cout << "Printed list: " << endl;
	while (temp != nullptr)
	{
		cout << temp->value << " (" << temp->quantity << ")" << "; ";
		temp = temp->next;
	}
	cout << endl;
}