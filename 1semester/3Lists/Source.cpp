#include <iostream>
#include <fstream>

using namespace std;

#include "List.h"

void main()
{
	List *list1 = createList();
	List *list2 = createList();
	List *list3 = createList();
	ifstream f("f.txt", ios::in);
	cout << "Enter your A and B: " << endl;
	int a = 0;
	cin >> a;
	int b = 0;
	cin >> b;
	while (!f.eof())
	{
		int n;
		f >> n;
		if (n < a)
		{
			ListElement *newElement = createListElement(n);
			listInsert(list1, newElement);
		}
		else if (n >= a && n <= b)
		{
			ListElement *newElement = createListElement(n);
			listInsert(list2, newElement);
		}
		else if (n > b)
		{
			ListElement *newElement = createListElement(n);
			listInsert(list3, newElement);
		}
	}
	f.close();
	ofstream g("g.txt", ios::out);
	printListToFile(list1, g);
	printListToFile(list2, g);
	printListToFile(list3, g);
	g.close();
	deleteList(list1);
	deleteList(list2);
	deleteList(list3);
}
// Input file f shouln't contain any additional symbols after the last integer.