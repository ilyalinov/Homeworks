#include <iostream>

using namespace std;

// структура для элементов списка
struct ListElement
{
	int value;
	ListElement *next;
};

// структура для указателя на первый элемент
struct Head
{
	ListElement *list;
};

// добавление элемента в сортированный список
void listInsert(Head *head, int number)
{
	if (head->list == nullptr)
	{
		head->list = new ListElement();
		head->list->value = number;
	}
	else
	{
		ListElement *temp = head->list;
		bool isAdded = false;
		if (head->list->value >= number)
		{
			ListElement *temp1 = new ListElement();
			temp1->value = number;
			temp1->next = temp;
			head->list = temp1;
			isAdded = true;
		}
		else
		{
			while (temp->next != nullptr)
			{
				if (temp->next->value >= number)
				{
					ListElement *temp1 = new ListElement();
					temp1->value = number;
					temp1->next = temp->next;
					temp->next = temp1;
					isAdded = true;
					break;
				}
				temp = temp->next;
			}
		}
		if (!isAdded)
		{
			temp->next = new ListElement();
			temp->next->value = number;
		}
	}
}

// печать списка
void printList(Head *head)
{
	if (head->list == nullptr)
	{
		cout << "Your list is empty" << endl;
		return;
	}
	ListElement *temp = head->list;
	cout << "Printed list : " << endl;
	while (temp != nullptr)
	{
		cout << temp->value << " ";
		temp = temp->next;
	}
	cout << endl;
}

// удаление элемента из списка по номеру
void remove(Head *head, int number)
{
	if (head->list->value == number)
	{
		ListElement *temp = head->list;
		head->list = head->list->next;
		delete temp;
		return;
	}
	ListElement *temp = head->list;
	while (temp->next != nullptr)
	{
		if (temp->next->value == number)
		{
			ListElement *temp1 = temp->next;
			temp->next = temp->next->next;
			delete temp1;
			break;
		}
		temp = temp->next;
	}
}

// удаление последнего элемента
// сначала реализовал через воид. Цикл while в main был при условии head != nullptr
// вместо delete head в функции стояло head = nullptr
// каким-то магическим образом в head помещался мусор вместо nullptr при выходе из функции и 
// в итоге while был бесконечным. Почему так происходило мне не ясно.. 
int deleteLastElem(Head *head)
{
	if (head->list == nullptr)
	{
		delete head;
		return 1;
	}
	else if (head->list->next == nullptr)
	{
		delete head->list;
		delete head;
		return 1;
	}
	ListElement *temp = head->list->next;
	ListElement *temp1 = head->list;
	while (temp->next != nullptr)
	{
		temp1 = temp;
		temp = temp->next;
	}
	temp1->next = nullptr;
	delete temp;
	return 0;
}

void main()
{
	Head *head = new Head();
	
	while (true)
	{
		cout << "0 - exit" << endl;
		cout << "1 - add number" << endl;
		cout << "2 - remove number" << endl;
		cout << "3 - print the list" << endl;
		int k = 0;
		cin >> k;
		int number;
		switch (k)
		{
			case 0:
				while (head != nullptr)
				{
					if (deleteLastElem(head))
					{
						break;
					}
				}
				cout << "Deleted" << endl;
				return;
				break;
			case 1:
				cout << "Enter your number: " << endl;
				cin >> number;
				listInsert(head, number);
				break;
			case 2:
				cout << "Enter your number: " << endl;
				cin >> number;
				remove(head, number);
				break;
			case 3:
				printList(head);
				break;
		}
	}
}
// tested on: delete element, add element, print whole list, delete list and exit;
// working correct