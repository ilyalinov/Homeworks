#include <iostream>
#include <vector>

using namespace std;

// заполнение массива рандомными числами от 0 до 499
void filling(vector<int> &array)
{
	cout << "Adding random array elements... " << endl;
	for (int i = 0; i < array.size(); ++i) // warning "signed/unsigned mismatch" !?
	{
		int const temp = 500; // max possible number in the array is 499
		array[i] = rand() % temp;
	}
}

// сортировка вставками
void insertionSort(vector<int> &array, int leftBorder, int rightBorder)
{
	for (int i = leftBorder + 1; i <= rightBorder; ++i)
	{
		int j = i - 1;
		int insert = array[i];
		while (j >= leftBorder && insert < array[j])
		{
			array[j + 1] = array[j];
			--j;
		}
		array[j + 1] = insert;
	}
}

// функция ставит в начало массива элементы, меньшие либо равные последнего, в конец - большие последнего.
// Затем последний элемент ставится в середину.
int partition(vector<int> &array, int leftBorder, int rightBorder)
{
	int i = leftBorder;
	for (int j = leftBorder; j < rightBorder; ++j)
	{
		if (array[j] <= array[rightBorder])
		{
			int temp = array[j];
			array[j] = array[i];
			array[i] = temp;
			++i;
		}
	}
	int temp = array[rightBorder];
	array[rightBorder] = array[i];
	array[i] = temp;
	return i;
}

// рекурсивное разбиение на 2 массива
void quickSort(vector<int> &array, int leftBorder, int rightBorder)
{
	if (leftBorder < rightBorder && rightBorder - leftBorder + 1 >= 10)
	{
		int pivotAdress = partition(array, leftBorder, rightBorder);
		quickSort(array, pivotAdress + 1, rightBorder);
		quickSort(array, leftBorder, pivotAdress - 1);
	}
	if (leftBorder < rightBorder && rightBorder - leftBorder + 1 < 10)
	{
		insertionSort(array, leftBorder, rightBorder);
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

	quickSort(array, 0, array.size() - 1);

	cout << "Modified array: " << endl;
	for (int i = 0; i < size; ++i)
	{
		cout << array[i] << endl;
	}
}
// tested on: 
// size: {0, 1, 5, 10, 15, 20}
// working fine