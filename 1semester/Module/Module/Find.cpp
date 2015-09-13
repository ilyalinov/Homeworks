#include <vector>
#include <iostream>

using namespace std;

void findMostCommon(vector<int> &array)
{
	int maxCounter = 0;
	int counterOfMostCommon = 1;
	int number = 0;
	unsigned i = 1;
	for (i = 1; i < array.size(); ++i)
	{
		if (array[i] == array[i - 1])
		{
			counterOfMostCommon++;
		}
		else if (counterOfMostCommon > maxCounter)
		{
			maxCounter = counterOfMostCommon;
			number = i - 1;
			counterOfMostCommon = 1;
		}
	}
    if (counterOfMostCommon > maxCounter)
	{
		maxCounter = counterOfMostCommon;
		number = i - 1;
		counterOfMostCommon = 1;
	}
	if (maxCounter == 1)
	{
		cout << "All elems are different" << endl;
	}
	else
	{
		cout << "Most common: " << array[number] << endl;
		cout << "Met " << maxCounter << " times" << endl;
	}
}