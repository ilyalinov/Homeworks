#include <iostream>

using namespace std;

float power(float x, int n) // warning "not all control paths return a value" again; added "if (n < 0)"; !?
{
    if (n == 1)
	{
		return x;
	}
	else if (n == 0)
	{
		return 1;
	}
	else if (n % 2 == 0 && n > 2)
	{
		float temp = power(x, n / 2);
		return temp * temp;
	}
	else if (n % 2 != 0 && n > 2)
	{
		float temp = power(x, (n - 1) / 2);
		return temp * temp * x;
	}
	else if (n < 0)
	{
		return power(1 / x, -n);
	}
	return x * x;

}

float notPower(float x, int n)
{
	float result = 1;
	if (n >= 1)
	{
		for (int i = 0; i < n; ++i)
		{
			result = result * x;
		}
	}
	else if (n == 0)
	{
		result = 1;
	}
	else if (n < 0)
	{
		return notPower(1 / x, -n);
	}
	return result;
}

void main()
{
	cout << "Enter your power: ";
	int point = 0;
	cin >> point;
	cout << "Enter your number : ";
	float number = 0;
	cin >> number;
	cout << "fast algotithm result:" << endl;
	cout << power(number, point) << endl;
	cout << "slow algorithm result: " << endl;
	cout << notPower(number, point) << endl;
}