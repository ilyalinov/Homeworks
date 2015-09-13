#include <iostream>
#include <vector>
#include <time.h>
#include <fstream>

using namespace std;

#include "Heapsort.h"
#include "Filling.h"
#include "Find.h"

void main()
{
	vector<int> array;
	ifstream f("Text.txt", ios::in);
	if (!f.is_open())
	{
		cout << "Create file 'Text.txt' in the project directory" << endl;
		return;
	}
	while (!f.eof())
	{
		int number = 0;
		f >> number;
		array.push_back(number);
	}
	f.close();

	cout << "Initial array: " << endl;
	printArray(array);

	heapsort(array);

	cout << "Modified array: " << endl;
	printArray(array);

	findMostCommon(array);
}