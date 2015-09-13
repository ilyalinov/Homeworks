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

// кусок хипсорта
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

// кусок хипсорта
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

// binary search
bool binarySearch(vector<int> array, int elem, int left, int right)
{
	if (array[(right + left) / 2] == elem)
	{
		return true;
	}
	else if (right - left > 1)
	{
		if (array[right] == elem)
		{
			return true;
		}
		else if (array[left] == elem)
		{
			return true;
		}
		else if (array[(left + right) / 2] > elem)
		{
			return binarySearch(array, elem, left, (left + right) / 2);
		}
		else if (array[(left + right) / 2] < elem)
		{
			return binarySearch(array, elem, (left + right) / 2, right);
		}
	}
	else if (right - left <= 1)
	{
		return false;
	}
	return true;
}

void main()
{
	vector<int> array;
	int n = 0;
	cout << "Enter n: ";
	cin >> n;
	array.resize(n);
	filling(array);

	vector<int> array1;
	int k = 0;
	cout << "Enter k: ";
	cin >> k;
	array1.resize(k);
	filling(array1);

	vector<bool> array2;

	heapsort(array);

	for (int i = 0; i < k; ++i)
	{
		array2.push_back(binarySearch(array, array1[i], 0, n - 1));
	}

}
// tested on: 
// n = {5, 10, 100, 1000}
// k = {10, 20, 100, 1000}
// working fine