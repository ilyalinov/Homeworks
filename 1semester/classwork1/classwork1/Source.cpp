#include <iostream>
#include <time.h>

using namespace std;

void main()
{
	srand(time(nullptr));
	/*
	for (int i = 0; i < 10; ++i)
	{
		int a = rand() % 100;
		cout << a << endl;
	}
	*/

	//vector<int> array; //vector

	int x = 0;
	int y = 1;
	int a = 1 + (x == y ? 1 : 2); // 1 - true; 2 - false
	cout << a << endl;

}