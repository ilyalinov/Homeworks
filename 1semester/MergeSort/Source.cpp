#include <iostream>
#include <fstream>
#include "List.h"
#include "ListArray.h"
#include "Merge.h"

using namespace std;

void main()
{
	MyList list = createListArray(); // --> MyList list = createList(); 
	ifstream file("Text.txt", ios::in);
	fileToList(file, list);

	list = sort(list);

	printList(list);
	deleteList(list);
}
// Tested and working on the example in "Text.txt" with changes and without them (on the array and on the dynamic list)
// All changes marked with '-->'
// Now the sorting is working with ListArray (list on array)