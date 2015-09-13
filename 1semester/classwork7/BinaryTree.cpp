#include <iostream>

using namespace std;

struct TreeElement
{
	int value;
	int amount = 0;
	TreeElement *right;
	TreeElement *left;
};

struct BinaryTree
{
	TreeElement *first;
};

BinaryTree* createTree()
{
	BinaryTree *binaryTree = new BinaryTree();
	binaryTree->first = nullptr;
	return binaryTree;
}

void add(BinaryTree *binaryTree, int number)
{
	TreeElement *newElement = new TreeElement();
	newElement->value = number;
	++newElement->amount;
	newElement->right = nullptr;
	newElement->left = nullptr;
	if (binaryTree->first == nullptr)
	{
		binaryTree->first = newElement;
	}
	else
	{
		TreeElement *temp = binaryTree->first;
		while (true)
		{
			if (number > temp->value)
			{
				if (temp->right == nullptr)
				{
					temp->right = newElement;
					break;
				}
				else
				{
					temp = temp->right;
					continue;
				}
			}
			else if (number == temp->value)
			{
				++temp->amount;
				break;
			}
			else if (number < temp->value)
			{
				if (temp->left == nullptr)
				{
					temp->left = newElement;
					break;
				}
				else
				{
					temp = temp->left;
					continue;
				}
			}
		}
	}
}

void printTreeElement(TreeElement *treeElement)
{  
	if (treeElement->left != nullptr)
	{
		printTreeElement(treeElement->left);
	}
	cout << treeElement->value << " ";
	if (treeElement->right != nullptr)
	{
		printTreeElement(treeElement->right);
	}
}

void printTree(BinaryTree *binaryTree)
{
	if (binaryTree->first != nullptr)
	{
		printTreeElement(binaryTree->first);
	}
	else
	{
		cout << "Your tree is empty!" << endl;
	}
}