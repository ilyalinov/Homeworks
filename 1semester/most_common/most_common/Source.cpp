#include <iostream>
#include <vector>

using namespace std;

// заполнение массива рандомными числами от 0 до 10^9
void filling(vector<int> &array)
{
	cout << "Adding random array elements... " << endl;
	for (unsigned i = 0; i < array.size(); ++i) 
	{
		int const temp = 1000000000; // max possible number in the array is 1000000000
		array[i] = rand() % temp;
	}
}

// проталкивание элемента в пирамиду
void miniHeap(vector<int> &array, int number, int heapSize)
{
	int largest = number;
	if (2 * number + 1 <= heapSize && array[number] < array[2 * number + 1])
	{
		largest = 2 * number + 1;
	}
	if (2 * number + 2 <= heapSize && array[number] < array[2 * number + 2] && array[2 * number + 1] < array[2 * number + 2])
	{
		largest = 2 * number + 2;
	}
	if (largest != number)
	{
		int temp = array[number];
		array[number] = array[largest];
		array[largest] = temp;
		miniHeap(array, largest, heapSize);
	}
}

// построение пирамиды
void buildMaxHeap(vector<int> &array)
{
	int const heapSize = array.size() - 1;
	for (int i = (array.size() - 1) / 2; i >= 0; i--)
	{
		miniHeap(array, i, heapSize);
	}
}

// кусок хипсорта
void heapsort(vector<int> &array)
{
	buildMaxHeap(array);
	int heapSize = array.size() - 1;
	for (int i = array.size() - 1; i > 0; --i)
	{
		int temp = array[0];
		array[0] = array[i];
		array[i] = temp;
		--heapSize;
		miniHeap(array, 0, heapSize);
	}
}

void main()
{
	vector<int> array;
	int size = 0;
	cout << "Enter your array size: ";
	cin >> size;
	array.resize(size);
	filling(array);
	
	cout << "Initial array: " << endl;
	for (unsigned i = 0; i < array.size(); ++i)
	{
		cout << array[i] << " ";
	}
	cout << endl;

	heapsort(array);

	int maxCounter = 1;
	int counterOfMostCommon = 1;
	int number = 0;
	for (int i = 1; i < size; ++i)
	{
		if (array[i] == array[i - 1])
		{
			counterOfMostCommon++;
		}
		if (counterOfMostCommon > maxCounter)
		{
			maxCounter = counterOfMostCommon;
			counterOfMostCommon = 1; 
			number = i;
		}
	}
	if (maxCounter == 1)
	{
		cout << "All elems are different" << endl;
	}
	else
	{
		cout << "Most common: " << array[number] << endl;
		cout << "Met " << maxCounter << " times" << endl;
	}
}
// tested on:
// size {100, 1000, 10000}
// result {all different, 5 times, 52 times}
