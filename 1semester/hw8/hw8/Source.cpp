#include <iostream>
#include <string>

using namespace std;

void main()
{
	cout << "Enter your string: ";
	string s;
	cin >> s;

	int bracketsBalance = 0;
	bool isOk = true;
	for (int i = 0; i < s.length(); ++i)
	{
		if (s[i] == '(')
		{
			++bracketsBalance;
		}
		if (s[i] == ')')
		{
			--bracketsBalance;
		}
		if (bracketsBalance < 0)
		{
			isOk = false;
			break;
		}

	}
	if (bracketsBalance == 0)
	{
		cout << "balanced" << endl;
	}
	else
	{	
		cout << "not balanced" << endl;
	}

}