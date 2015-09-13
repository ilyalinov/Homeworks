#include <iostream>
#include <fstream>
#include <vector>

using namespace std;

// Allocates memory for a two-dimensional array
int** createArray(int const n)
{
	int **array = new int* [n]; 
	for (int i = 0; i < n; i++)
	{
		array[i] = new int [n];
	}
	return array;
}

// Fills whole matrix with '-1'
void ZerosToMatrix(int**& array, int size)
{
	for (int i = 0; i < size; i++)
	{
		for (int j = 0; j < size; j++)
		{
			array[i][j] = -1;
			array[j][i] = -1;
		}
	}
}

// Reads roads from file and writes it to the matrix
void roadsToMatrix(ifstream &file, int**& roads, const int numberOfRoads)
{
	for (int i = 0; i < numberOfRoads; i++)
	{
		int city1 = 0;
		int city2 = 0;
		file >> city1;
		file >> city2;
		int length = 0;
		file >> length;
		roads[city1][city2] = length;
		roads[city2][city1] = length;
	}
}

// Checks is there a city without state
bool isEnd(vector<int> &cities)
{
	for (unsigned i = 0; i < cities.size(); i++)
	{
		if (cities[i] == -1)
		{
			return false;
		}
	}
	return true;
}

// Adds one city (if there is a possibility to do) to the state
void add(int capital, vector<int> &cities, int** roads)
{
	int cityNumber = -1;
	int minimumRoad = 0;
	for (unsigned i = 0; i < cities.size(); i++)
	{
		if (cities[i] == capital)
		{
			for (unsigned j = 0; j < cities.size(); j++)
			{
				if (roads[i][j] != -1 && cities[j] == -1)
				{
					if (cityNumber == -1)
					{
						cityNumber = j;
						minimumRoad = roads[i][j];
					}
					else if (roads[i][j] < minimumRoad)
					{
						cityNumber = j;
						minimumRoad = roads[i][j];
					}
				}
			}
		}
	}
	if (cityNumber != -1)
	{
		cities[cityNumber] = capital;
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

// Prints cities lists to console
void showResult(vector<int> &cities, vector<int> &capitals)
{
	for (unsigned i = 0; i < capitals.size(); i++)
	{
		cout << "State with its capital " << capitals[i] << endl;
		for (unsigned j = 0; j < cities.size(); j++)
		{
			if (cities[j] == capitals[i])
			{
				cout << j << " ";
			}
		}
		cout << endl;
	}
}

void main()
{
	ifstream file("Text.txt", ios::in);
	int n = 0;
	int m = 0;
	file >> n;
	file >> m;
	int** roads = createArray(n);
	ZerosToMatrix(roads, n);
	roadsToMatrix(file, roads, m);
	int k = 0;
	file >> k;
	vector<int> cities;
	vector<int> capitals;
	for (int i = 0; i < n; i++)
	{
		cities.push_back(-1);
	}
	for (int i = 0; i < k; i++)
	{
		int temp = 0;
		file >> temp;
		cities[temp] = temp;
		capitals.push_back(temp);
	}
	int capitalNumber = 0;
	while (!isEnd(cities))
	{
		if (capitalNumber >= k)
		{
			capitalNumber = capitalNumber % k;
		}
		add(capitals[capitalNumber], cities, roads);
		++capitalNumber;
	}
	showResult(cities, capitals);
	deleteArray(roads, n);
	file.close();
}
// Tested on the example in 'Text.txt', working ok.