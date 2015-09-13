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

// Inserts element to the list tail
void listInsertToTheTail(List *, ListElement *);

// Inserts element to the list head
void listInsertToTheHead(List *, ListElement *);

// Deletes all list
void deleteList(List *);

// Prints whole list
void printList(List *list);

// Add
List* pluss(List *list1, List *list2);

// 
List* multiplication(List *list1, List *list2);

// 
List* minuss(List *list1, List *list2);