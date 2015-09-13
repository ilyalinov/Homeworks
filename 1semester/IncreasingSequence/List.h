#pragma once

// 
struct ListElement;

// 
struct List;

// 
List *createList();

// 
ListElement *createListElement(int value);

// 
void listInsert(List *list, ListElement *newElement);

// 
void deleteList(List *list);

// 
void printList(List *list);

// 
int getListSize(List *list);

// 
int getValue(ListElement *listElement);

// 
ListElement* getNext(ListElement *listElement);

// 
ListElement* getHead(List *list);