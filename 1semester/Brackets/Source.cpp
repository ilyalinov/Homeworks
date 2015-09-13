#include <iostream>
#include <string> 
#include <vector>

using namespace std;

#include "Stack.h"

int charToInt(char c)
{
	const vector<int> bracketNumber{ 0, 1, 3, 4, 6, 7 };
	const vector<char> bracket{ '(', ')', '{', '}', '[', ']' };
	for (unsigned int i = 0; i < bracket.size(); ++i)
	{
		if (bracket[i] == c)
		{
			return bracketNumber[i];
		}
	}
	return -1;
}

void main()
{
	string s;
	cout << "Enter your string with brackets: " << endl;
	cin >> s;
	Stack *stack = createStack();

	for (const auto &c : s)
	{
		if (!empty(stack))
		{
			int number = pop(stack);
			if (number != charToInt(c) - 1)
			{
				push(stack, number);
				push(stack, charToInt(c));
			}
		}
		else
		{
			push(stack, charToInt(c));
		}
	}
	if (empty(stack))
	{
		cout << "Yes" << endl;
	}
	else
	{
		cout << "No" << endl;
	}
	deleteStack(stack);
}