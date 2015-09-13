#include <iostream>
#include <fstream>

using namespace std;

struct ListElement
{
	int value;
	ListElement *next = nullptr;
};

struct List
{
	ListElement *head = nullptr;
	ListElement *last = nullptr;
	int size = 0;
	char sign = ' ';
};

List *createList()
{
	return new List();
}

ListElement *createListElement(int value)
{
	ListElement *newElement = new ListElement();
	newElement->value = value;
	return newElement;
}

void listInsertToTheTail(List *list, ListElement *newElement)
{
	if (list->head == nullptr)
	{
		list->head = newElement;
		list->last = newElement;
	}
	else
	{
		list->last->next = newElement;
		list->last = newElement;
	}
	list->size++;
}

void listInsertToTheHead(List *list, ListElement *newElement)
{
	if (list->head == nullptr)
	{
		list->head = newElement;
		list->last = newElement;
	}
	else
	{
		ListElement *temp = list->head;
		list->head = newElement;
		list->head->next = temp;
	}
	list->size++;
}

int deleteLastElement(List *list)
{
	if (list->head == nullptr)
	{
		return -1;
	}
	else
	{
		ListElement *temp1 = list->head;
		ListElement *temp = list->head;
		while (temp->next != nullptr)
		{
			temp1 = temp;
			temp = temp->next;
		}
		if (temp == temp1)
		{
			int result = temp->value;
			delete temp;
			list->head = nullptr;
			list->last = nullptr;
			return result;
		}
		else
		{
			temp1->next = nullptr;
			int result = temp->value;
			delete temp;
			list->last = temp1;
			return result;
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
}

void printList(List *list)
{
	if (list->head == nullptr)
	{
		cout << "Your list is empty";
	}
	else
	{
		ListElement *temp = list->head;
		cout << list->sign;
		while (temp != nullptr)
		{
			cout << temp->value;
			temp = temp->next;
		}
		cout << endl;
	}
}

List* pluss(List *list1, List *list2)
{
	List *list = createList();
	int nextDigit = 0;
	while (list1->head != nullptr && list2->head != nullptr)
	{
		int temp = (deleteLastElement(list1) + deleteLastElement(list2) + nextDigit);
		listInsertToTheHead(list, createListElement(temp % 10));
		nextDigit = (temp) / 10;
	}
	if (list1->head == nullptr)
	{
		while (list2->head != nullptr)
		{
			listInsertToTheHead(list, createListElement((deleteLastElement(list2) + nextDigit) % 10));
			nextDigit = 0;
		}
	}
	else
	{
		while (list1->head != nullptr)
		{
			listInsertToTheHead(list, createListElement((deleteLastElement(list1) + nextDigit) % 10));
			nextDigit = 0;
		}
	}
	deleteList(list1);
	deleteList(list2);
	return list;
}

List* multiplication(List *list1, List *list2)
{
	List *list = createList();
	int powerOfTen = 0;
	int nextDigit = 0;
	while (list2->head != nullptr)
	{
		int digit = deleteLastElement(list2);
		List *list11 = createList();
		ListElement *temp = list1->head;
		while (temp != nullptr)
		{
			listInsertToTheTail(list11, createListElement(temp->value));
			temp = temp->next;
		}
		List *list3 = createList();
		for (int i = 0; i < list1->size; ++i)
		{
			int temp1 = deleteLastElement(list11) * digit + nextDigit;
			listInsertToTheHead(list3, createListElement(temp1 % 10));
			nextDigit = temp1 / 10;
		}
		for (int j = 0; j < powerOfTen; j++)
		{
			listInsertToTheTail(list3, createListElement(0));
		}
		list = pluss(list, list3);
		/*deleteList(list3);
		deleteList(list11);*/
		powerOfTen++;
	}
	if (nextDigit != 0)
	{
		listInsertToTheHead(list, createListElement(nextDigit));
	}
	deleteList(list1);
	deleteList(list2);
	return list;
}

bool compare(List *list1, List *list2)
{
	if (list1->size > list2->size)
	{
		return true;
	}
	else if (list2->size > list1->size)
	{
		return false;
	}
	else
	{
		ListElement *temp1 = list1->head;
		ListElement *temp2 = list2->head;
		for (int i = 0; i < list1->size; i++)
		{
			if (temp1->value > temp2->value)
			{
				return true;
			}
			else if (temp1->value < temp2->value)
			{
				return false;
			}
		}
	}
	return true;
}

List* minuss(List *list1, List *list2)
{
	List *list = createList();
	int nextDigit = 0;
	if (compare(list1, list2))
	{
		while (list2->head != nullptr)
		{
			int temp = deleteLastElement(list1) - deleteLastElement(list2);
			if (temp + nextDigit < 0)
			{
				listInsertToTheHead(list, createListElement(temp + 10 + nextDigit));
				nextDigit = -1;
			}
			else
			{
				listInsertToTheHead(list, createListElement(temp + nextDigit));
				nextDigit = 0;
			}
		}
		while (list1->head != nullptr)
		{
			int temp = deleteLastElement(list1);
			listInsertToTheHead(list, createListElement(temp + nextDigit));
		}
		list->sign = '+';
	}
	else
	{
		list = minuss(list2, list1);
		list->sign = '-';
	}
	return list;
}