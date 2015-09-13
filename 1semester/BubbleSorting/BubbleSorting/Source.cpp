#include <iostream>
#include <vector>

using namespace std;

void bubble(vector<int> &array)
{
	for (unsigned i = 0; i < array.size(); i++)
	{
		for (unsigned j = array.size() - 1; j > i; j--)
		{
			if (array[j] < array[j - 1])
			{
				int temp = array[j];
				array[j] = array[j - 1];
				array[j - 1] = temp;
			}
		}
	}

}

void main()
{
	vector<int> array;
	int size = 0;
	cout << "Enter array size: " << endl;
	cin >> size;
	array.resize(size);
	cout << "Enter array elements: " << endl;
	for (int i = 0; i < size; ++i)
	{
		cin >> array[i];
	}
	bubble(array);

	cout << "Modified array: " << endl;
	for (unsigned i = 0; i < array.size(); ++i)
	{
		cout << array[i] << " ";
	}
}