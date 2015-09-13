#include <vector>
#include <iostream>

using namespace std;

// заполнение массива рандомными числами
void filling(vector<int> &array)
{
	cout << "Adding array elements..." << endl;
	for (unsigned i = 0; i < array.size(); ++i) 
	{
		int const temp = 1000000000; // max possible number in the array is 1000000000
		array[i] = rand() % temp;
	}
}

// печатаем массив
void printArray(vector<int> &array)
{
	for (unsigned i = 0; i < array.size(); ++i)
	{
		cout << array[i] << " ";
	}
	cout << endl;
}
