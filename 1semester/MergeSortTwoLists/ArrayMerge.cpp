#include <iostream>
#include "ArrayList.h"

using namespace std;

List* merge(List *leftList, List *rightList)
{
	List *list = createList();
	int leftTemp = head(leftList);
	int rightTemp = head(rightList);
	while (leftTemp != -1 && rightTemp != -1)
	{
		if (compare(leftList, leftTemp, rightList, rightTemp))
		{
			listInsert(list, addKey(list, getKey(leftList, leftTemp)));
			leftTemp = getNext(leftList, leftTemp);
		}
		else
		{
			listInsert(list, addKey(list, getKey(rightList, rightTemp)));
			rightTemp = getNext(rightList, rightTemp);
		}
	}
	if (leftTemp == -1)
	{
		while (rightTemp != -1)
		{
			listInsert(list, addKey(list, getKey(rightList, rightTemp)));
			rightTemp = getNext(rightList, rightTemp);
		}
	}
	else if (rightTemp == -1)
	{
		while (leftTemp != -1)
		{
			listInsert(list, addKey(list, getKey(leftList, leftTemp)));
			leftTemp = getNext(leftList, leftTemp);
		}
	}
	return list;
}

List* sort(List *list)
{
	if (getListSize(list) <= 1)
	{
		return list;
	}
	else
	{
		List* leftList = createList();
		leftList = divideList(list, 0, (getListSize(list) - 1) / 2);
		List* rightList = createList();
		rightList = divideList(list, (getListSize(list) - 1) / 2 + 1, getListSize(list) - 1);
		leftList = sort(leftList);
		rightList = sort(rightList);
		list = merge(leftList, rightList);
		return list;
	}
}