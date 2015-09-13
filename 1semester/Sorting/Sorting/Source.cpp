#include <iostream>
#include <vector>

using namespace std;

void bubble(vector<int> &array)     // Ok, after 1 hour i understood that there should be "&" :)
									// before which types should be comma for the changes in the array from "main"? 
{
	for (int i = 0; i < array.size(); ++i)
	{
		for (int j = array.size() - 1; j > i; --j)
		{
			if (array[j - 1] > array[j])
			{
				int t = array[j - 1];
				array[j - 1] = array[j];
				array[j] = t;
			}
		}
	}
}

void counting(vector<int> &array)
{
	int const size = 1000;
	int secondaryArray[size];
	for (int i = 0; i < size; ++i)
	{
		secondaryArray[i] = 0;
	}
	for (int i = 0; i < array.size(); ++i)
	{
		++secondaryArray[array[i]];
	}
	int k = 0;
	for (int i = 0; i < size; ++i)
	{
		while (secondaryArray[i] != 0)
		{
			array[k] = i;
			++k;
			--secondaryArray[i];
		}
	}
}

void main()
{
	vector<int> array;
	cout << "Enter your array size: ";
	int size = 0;
	cin >> size;
	cout << "Enter your array: "; 
	for (int i = 0; i < size; ++i)
	{
		int t = 0;
		cin >> t;
		array.push_back(t); //maybe, i should do that cycle shorter (faster), but don't know how..
	}
	
	//bubble(array);
	counting(array);

	cout << "Modified array: " << endl;
	for (int i = 0; i < size; ++i)
	{
		cout << array[i] << endl;
	}
}