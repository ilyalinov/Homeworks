#pragma once

// You can see those comments (exactly the same) in "List.h"

// 
struct ListArray;

// 
ListArray* createListArray();

//
void addElementByValue(ListArray* list, int value);

//
void addElementByValue(ListArray* list, int value);

//
void fileToList(ifstream &file, ListArray* list);

// 
int first(ListArray *list);

//
bool compare(ListArray* list1, int pointer1, ListArray* list2, int pointer2);

// 
int getListSize(ListArray* list);

// 
int getValue(ListArray* list, int pointer);

// 
ListArray* divideList(ListArray* list, int startPosition, int finishPosition);

//
int getNext(int pointer);

// 
void deleteList(ListArray *list);

// 
bool hasNext(ListArray* list, int pointer);

// 
void printList(ListArray* list);