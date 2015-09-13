#pragma once
#include <iostream>

using namespace std;

// List elements structure
struct ListElement;

// List structure
struct List;

// Creates empty list
List *createList();

// Creates list element by integer
ListElement *createListElement(int);

// insert element to the list
void listInsert(List *, ListElement *);

// deletes all list
void deleteList(List *);

// prints all list to console
void printList(List *);

bool isListSymmetric(List *list);