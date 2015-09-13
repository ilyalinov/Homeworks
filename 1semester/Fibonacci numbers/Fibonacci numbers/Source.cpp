#include <iostream>

using namespace std;

int fibonacci1(int number)
{
	if (number > 1)
	{
		return fibonacci1(number - 1) + fibonacci1(number - 2);
	}
	else
	{
		return 1;
	}
}

int fibonacci2(int number)
{
	int const size = 3;
	int fibNumbers[size];
	fibNumbers[1] = 1;
	fibNumbers[2] = 1;
	for (int i = size - 1; i <= number; ++i)
	{
		int fibNext = fibNumbers[size - 1] + fibNumbers[size - 2];
		for (int j = 0; j < size - 1; ++j)
		{
			fibNumbers[j] = fibNumbers[j + 1];
		}
		fibNumbers[size - 1] = fibNext;
	}
	if (number < size - 1)
	{
		return 1;
	}
	else
	{
		return fibNumbers[size - 1];
	}
}

void main()
{
	cout << "Enter your number: ";
	int n = 0;
	cin >> n;
	cout << "Choose the algorithm (1 - slow recursion; 2 - fast cycle): ";
	int userChoice = 0;
	cin >> userChoice;
	if (userChoice == 1)
	{
		int result = fibonacci1(n);
		cout << "Result: " << result << endl;
	}
	if (userChoice == 2)
	{
		int result = fibonacci2(n);
		cout << "Result: " << result << endl;
	}
	
}