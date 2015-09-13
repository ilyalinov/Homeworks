#pragma once
#include <iostream>
#include <string>

using namespace std;

// tree elements structure
struct TreeElement
{
};

// binary tree structure
struct BinaryTree
{
};

//
BinaryTree *createBinaryTree();

//
TreeElement *createTreeElement(string);

//
TreeElement *&returnFirst(BinaryTree *);

//
TreeElement *&getLeftChild(TreeElement *);

//
TreeElement *&getRightChild(TreeElement *);

//
void inorderIncreasingTreeWalk(BinaryTree *binaryTree);

//
void addLeftChild(TreeElement *, string);

//
void addRightChild(TreeElement *, string);

//
void deleteTree(BinaryTree *, TreeElement *);

//
string getValue(TreeElement *);