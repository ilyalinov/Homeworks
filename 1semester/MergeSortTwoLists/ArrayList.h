#pragma once

// 
struct List;

// 
List* createList();

// 
int listSearch(List *list, int value);

// 
int addKey(List *list, int key);

// 
void listInsert(List *list, int element);

// 
void deleteList(List *list);

// 
int getListSize(List *list);

// 
List* divideList(List *list, int startPosition, int finishPosition);

// 
int head(List *list);

// 
bool compare(List *leftList, int pointer1, List *rightList, int pointer2);

// 
int getKey(List *list, int pointer);

// 
int getNext(List *list, int pointer);

// 
void printList(List *list);