#include <iostream>
#include <vector>

using namespace std;

void main()
{
	vector<bool> number1;
	vector<bool> number2;

	int const size = 8;
	number1.resize(size);
	number2.resize(size);
	cout << "Enter first number: " << endl;
	for (unsigned i = 0; i < number1.size(); ++i)
	{
		bool temp;
		cin >> temp;
		number1[i] = temp;
	}
	cout << "Enter second number: " << endl;
	for (unsigned i = 0; i < number1.size(); ++i)
	{
		bool temp;
		cin >> temp;
		number2[i] = temp;
	}

	for (int i = 0; i < size; ++i)
	{
		if (number1[i] != number2[i])
		{
			if (number1[i] == true && number2[i] == false)
			{
				cout << "First bigger" << endl;
				break;
			}
			else
			{
				cout << "Second bigger" << endl;
				break;
			}
		}
		if (i == size - 1)
		{
			cout << "Numbers are equal" << endl;
		}
	}
}