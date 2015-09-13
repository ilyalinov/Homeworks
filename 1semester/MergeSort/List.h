#pragma once 
#include <fstream>
#include <string>

using namespace std;

// List elements structure
struct ListElement;

// List structure
struct List;

// Creates empty list and returns it
List* createList();

// Adds element to the list by value
void addElementByValue(List *list, int value);

// Compares two list elements
bool compare(List* list1, ListElement *listElement1, List *list2, ListElement *listElement2);

// Returns list size
int getListSize(List *list);

// Returns first list element
ListElement* first(List *list);

// Returns list element value
int getValue(List* list, ListElement *listElement);

// Returns next list element after the given one
ListElement* getNext(ListElement *listElement);

// Writes file to the list
void fileToList(ifstream &file, List *list);

// Prints whole list to console
void printList(List *list);

// Writes part of the list from startPosition to finishPosition and to a new list. Then returns new list
List* divideList(List *list, int startPosition, int finishPosition);

// Deletes whole list
void deleteList(List *list);

// Nobody reads comments!
bool hasNext(List* list, ListElement* listElement);