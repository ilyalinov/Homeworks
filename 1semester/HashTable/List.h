#pragma once
#include <iostream>
#include <string>

using namespace std;

// List elements structure
struct ListElement;

// List structure
struct List;

// Creates empty list
List *createList();

// Creates list element and put string from argument to the value field
ListElement *createListElement(string);

// Add list element to the list
void listInsert(List *, ListElement *); 

// Finds list element in the list. Return false if there's no such element in our list. 
bool findListElement(List *, ListElement *);

// Removes all list
void deleteList(List *);

// Prints our list to console
void printList(List *);