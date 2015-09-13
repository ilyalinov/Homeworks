#pragma once

// tree elements structure
struct TreeElement;

// binary tree structure
struct BinaryTree;

// add element to tree
void add(BinaryTree *binaryTree, int number);

// returns created empty binary tree
BinaryTree* createTree();

// print binary tree to console in increasing order
void inorderIncreasingTreeWalk(BinaryTree *binaryTree);

// print binary tree to console in decreasing order
void inorderDecreasingTreeWalk(BinaryTree *binaryTree);

// delete tree element
void deleteTreeElement(BinaryTree *binaryTree, TreeElement *treeElement);

// find element in tree
TreeElement* findElement(BinaryTree *binaryTree, int number);

void deleteBinaryTree(BinaryTree *binaryTree);

// returns true only if our tree is empty
bool isTreeEmpty(BinaryTree *binaryTree);

// returns head of the tree
TreeElement* returnHead(BinaryTree *binaryTree);