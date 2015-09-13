#pragma once 
#include <iostream>
#include <string>
#include "Stack.h"

using namespace std;

void main()
{
	string buffer;
	getline(cin, buffer);
	Stack *stack = createStack();

	unsigned i = 0;
	string s;
	while (i < buffer.size())
	{
		for (unsigned j = 0; buffer[i] != ' ' && i < buffer.size(); j++, i++)
		{
			s.resize(j + 1);
			s[j] = buffer[i];
		}
		if (s == "+")
		{
			int operand1 = pop(stack); // That can't be written before if because before "if" we don't know how many 
			int operand2 = pop(stack); // operands from stack we need to take.
			if (operand1 == -1 || operand2 == -1)
			{
				cout << "Invalid expression!" << endl;
				return;
			}
			push(stack, operand1 + operand2);
		}
		else if (s == "-")
		{
			int operand1 = pop(stack);
			int operand2 = pop(stack);
			if (operand1 == -1 || operand2 == -1)
			{
				cout << "Invalid expression!" << endl;
				return;
			}
			push(stack, operand2 - operand1);
		}
		else if (s == "*")
		{
			int operand1 = pop(stack);
			int operand2 = pop(stack);
			if (operand1 == -1 || operand2 == -1)
			{
				cout << "Invalid expression!" << endl;
				return;
			}
			push(stack, operand1 * operand2);
		}
		else if (s == "/")
		{
			int operand1 = pop(stack);
			int operand2 = pop(stack);
			if (operand1 == -1 || operand2 == -1 || operand1 == 0)
			{
				cout << "Invalid expression!" << endl;
				return;
			}
			push(stack, operand2 / operand1);
		}
		else
		{
			int operand = stoi(s);
			push(stack, operand);
		}
		s.clear();
		++i;
	}
	int result = pop(stack);
	if (empty(stack))
	{
		cout << result << endl;
	}
	else
	{
		cout << "Invalid expression" << endl;
	}
	deleteStack(stack);
}
// Tested and working.
// Tests: 
// 1; result: 1; 
// 1 2 +; result: 3;
// 7 2 * 3 -; result: 
// 2 1 / 7 + 3 -; result: 6;
// 1 2 + 0 /; result: invalid expression;
// 9 6 - 1 2 + *; result: 9;