#pragma once

// List elements structure
struct ListElement;

// List structure
struct List;

// Creates and returns null list
List *createList();

// Creates list element by value
ListElement *createListElement(int value);

// Inserts list element to the list
void listInsert(List *list, ListElement *newElement);

// Deletes first element in the list and returns its value
int deleteFirst(List *list);

// Checks the list on the emptiness
bool isEmpty(List *list);

// Deletes whole list
void deleteList(List *list);