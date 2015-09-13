#include <iostream>

using namespace std;

bool binarySearch(int array[], int elem, int left, int right)
{
	if (array[(right + left) / 2] == elem)
	{
		return true;
	}
	else if (right - left > 1)
	{
		if (array[right] == elem)
		{
			return true;
		}
		else if (array[left] == elem)
		{
			return true;
		}
		else if (array[(left + right) / 2] > elem)
		{
			return binarySearch(array, elem, left, (left + right) / 2);
		}
		else if (array[(left + right) / 2] < elem)
		{
			return binarySearch(array, elem, (left + right) / 2, right);
		}
	}
	else if (right - left <= 1)
	{
		return false;
	}
}

void main()
{
	int a[10];
	for (int i = 0; i < 10; ++i)
	{
		cin >> a[i];
	}
	cout << "elem: " << endl;
	int n = 0;
	cin >> n;
	cout << binarySearch(a, n, 0, 9) << endl;
}