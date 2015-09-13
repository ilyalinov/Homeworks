#include <iostream>
#include <fstream>
#include <string>
#include <vector>

using namespace std;
// структура элементов списка
struct ListElement
{
	string name;
	string number;
};
// добавление элемента в список
void addElement(vector<ListElement> &list, string const &name, string number)
{
	list.resize(list.size() + 1);
	list[list.size() - 1].name = name;
	list[list.size() - 1].number = number;
}
// поиск имени по номеру
string findNameViaNumber(vector<ListElement> &list, string number)
{
	for (unsigned i = 0; i < list.size(); ++i)
	{
		if (list[i].number == number)
		{
			return list[i].name;
		}
	}
	return "No such name in the list";
}
// поиск номера по имени
string findNumberViaName(vector<ListElement> &list, string name)
{
	for (unsigned i = 0; i < list.size(); ++i)
	{
		if (list[i].name == name)
		{
			return list[i].number;
		}
	}
	return "No such number in the list";
}
// чтение данных из файла
void readFile(fstream &file, vector<ListElement> &list)
{
	while (!file.eof())
	{
		string name;
		file >> name;
		string number;
		file >> number;
		if (!name.empty() && !number.empty())
		{
			addElement(list, name, number);
		}
	}
	file.close();
}
// запись данных из списка в файл
void dataToFile(fstream &file, vector<ListElement> &list)
{
	file.open("Book.txt", ios::out);
	for (unsigned i = 0; i < list.size(); ++i)
	{
		file << list[i].name << " " << list[i].number << endl;
	}
	file.close();
}

void main()
{
	vector<ListElement> list;
	fstream file("Book.txt", ios::in);

	if (!file.is_open())
	{
		cout << "File not found" << endl;
	}
	else
	{
		readFile(file, list);
	}

	while (true)
	{
		string name;
		string number;
		int k = 0;
		cout << "0 - Exit;" << endl;
		cout << "1 - Add name and number;" << endl;
		cout << "2 - Find number via name;" << endl;
		cout << "3 - Find name via number;" << endl;
		cout << "4 - Save data to file;" << endl;
		cin >> k;
		switch (k)
		{
			case 0:
				return;
			case 1:
				cout << "Enter you name and number: " << endl;
				cin >> name;
				cin >> number;
				addElement(list, name, number);
				break;
			case 2:
				cout << "Enter your name: " << endl;
				cin >> name;
				cout << "Phone: " << findNumberViaName(list, name) << endl;
				break;
			case 3:
				cout << "Enter your number: " << endl;
				cin >> number;
				cout << "Name: " << findNameViaNumber(list, number) << endl;
				break;
			case 4:
				dataToFile(file, list);
				cout << "Done" << endl;
				break;
			default:
				cout << "wrong number" << endl;
				continue;
		}
	}
}
// tested on: FIle not found, exit, adding elements, searching by number/name, saving data to file;
// working correct.