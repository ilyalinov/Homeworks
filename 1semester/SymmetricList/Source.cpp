#include <iostream>
#include <fstream>

using namespace std;

#include "List.h"

void main()
{
	List *list = createList();
	ifstream file("Text.txt", ios::in);
	while (!file.eof())
	{
		int n = 0;
		file >> n;
		ListElement *newElement = createListElement(n);
		listInsert(list, newElement);
	}
	file.close();
	if (isListSymmetric(list))
	{
		cout << "Your list is symmetric" << endl;
	}
	else
	{
		cout << "Your list isn't symmetric" << endl;
	}
	deleteList(list);
}
// Input file f shouln't contain any additional symbols after the last integer.