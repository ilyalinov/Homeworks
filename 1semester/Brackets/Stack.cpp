#include <iostream>

using namespace std;

struct StackElement
{
	int value;
	StackElement *next;
};

struct Stack
{
	StackElement *head;
};

Stack* createStack()
{
	Stack *stack = new Stack();
	return stack;
}

void push(Stack *stack, int number)
{
	StackElement *stackElement = new StackElement();
	stackElement->value = number;
	stackElement->next = stack->head;
	stack->head = stackElement;
}

int pop(Stack *stack)
{
	if (stack->head == nullptr)
	{
		return -1;
	}
	StackElement *temp = stack->head;
	int value = temp->value;
	stack->head = temp->next;
	delete temp;
	return value;
}

void deleteStack(Stack *stack)
{
	while (stack->head != nullptr)
	{
		StackElement *temp = stack->head;
		stack->head = stack->head->next;
		delete temp;
	}
	delete stack;
	cout << "Stack deleted" << endl;
}

bool empty(Stack *stack)
{
	if (stack->head == nullptr)
	{
		return true;
	}
	else
	{
		return false;
	}
}