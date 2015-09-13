#include <iostream>
#include "List.h"
#include "ListArray.h"

using namespace std;

typedef int ListElementType; // --> typedef ListElement* ListElementType;


typedef ListArray* MyList; // --> typedef List* MyList;



MyList merge(MyList leftList, MyList rightList)
{
	MyList list = createListArray(); // --> MyList list = createList();
	ListElementType leftTemp = first(leftList);
	ListElementType rightTemp = first(rightList);
	while (hasNext(leftList, leftTemp) && hasNext(rightList, rightTemp))
	{
		bool comparationResult = compare(leftList, leftTemp, rightList, rightTemp);
		if (!comparationResult)
		{
			addElementByValue(list, getValue(leftList, leftTemp));
			leftTemp = getNext(leftTemp);
		}
		else
		{
			addElementByValue(list, getValue(rightList, rightTemp));
			rightTemp = getNext(rightTemp);
		}
	}
	if (!hasNext(leftList, leftTemp))
	{
		while (hasNext(rightList, rightTemp))
		{
			addElementByValue(list, getValue(rightList, rightTemp));
			rightTemp = getNext(rightTemp);
		}
	}
	else if (!hasNext(rightList, rightTemp))
	{
		while (hasNext(leftList, leftTemp))
		{
			addElementByValue(list, getValue(leftList, leftTemp));
			leftTemp = getNext(leftTemp);
		}
	}
	deleteList(leftList);
	deleteList(rightList);
	return list;
}

MyList sort(MyList list)
{
	if (getListSize(list) <= 1)
	{
		return list;
	}
	MyList leftList = createListArray(); // --> MyList leftList = createList();
	leftList = divideList(list, 0, (getListSize(list) - 1) / 2);
	MyList rightList = createListArray(); // --> MyList rightList = createList();
	rightList = divideList(list, (getListSize(list) - 1) / 2 + 1, getListSize(list) - 1);
	leftList = sort(leftList);
	rightList = sort(rightList);
	list = merge(leftList, rightList);
	return list;
}