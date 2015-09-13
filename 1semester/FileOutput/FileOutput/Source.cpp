#include <iostream>
#include <fstream>
#include <string>

using namespace std;

void main()
{
	ifstream f("Text.txt", ios::in);
	bool isWritten = false;
	char symbol;
	f >> symbol;
	cout << symbol;
	while (!f.eof())
	{
		char symbol1;
		f >> symbol1;
		if (symbol != symbol1)
		{
			cout << symbol1;
		}
		symbol = symbol1;
	}
	f.close();
	cout << endl;
}