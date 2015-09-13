#pragma once

// Stack elements structure
struct StackElement;

// Stack strucutre
struct Stack;

// Creates and returns empty stack
Stack* createStack();

// Pushes symbol(number) to the stack
void push(Stack *stack, char number);

// Deletes first element in the stack
char pop(Stack *stack);

// Deletes whole stack
void deleteStack(Stack *stack);

// Checks if the stack is empty
bool empty(Stack *stack);