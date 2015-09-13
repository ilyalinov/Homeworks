#include <iostream>

using namespace std;

struct Warrior
{
	int number;
	Warrior *next;
	Warrior *prev;
};

struct List
{
	Warrior *first;
	int size;
	int counter;
};
// создаем список воинов
void createList(List *list, int number)
{
	list->first = new Warrior();
	list->first->number = 1;

	Warrior *temp = list->first;
	for (int i = 2; i <= number; ++i)
	{
		temp->next = new Warrior();
		temp->next->prev = temp;
		temp->next->number = i;
		temp = temp->next;
	}
	temp->next = list->first;
	list->first->prev = temp;
}
// убиваем m воина после заданного, функция возвращает следующего воина после убитого, или (если таких нет) пишет имя победителя.
Warrior* kill(List *list, Warrior *warrior)
{
	if (warrior->next == warrior && warrior->prev == warrior)
	{
		cout << warrior->number << " is a winner" << endl;
		return warrior;
	}
	for (int i = 1; i < list->counter; ++i)
	{
		warrior = warrior->next;
	}
	warrior->next->prev = warrior->prev;
	warrior->prev->next = warrior->next;
	Warrior *temp = warrior->next;
	delete warrior;
	return temp;
}

void main()
{
	List *list = new List();
	int n = 0;
	cout << "Enter quantity of the warriors (> 0): " << endl;
	cin >> n;
	list->size = n;
	cout << "Enter quantity of steps before the death (> 0): " << endl;
	int m = 0;
	cin >> m;
	list->counter = m;
	createList(list, list->size);

	Warrior *temp = kill(list, list->first);
	while (list->size > 1)
	{
		temp = kill(list, temp);
		list->size--;
	}
	delete temp;
	delete list;
}
// tested on: n = {5}, m = {1, 2, 3, 4, 5}
// result: (n, m): 
// (5, 1) -> 5 is a winner
// (5, 2) -> 3 is a winner
// (5, 3) -> 4 is a winner
// (5, 4) -> 1 is a winner
// (5, 5) -> 2 is a winner
// working correct