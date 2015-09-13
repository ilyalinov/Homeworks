#include <iostream>

using namespace std;

#include "BinaryTree.h"

void main()
{
	BinaryTree *binaryTree = createTree();
	add(binaryTree, 1);
	add(binaryTree, 2);
	add(binaryTree, 3);
	add(binaryTree, -1);

	printTree(binaryTree);
}