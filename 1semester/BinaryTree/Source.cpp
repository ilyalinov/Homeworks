#include <iostream>

using namespace std;

#include "BinaryTree.h"

void showMenu()
{
	cout << "0 - exit" << endl;
	cout << "1 - add" << endl;
	cout << "2 - delete" << endl;
	cout << "3 - find" << endl;
	cout << "4 - print tree in increasing order" << endl;
	cout << "5 - print tree int increasing order" << endl;
}

int main()
{
	BinaryTree *binaryTree = createTree();
	
	int k = 0;
	int n = 0;
	while (true)
	{
		showMenu();
		cin >> k;
		switch (k) 
		{
			case 0:
				deleteBinaryTree(binaryTree);
				cout << "Binary tree deleted" << endl;
				return 0;
			case 1:
				cout << "Enter your number:" << endl;
				cin >> n; 
				if (findElement(binaryTree, n) == nullptr)
				{
					add(binaryTree, n);
					cout << "Added" << endl;
				}
				else
				{
					cout << "An element already exists" << endl;
				}
				break;
			case 2:
				cout << "Enter your number:" << endl;
				cin >> n;
				deleteTreeElement(binaryTree, findElement(binaryTree, n));
				break;
			case 3:
				cout << "Enter your number:" << endl;
				cin >> n;
				if (findElement(binaryTree, n) == nullptr)
				{
					cout << "Doesn't exist" << endl;
				}
				else
				{
					cout << "There is such element in the tree" << endl;
				}
				break;
			case 4:
				cout << "Printed tree in increasing order:" << endl;
				inorderIncreasingTreeWalk(binaryTree);
				break;
			case 5:
				cout << "Printed tree in decreasing order:" << endl;
				inorderDecreasingTreeWalk(binaryTree);
				break;
		}
	}
	return 0;
}