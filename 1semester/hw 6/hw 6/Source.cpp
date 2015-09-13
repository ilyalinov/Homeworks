#include <iostream>

using namespace std;

void main()
{
	int const size = 28;
	int array[size];

	for (int i = 0; i < size; ++i)
	{
		array[i] = 0;
	}

	for (int i = 0; i < 10; ++i)
	{
		for (int j = 0; j < 10; ++j)
		{
			for (int k = 0; k < 10; ++k)
			{
				++array[i + j + k];
			}
		}
	}
	long int sum = 0;
	for (int i = 0; i < size; ++i)
	{
		sum = sum + array[i] * array[i]; 
	}
	cout << "The number of happy tickets : \n";
	cout << sum << endl;
}