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

// Wrires '-1' to the input matrix
void writeZerosToMatrix(int **&array, int const size)
{
	for (int i = 0; i < size; ++i)
	{
		for (int j = 0; j < size; ++j)
		{
			array[i][j] = -1;
		}
	}
}

// 
void matrixToFile(ofstream &file, int** matrix, int size)
{
	for (int i = 0; i < size; ++i)
	{
		for (int j = 0; j < size; j++)
		{
			file << matrix[i][j] << " ";
		}
		file << endl;
	}
}

void main()
{
	ifstream file("InputGraph.txt", ios::in);
	int numberOfVertices = 0;
	file >> numberOfVertices;
	int **edges = createArray(numberOfVertices);
	fileToMatrix(file, edges, numberOfVertices);
	int **spanningTree = createArray(numberOfVertices);
	writeZerosToMatrix(spanningTree, numberOfVertices);

	Queue *queue = createQueue();
	addElement(queue, createElement(0, 0));
	for (int i = 1; i < numberOfVertices; ++i)
	{
		addElement(queue, createElement(i, -1));
	}

	vector<bool> vertices;
	for (int i = 0; i < numberOfVertices; ++i)
	{
		vertices.push_back(true);
	}

	vector<int> nextEdge;
	nextEdge.resize(numberOfVertices);
	while (!isEmpty(queue))
	{
		int vertice = extractMin(queue);
		vertices[vertice] = false;
		for (int i = 0; i < numberOfVertices; ++i)
		{
			if (edges[vertice][i] != -1 && (edges[vertice][i] < priority(queue, i) || priority(queue, i) == -1) && vertices[i])
			{
				nextEdge[i] = vertice;
				setPriority(queue, i, edges[i][vertice]);
			}
		}
	}

	for (int i = 1; i < numberOfVertices; ++i)
	{
		spanningTree[nextEdge[i]][i] = edges[nextEdge[i]][i];
		spanningTree[i][nextEdge[i]] = edges[i][nextEdge[i]];
	}

	ofstream file1("OutputGraph.txt", ios::in);
	matrixToFile(file1, spanningTree, numberOfVertices);
	
	file1.close();
	file.close();
	deleteArray(spanningTree, numberOfVertices);
	deleteArray(edges, numberOfVertices);
	deleteQueue(queue);
}
// Tested and working.
// Tests: 
// Input:      Output: 
// 4
// -1 1 -1 -1  -1 1 -1 -1
// 1 -1 2 -1   1 -1 2 -1
// -1 2 -1 3   -1 2 -1 3
// -1 -1 3 -1  -1 -1 3 -1
// 
// 4           
// -1 1 2 3    -1 1 2 3 
// 1 -1 3 4    1 -1 -1 -1 
// 2 3 -1 5    2 -1 -1 -1 
// 3 4 5 -1    3 -1 -1 -1
// Last example is written in the input&output files
