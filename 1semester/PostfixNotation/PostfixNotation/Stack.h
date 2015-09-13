#pragma once

// stack element structure
struct StackElement;

// stack structure
struct Stack;

// the creation of the stack
Stack* createStack();

// add number to the stack
void push(Stack *stack, int number);

// delete last element in stack and return its value
int pop(Stack *stack);

// delete all stack
void deleteStack(Stack *stack);

// returns true only if the stack is empty
bool empty(Stack *stack);