#include <iostream>

using namespace std;

struct TreeElement
{
	int value = 0;
	int amount = 0;
	TreeElement *right = nullptr;
	TreeElement *left = nullptr;
	TreeElement *parent = nullptr;
};

struct BinaryTree
{
	TreeElement *first = nullptr;
};

BinaryTree* createTree()
{
	return new BinaryTree();
}

TreeElement* createTreeElement(int number)
{
	TreeElement *newElement = new TreeElement();
	newElement->value = number;
	newElement->left = nullptr;
	newElement->right = nullptr;
	newElement->parent = nullptr;
	return newElement;
}

void add(BinaryTree *binaryTree, int number)
{
	TreeElement *parent = nullptr;
	TreeElement *temp = binaryTree->first;
	while (temp != nullptr)
	{
		parent = temp;
		if (number > temp->value)
		{
			temp = temp->right;
		}
		else
		{
			temp = temp->left;
		}
	}
	TreeElement *newElement = createTreeElement(number);
	newElement->parent = parent;
	if (parent == nullptr)
	{
		binaryTree->first = newElement;
	}
	else
	{
		if (number > parent->value)
		{
			parent->right = newElement;
		}
		else
		{
			parent->left = newElement;
		}
	}
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

void printTreeElementFromRight(TreeElement *treeElement)
{
	if (treeElement->right != nullptr)
	{
		printTreeElementFromRight(treeElement->right);
	}
	cout << treeElement->value << " ";
	if (treeElement->left != nullptr)
	{
		printTreeElementFromRight(treeElement->left);
	}
}

void inorderDecreasingTreeWalk(BinaryTree *binaryTree)
{
	if (binaryTree->first != nullptr)
	{
		printTreeElementFromRight(binaryTree->first);
	}
	else
	{
		cout << "Your tree is empty!" << endl;
	}
	cout << endl;
}

TreeElement* treeSuccessor(TreeElement *treeElement)
{
	TreeElement *temp = treeElement->right;
	while (temp->left != nullptr)
	{
		temp = temp->left;
	}
	return temp;
}

void deleteTreeElement(BinaryTree *binaryTree, TreeElement *treeElement)
{
	if (treeElement == nullptr)
	{
		cout << "Element doesn't exist" << endl;
		return;
	}
	TreeElement *successor = treeElement;
	TreeElement *temp = treeElement;
	if (treeElement->left == nullptr || treeElement->right == nullptr)
	{
		successor = treeElement;
	}
	else
	{
		successor = treeSuccessor(treeElement);
	}
	if (successor->left != nullptr)
	{
		temp = successor->left;
	}
	else
	{
		temp = successor->right;
	}
	if (temp != nullptr)
	{
		temp->parent = successor->parent;
	}
	if (successor->parent == nullptr)
	{
		binaryTree->first = temp;
	}
	else if (successor == successor->parent->left)
	{
		successor->parent->left = temp;
	}
	else if (successor == successor->parent->right)
	{
		successor->parent->right = temp;
	}
	cout << "deleted element with value = " << treeElement->value << endl;
	if (successor != treeElement)
	{
		treeElement->value = successor->value;
	}
	delete successor;
}

TreeElement* findElement(BinaryTree *binaryTree, int number)
{
	TreeElement* temp = binaryTree->first;
	while (temp != nullptr && temp->value != number)
	{
		if (number > temp->value)
		{
			temp = temp->right;
		}
		else
		{
			temp = temp->left;
		}
	}
	return temp;
}

TreeElement* returnHead(BinaryTree *binaryTree)
{
	return binaryTree->first;
}

bool isTreeEmpty(BinaryTree *binaryTree)
{
	return (binaryTree->first == nullptr);
}

void deleteBinaryTree(BinaryTree *binaryTree)
{
	while (!isTreeEmpty(binaryTree))
	{
		deleteTreeElement(binaryTree, returnHead(binaryTree));
	}
	delete binaryTree;
}