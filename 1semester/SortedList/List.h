#pragma once

// List elements structure
struct ListElement;

// List structure
struct List;

// Creates and returns null list 
List *createList();

// Creates list element by value. Then returns it.
ListElement *createListElement(int value);

// Inserts list element in the list
void listInsert(List *list, ListElement *newElement);

// Deletes whole list
void deleteList(List *list);

// Prints whole list to console
void printList(List *list);