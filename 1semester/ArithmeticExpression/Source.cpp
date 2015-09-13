#pragma once
#include <iostream>
#include <fstream>
#include <string>
#include <vector>

#include "BinaryTree.h"

using namespace std;

bool isOperandComplex(string expression)
{
	if (expression[0] == '(')
	{
		return true;
	}
	else
	{
		return false;
	}
}

string getOperand(string expression)
{
	string temp;
	bool isComplex = isOperandComplex(expression);
	if (isComplex)
	{
		int counterOfBrackets = 0;
		unsigned i = 0;
		for (i = 0; i < expression.length(); ++i)
		{
			if (expression[i] == '(')
			{
				counterOfBrackets++;
			}
			if (expression[i] == ')')
			{
				counterOfBrackets--;
			}
			temp += expression[i];
			if (counterOfBrackets == 0)
			{
				break;
			}
		}
	}
	else
	{
		unsigned i = 0;
		for (i = 0; i < expression.length(); ++i)
		{
			if (expression[i] == ' ')
			{
				break;
			}
			temp += expression[i];
		}
	}
	return temp;
}

bool isOperator(string expression)
{
	if (expression == "+" || expression == "-" || expression == "/" || expression == "*")
	{
		return true;
	}
	else
	{
		return false;
	}
}

vector<string> getOperatorAndOperands(string expression)
{
	vector<string> result;
	string temp;
	temp += expression[2];
	result.push_back(temp);
	temp.clear();
	expression.erase(0, 4);

	temp = getOperand(expression);

	expression.erase(0, temp.length() + 1);
	result.push_back(temp);
	temp.clear();

	temp = getOperand(expression);

	result.push_back(temp);
	return result;
}

void ExpressionToTree(BinaryTree *binaryTree, string expression, TreeElement *&treeElement)
{
	vector<string> myVector = getOperatorAndOperands(expression);
	treeElement = createTreeElement(myVector[0]);
	if (isOperandComplex(myVector[1]))
	{
		addLeftChild(treeElement, myVector[1]);
		ExpressionToTree(binaryTree, myVector[1], getLeftChild(treeElement));
	}
	else
	{
		addLeftChild(treeElement, myVector[1]);
	}
	if (isOperandComplex(myVector[2]))
	{
		addRightChild(treeElement, myVector[2]);
		ExpressionToTree(binaryTree, myVector[2], getLeftChild(treeElement));
	}
	else
	{
		addRightChild(treeElement, myVector[2]);
	}
}

int result(TreeElement *treeElement)
{
	/*if (isOperator(getValue(getLeftChild(treeElement))))
	{
		result(getLeftChild(treeElement));
	}
	if (isOperator(getValue(getRightChild(treeElement))))
	{
		result(getRightChild(treeElement));
	}*/
	if (getValue(treeElement) == "+")
	{
		return result(getLeftChild(treeElement)) + result(getRightChild(treeElement));
	}
	else if (getValue(treeElement) == "-")
	{
		return result(getLeftChild(treeElement)) - result(getRightChild(treeElement));
	}
	else if (getValue(treeElement) == "*")
	{
		return result(getLeftChild(treeElement)) * result(getRightChild(treeElement));
	}
	else if (getValue(treeElement) == "/")
	{
		return result(getLeftChild(treeElement)) / result(getRightChild(treeElement));
	}
	else
	{
		return stoi(getValue(treeElement));
	}
}

void main()
{
	ifstream file("Text.txt", ios::in);
	string expression;
	getline(file, expression);
	BinaryTree *binaryTree = createBinaryTree();
	TreeElement *&temp = returnFirst(binaryTree);
	temp = createTreeElement(expression);
	ExpressionToTree(binaryTree, expression, returnFirst(binaryTree));
	cout << "Generated tree: " << endl;
	inorderIncreasingTreeWalk(binaryTree);

	cout << "result: " << endl;
	cout << result(returnFirst(binaryTree)) << endl;

	deleteTree(binaryTree, returnFirst(binaryTree));
	delete binaryTree;
	cout << "Tree deleted" << endl;
}

// There should be spaces between all symbols in the input file! (Like in attached "Text.txt")