#include <iostream>

using namespace std;

struct StackElem
{
	int value;
	StackElem *next;
};

struct Stack
{
	StackElem *head;
};

void push(Stack *stack, int number)
{
	StackElem *stackElem = new StackElem();
	stackElem->value = number;
	stackElem->next = stack->head;
	stack->head = stackElem;
}

int pop(Stack *stack)
{
	if (stack->head == nullptr)
	{
		return -1;
	}
	int value = stack->head->value;
	StackElem *temp = stack->head->next;
	delete stack->head;
	stack->head = temp;
	return value;
}

void deleteStack(Stack *stack)
{
	while (stack->head != nullptr)
	{
		StackElem *temp = new StackElem();
		stack->head = stack->head->next;
		delete temp;
	}
	delete stack;
}

void main()
{
	Stack *stack = new Stack();
	stack->head = nullptr;
	push(stack, 2);
	push(stack, 1);
	
	int head = pop(stack);
	cout << head << endl;
	cout << pop(stack) << endl;
	cout << pop(stack) << endl;
	
	deleteStack(stack);
}