#include <iostream>
#include <fstream>
#include <vector>
#include <string>

using namespace std;

void main()
{
	ifstream file("../Text.txt", ios::in);
	if (!file.is_open())
	{
		cout << "file not found" << endl;
		return;
	}

	vector<string> data;

	while (!file.eof())
	{
		string buffer;
		file >> buffer;
		data.push_back(buffer);
	}

	file.close();

	for (auto const &line : data)
	{
		cout << line << endl;
	}

	/*
	ofstream f;
	f.open("first.txt", ios_base::app);
	f << "Hello world!" << endl;
	cout << f.eof() << endl;
	*/
}