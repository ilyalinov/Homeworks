#include <iostream>
#include <time.h>
#include <vector>

using namespace std;

vector<int> makeDigits(int number)
{
	vector<int> result;
	while (number > 0)
	{
		result.push_back(number % 10);
		number = number / 10;
	}
	return result;
}

bool analysis(int userNumber, int number)
{
	bool isEnd = false;
	vector<int> number1 = makeDigits(number);
	vector<int> number2 = makeDigits(userNumber);
	int cows = 0;
	int bulls = 0;

	if (number1.size() != number2.size())
	{
		cout << "wrong number" << endl;
	}
	else
	{
		for (unsigned i = 0; i < number1.size(); ++i)
		{
			if (number1[i] == number2[i])
			{
				bulls++;
			}
		}
		for (unsigned i = 0; i < number2.size(); ++i)
		{
			for (unsigned j = 0; j < number1.size(); ++j)
			{
				if (number2[i] == number1[j] && i != j)
				{
					cows++;
				}
			}
		}
		cout << "cows: " << cows << endl;
		cout << "bulls: " << bulls << endl;
		if (bulls == 4)
		{
			cout << "You win" << endl;
			isEnd = true;
		}
	}
	return isEnd;
}

void main()
{
	int const maxNumber = 10000;
	int const minNumber = 1000;
	srand(static_cast<unsigned>(time(nullptr)));
	int number = rand() % maxNumber;
	if (number < minNumber)
	{
		number += minNumber;
	}
	while (true)
	{
		cout << "Enter your 4-digits number: " << endl;
		int n = 0;
		cin >> n;
		if (analysis(number, n))
		{
			break;
		}
	}
}