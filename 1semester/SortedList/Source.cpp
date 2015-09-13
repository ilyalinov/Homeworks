#include <iostream>

using namespace std;

#include "List.h"

void main()
{
	List *list = createList();
	cout << "Enter your numbers" << endl;
	while (true)
	{
		int n = 0;
		cin >> n;
		if (n == 0)
		{
			break;
		}
		listInsert(list, createListElement(n));
	}
	printList(list);
	deleteList(list);
}
// Tested. Working fine.