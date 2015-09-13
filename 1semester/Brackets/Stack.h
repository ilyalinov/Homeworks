#pragma once

//
struct StackElement
{
};

//
struct Stack
{
};

//
Stack* createStack();

//
void push(Stack *, int );

//
int pop(Stack *);

//
void deleteStack(Stack *);

//
bool empty(Stack *);