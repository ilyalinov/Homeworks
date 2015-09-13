#include <iostream>

using namespace std;

struct Point
{
	int x;
	int y;
};

//список
struct List
{
	ListElement *head;
};

struct ListElement
{
	int value;
	ListElement *next;
	List *list;
};

void main()
{
	////Point point; 
	//Point point {10, 20};
	//point.x = 21;
	//point.y = 32;
	//cout << point.x << " " << point.y << endl;

	//Point *point1 = new Point();
	//point1->x = 10;
	//point1->y = 20;

	//delete point1;

	ListElement *listElement = new ListElement();
	listElement->value = 1;
	listElement->next = nullptr;

	ListElement *listElement2 = new ListElement();
	listElement2->value = 2;
	listElement->next = listElement2;
	

}