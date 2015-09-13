#include <vector>

using namespace std;

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
