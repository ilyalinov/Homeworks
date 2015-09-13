#pragma once
#include <iostream>

using namespace std;

// List elements structure
struct ListElement;

// List structure
struct List;

// Creates list
List *createList();

// Creates list element
ListElement *createListElement(int);

// Inserts element to the list
void listInsert(List *, ListElement *);

// Deletes all list
void deleteList(List *);

// Prints all list to file
void printListToFile(List *, ofstream &);