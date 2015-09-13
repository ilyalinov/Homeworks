#include <iostream>
#include <vector>

using namespace std;

//struct List
//{
//	vector<int> key;
//	vector<int> prev;
//	vector<int> next;
//	int head = -1;
//	int size = 0;
//};
//
//List* createList()
//{
//	return new List();
//}
//
//int listSearch(List *list, int value)
//{
//	int temp = list->head;
//	while (temp != -1 && list->key[temp] != value)
//	{
//		temp = list->next[temp];
//	}
//	return temp;
//}
//
//int addKey(List *list, int key)
//{
//	list->key.push_back(key);
//	return list->key.size() - 1;
//}
//
//void listInsert(List *list, int element)
//{
//	list->next.resize(list->size + 1);
//	list->prev.resize(list->size + 1);
//	list->next[element] = list->head;
//	if (list->head != -1)
//	{
//		list->prev[list->head] = element;
//	}
//	list->head = element;
//	list->prev[element] = -1;
//	list->size++;
//}
//
//void listDelete(List *list, int element)
//{
//	if (list->prev[element] != -1)
//	{
//		list->next[list->prev[element]] = list->next[element];
//	}
//	else
//	{
//		list->head = list->next[element];
//	}
//	if (list->next[element] != -1)
//	{
//		list->prev[list->next[element]] = list->prev[element];
//	}
//}
//
//void deleteList(List *list)
//{
//	delete list;
//}
//
//int getListSize(List *list)
//{
//	return list->size;
//}
//
//List* divideList(List *list, int startPosition, int finishPosition)
//{
//	List *newList = createList();
//	int temp = list->head;
//	for (int i = 0; i < list->size; ++i)
//	{
//		if (i >= startPosition && i <= finishPosition)
//		{
//			listInsert(newList, addKey(newList, list->key[temp]));
//		}
//		temp = list->next[temp];
//	}
//	return newList;
//}
//
//int head(List *list)
//{
//	return list->head;
//}
//
//bool compare(List *leftList, int pointer1, List *rightList, int pointer2)
//{
//	return (leftList->key[pointer1] > rightList->key[pointer2]);
//}
//
//int getKey(List *list, int pointer)
//{
//	return list->key[pointer];
//}
//
//int getNext(List *list, int pointer)
//{
//	return list->next[pointer];
//}
//
//void printList(List *list)
//{
//	int temp = list->head;
//	cout << "Printed list" << endl;
//	while (temp != -1)
//	{
//		cout << list->key[temp] << " ";
//		temp = list->next[temp];
//	}
//}

