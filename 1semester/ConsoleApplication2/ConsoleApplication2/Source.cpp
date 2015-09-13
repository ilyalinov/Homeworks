#include <iostream>

using namespace std;

void main()
{
	cout << "Enter your number: \n";
	int x = 0;
	cin >> x;
	int squareOfX = x * x;
	cout << "Your result: \n";
	cout << (squareOfX + x) * (squareOfX + 1) + 1 << endl;
}