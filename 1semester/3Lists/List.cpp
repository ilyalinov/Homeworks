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

void printListToFile(List *list, ofstream &file)
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
		file << temp->value << " ";
		temp = temp->next;
	}
	file << endl;
}