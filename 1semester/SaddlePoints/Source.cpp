#include <iostream>
#include <fstream>

using namespace std;

// Creates two-dimensional array
int** createArray(int const width, int const height)
{
	int **array = new int*[width];
	for (int i = 0; i < width; i++)
	{
		array[i] = new int[height];
	}
	return array;
}

// Deletes two-dimensional array
void deleteArray(int **&array, int width)
{
	for (int i = 0; i < width; i++)
	{
		delete[] array[i];
	}
	delete[] array;
	cout << "Memory is cleared" << endl;
}

// Checks whether our point is saddle
bool isPointSaddle(int **matrix, int const width, int const height, int const matrixWidth, int const matrixHeight)
{
	for (int j = 0; j < matrixHeight; ++j)
	{
		if (j != height)
		{
			if (matrix[width][j] >= matrix[width][height])
			{
				return false;
			}
		}
	}
	for (int j = 0; j < matrixWidth; ++j)
	{
		if (j != width)
		{
			if (matrix[j][height] <= matrix[width][height])
			{
				return false;
			}
		}
	}
	return true;
}

// Prints all saddle points to console
void printSaddlePoints(int **matrix, int width, int height)
{
	cout << "Saddle points: " << endl;
	for (int i = 0; i < width; ++i)
	{
		for (int j = 0; j < height; j++)
		{
			if (isPointSaddle(matrix, i, j, width, height))
			{
				cout << i << " " << j << "(" << matrix[i][j] << ")" << endl;
			}
		}
	}
}

void main()
{
	ifstream file("Text.txt", ios::in);
	int width = 0;
	int height = 0;
	file >> height;
	file >> width;
	int **matrix = createArray(width, height);
	for (int i = 0; i < height; i++)
	{
		for (int j = 0; j < width; j++)
		{
			int temp = 0;
			file >> temp;
			matrix[j][i] = temp;
		}
	}
	printSaddlePoints(matrix, width, height);
	file.close();
	deleteArray(matrix, width);
}
// Tested on the example in 'Text.txt'. Working fine. 