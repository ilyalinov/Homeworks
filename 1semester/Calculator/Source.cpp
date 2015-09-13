#include <iostream>
#include <string>
#include "List.h"

using namespace std;

void showMenu()
{
	cout << "Enter your number below:" << endl;
	cout << "1 - multiplication" << endl;
	cout << "2 - plus" << endl;
	cout << "3 - minus" << endl;
	cout << "4 - uni minus" << endl;
}

List* createListByString()
{
	string buffer;
	cin >> buffer;
	List *list1 = createList();
	for (unsigned i = 0; i < buffer.length(); ++i)
	{
		string temp;
		temp += buffer[i];
		listInsertToTheTail(list1, createListElement(stoi(temp)));
		temp.clear();
	}
	return list1;
}

void main()
{
	List *list = createList();
	showMenu();
	int n;
	cin >> n;
	cout << "Enter your string(s): " << endl;
	if (n == 1)
	{
		List *list1 = createListByString();
		List *list2 = createListByString();
		list = multiplication(list1, list2);
		printList(list);
		deleteList(list);
	}
	else if (n == 2)
	{
		List *list1 = createListByString();
		List *list2 = createListByString();
		list = pluss(list1, list2);
		printList(list);
		deleteList(list);
	}
	else if (n == 3)
	{
		List *list1 = createListByString();
		List *list2 = createListByString();
		list = minuss(list1, list2);
		printList(list);
		deleteList(list);
	}
	else if (n == 4)
	{
		List *list1 = createListByString();
		cout << "-";
		printList(list1);
		deleteList(list1);
	}
}