#include <iostream>
#include <time.h>
#include <vector>

using namespace std;

void filling(vector<int> &array)
{
	for (unsigned i = 0; i < array.size(); ++i) // warning "signed/unsigned mismatch" !?
	{
		int const temp = 500; // max possible number in the array is 499
		array[i] = rand() % temp;
	}
}

void pieceOfQsort(vector<int> &array)
{
	int leftPointer = 1;
	int rightPointer = array.size() - 1;
	while (leftPointer < rightPointer)
	{
		if (array[leftPointer] > array[0] && array[rightPointer] < array[0])
		{
			int temp = array[leftPointer];
			array[leftPointer] = array[rightPointer];
			array[rightPointer] = temp;
			++leftPointer;
			--rightPointer;
		}
		else if (array[leftPointer] <= array[0] && array[rightPointer] < array[0])
		{
			++leftPointer;
		}
		else if (array[leftPointer] <= array[0] && array[rightPointer] >= array[0])
		{
			++leftPointer;
			--rightPointer;
		}
		else if (array[leftPointer] > array[0] && array[rightPointer] >= array[0])
		{
			--rightPointer;
		}
	}
}

void main()
{
	srand(static_cast<unsigned>(time(nullptr))); 

	vector<int> array;
	cout << "Enter the array size: ";
	int size = 0;
	cin >> size;
	cout << "Adding array elements... " << endl;
	array.resize(size);

	filling(array);

	cout << "Initial array: " << endl;
	for (int i = 0; i < size; ++i)
	{
		cout << array[i] << " ";
	}
	cout << endl;

	pieceOfQsort(array);

	cout << "Modified array: " << endl;
	for (int i = 0; i < size; ++i)
	{
		cout << array[i] << " ";
	}
	cout << endl;
}