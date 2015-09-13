#include <iostream>

using namespace std;

void main()
{
	cout << "Enter your number: ";
	int n = 0;
	cin >> n;

	for (int i = 2; i <= n; ++i)
	{
		bool isPrime = true; 
		for (int j = 2; j < i; ++j)
		{
			if (i % j == 0)
			{
				isPrime = false;
			}
		}
		if (isPrime)
		{
			cout << i << endl;
		}
	}

}