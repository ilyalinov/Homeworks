#include <iostream>

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
	newElement->quantity = 1;
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
		ListElement *temp1 = list->head;
		ListElement *temp = list->head;
		while (temp != nullptr && temp->value <= newElement->value)
		{
			if (temp->value == newElement->value)
			{
				++temp->quantity;
				delete newElement;
				return;
			}
			temp1 = temp;
			temp = temp->next;
		}
		if (temp == nullptr)
		{
			temp1->next = newElement;
		}
		else if (temp == list->head)
		{
			list->head = newElement;
			list->head->next = temp;
		}
		else
		{
			temp1->next = newElement;
			temp1->next->next = temp;
		}
	}
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
		cout << temp->value << "(" << temp->quantity << "); ";
		temp = temp->next;
	}
	cout << endl;
}