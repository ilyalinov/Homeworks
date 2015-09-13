#include <iostream>
#include <vector>
#include <string>
#include "Stack.h"


using namespace std;

int priority(const char c)
{
	const vector<char> operation{ '+', '-', '*', '^', '/', '(', ')' };
	const vector<int> value{ 1, 1, 2, 3, 2, 0, 0 };
	for (unsigned int i = 0; i < operation.size(); ++i)
	{
		if (operation[i] == c)
		{
			return value[i];
		}
	}
	return -1;
}

bool isDigit(const char c)
{
	return (static_cast<int>(c) <= 57 && static_cast<int>(c) >= 48);
}

bool isOperator(const char c)
{
	const vector<char> operation{ '+', '-', '*', '^', '/', '(', ')' };
	for (auto const &c1 : operation)
	{
		if (c == c1)
		{
			return true;
		}
	}
	return false;
}

void main()
{
	string s;
	cout << "Enter your expression(without spaces and other extra symbols): " << endl;
	cin >> s;
	string result;
	Stack *stack = createStack();
	for (auto const &c : s)
	{
		if (c == '(')
		{
			push(stack, c);
		}
		else if (c == ')')
		{
			while (true)
			{
				char c1 = pop(stack);
				if (c1 == '!')
				{
					cout << "Invalid expression" << endl;
					return;
				}
				else if (c1 == '(')
				{
					break;
				}
				else
				{
					result = result + c1 + ' ';
				}
			}
		}
		else if (isDigit(c))
		{
			result = result + c + ' ';
		}
		else if (isOperator(c))
		{
			char c1 = pop(stack);
			while (priority(c) <= priority(c1))
			{
				result = result + c1 + ' ';
				c1 = pop(stack);
			}
			if (c1 != '!')
			{
				push(stack, c1);
			}
			push(stack, c);
		}
	}

	while (!empty(stack))
	{
		char c = pop(stack);
		if (!isOperator(c))
		{
			cout << "Invalid expression" << endl;
			return;
		}
		result = result + c + ' ';
	}
	cout << result << endl;
	deleteStack(stack);
}
// Tested and working.
// Tests: 
// (1+1)); result: invalid expression;
// (1+1); result: 1 1 +;
// (1+1)*2/(3+4*5); result: 1 1 + 2 * 3 4 5 * + /;
// ((1-1)+2)/(5*7)+3; result: 1 1 - 2 + 5 7 * / 3 +;
// (1+1-3*4)+5/9(); result:  1 1 + 3 4 * - 5 9 / +;