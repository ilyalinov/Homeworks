#include <iostream>

using namespace std;

void main()
{
	int const maxSize = 100;
	int array[maxSize];
	int size = 0;
	cout << "Enter the size of array: ";
	cin >> size;
	int counter = 0;
	for (int i = 0; i < size; i++)
	{
		cin >> array[i];
		if (array[i] == 0)
		{
			counter++;
		}
	}
	cout << "The number of zero elements in the array: ";
	cout << counter << endl;
}