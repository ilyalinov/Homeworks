#include <iostream>

using namespace std;

int division1(int dividend, int divider)
{
	int t = 0;
	int quotient = 0;
	while (t <= dividend)
	{
		t = t + divider;
		++quotient;
	}
	t = t - divider;
	return --quotient;
}

int division2(int dividend, int divider)
{
	int t = 0;
	int quotient = 0;
	while (t > dividend)
	{
		t = t + divider;
		++quotient;
	}
	return quotient;
}

void main()
{
	cout << "Enter the dividend: ";
	int dividend = 0;
	cin >> dividend;
	cout << "Enter the divider: ";
	int divider = 0;
	cin >> divider;

	int quotient = 0;
	int residue = 0;
	if (dividend >= 0 && divider > 0)
	{
		quotient = division1(dividend, divider);
		residue = dividend - divider * quotient;
	}
	if (dividend >= 0 && divider < 0)
	{
		divider = -divider;
		quotient = -division1(dividend, divider);
		residue = dividend - ((-divider) * quotient);
	}
	if (dividend < 0 && divider < 0)
	{
		quotient = division2(dividend, divider);
		residue = dividend - divider * quotient;
	}
	if (dividend < 0 && divider > 0)
	{
		divider = -divider;
		quotient = -division2(dividend, divider);
		residue = dividend - ((-divider) * quotient);
	}
	cout << "Result: " << endl;
	cout << "quotient = " << quotient << endl;
	cout << "residue = " << residue << endl;

}
