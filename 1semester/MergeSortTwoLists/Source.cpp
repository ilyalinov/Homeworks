#include <iostream>
#include <fstream>
#include "ArrayList.h"
#include "ArrayMerge.h"

using namespace std;

void main()
{
	List *list = createList();
	ifstream file("Text.txt", ios::in);

	list = sort(list);
	printList(list);
}