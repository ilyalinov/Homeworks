#include <iostream>
#include <vector>

using namespace std;

vector<int> merge(vector<int> leftList, vector<int> rightList)
{
	vector<int> list;
	int leftTemp = 0;
	int rightTemp = 0;
	while (leftTemp != leftList.size() && rightTemp != rightList.size())
	{
		if (leftList[leftTemp] > rightList[rightTemp])
		{
			list.push_back(rightList[rightTemp]);
			rightTemp++;
		}
		else
		{
			list.push_back(leftList[leftTemp]);
			leftTemp++;
		}
	}
	if (leftTemp == leftList.size())
	{
		while (rightTemp <= rightList.size() - 1)
		{
			list.push_back(rightList[rightTemp]);
			rightTemp++;
		}
	}
	else if (rightTemp == rightList.size())
	{
		while (leftTemp <= leftList.size() - 1)
		{
			list.push_back(leftList[leftTemp]);
			leftTemp++;
		}
	}
	return list;
}

vector<int> divideList(vector<int> list, int startPosition, int finishPosition)
{
	vector<int> newList;
	for (int i = 0; i <= finishPosition; ++i)
	{
		if (i >= startPosition)
		{
			newList.push_back(list[i]);
		}
	}
	return newList;
}

vector<int> sort(vector<int> list)
{
	if (list.size() <= 1)
	{
		return list;
	}
	vector<int> leftList = divideList(list, 0, (list.size() - 1) / 2);
	vector<int> rightList = divideList(list, (list.size() - 1) / 2 + 1, list.size() - 1);
	leftList = sort(leftList);
	rightList = sort(rightList);
	list = merge(leftList, rightList);
	return list;
}