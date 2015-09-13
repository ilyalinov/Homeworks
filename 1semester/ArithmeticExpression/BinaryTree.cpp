#include <iostream>
#include <string>

using namespace std;

struct TreeElement
{
	string value;
	TreeElement *left;
	TreeElement *right;
};

struct BinaryTree
{
	TreeElement *first;
};

BinaryTree *createBinaryTree()
{
	BinaryTree *binaryTree = new BinaryTree();
	binaryTree->first = nullptr;
	return binaryTree;
}

TreeElement *createTreeElement(string value)
{
	TreeElement *treeElement = new TreeElement();
	treeElement->left = nullptr;
	treeElement->right = nullptr;
	treeElement->value = value;
	return treeElement;
}

TreeElement *&returnFirst(BinaryTree *binaryTree)
{
	return binaryTree->first;
}

TreeElement *&getLeftChild(TreeElement *treeElement)
{
	return treeElement->left;
}

TreeElement *&getRightChild(TreeElement *treeElement)
{
	return treeElement->right;
}

void printTreeElementFromLeft(TreeElement *treeElement)
{
	if (treeElement->left != nullptr)
	{
		printTreeElementFromLeft(treeElement->left);
	}
	cout << treeElement->value << " ";
	if (treeElement->right != nullptr)
	{
		printTreeElementFromLeft(treeElement->right);
	}
}

void inorderIncreasingTreeWalk(BinaryTree *binaryTree)
{
	if (binaryTree->first != nullptr)
	{
		printTreeElementFromLeft(binaryTree->first);
	}
	else
	{
		cout << "Your tree is empty!" << endl;
	}
	cout << endl;
}

void addLeftChild(TreeElement *treeElement, string expression)
{
	TreeElement *newElement = createTreeElement(expression);
	treeElement->left = newElement;
}

void addRightChild(TreeElement *treeElement, string expression)
{
	TreeElement *newElement = createTreeElement(expression);
	treeElement->right = newElement;
}

void deleteTree(BinaryTree *binaryTree, TreeElement *treeElement)
{
	TreeElement *temp = treeElement;
	if (temp->left != nullptr || temp->right != nullptr)
	{
		if (temp->left != nullptr)
		{
			deleteTree(binaryTree, temp->left);
		}
		if (temp->right != nullptr)
		{
			deleteTree(binaryTree, temp->right);
		}
	}
	delete temp;
}

string getValue(TreeElement *treeElement)
{
	return treeElement->value;
}