#include <iostream>
#include <fstream>
#include <vector>

#include "Queue.h"

using namespace std;

// Allocates memory for a two-dimensional array
int** createArray(int const n)
{
	int **array = new int*[n];
	for (int i = 0; i < n; i++)
	{
		array[i] = new int[n];
	}
	return array;
}

// Writes file to the matrix
void fileToMatrix(ifstream &file, int **&matrix, const int size)
{
	for (int i = 0; i < size; i++)
	{
		for (int j = 0; j < size; j++)
		{
			int n = 0;
			file >> n;
			matrix[i][j] = n;
		}
	}
}

// Deletes two-dimensional array
void deleteArray(int **&array, int size)
{
	for (int i = 0; i < size; i++)
	{
		delete[] array[i];
	}
	delete[] array;
	cout << "Memory is cleared" << endl;
}

void main()
{
	List *list = createList();
	ifstream file("Text.txt", ios::in);
	int n = 0;
	file >> n;
	int **matrix = createArray(n);
	fileToMatrix(file, matrix, n);
	vector<int> vertices;
	vertices.resize(n);
	for (int i = 0; i < n; i++)
	{
		vertices[i] = 0;
	}
	listInsert(list, createListElement(0));
	vertices[0] = 1;
	while (!isEmpty(list))
	{
		int verticeNumber = deleteFirst(list);
		cout << verticeNumber << endl;
		for (int i = 0; i < n; i++)
		{
			if (matrix[verticeNumber][i] != -1 && vertices[i] == 0)
			{
				listInsert(list, createListElement(i));
				vertices[i] = 1;
			}
		}
	}
	file.close();
	deleteList(list);
	deleteArray(matrix, n);
}
// Tested on the example in 'text.txt'. Working fine.
