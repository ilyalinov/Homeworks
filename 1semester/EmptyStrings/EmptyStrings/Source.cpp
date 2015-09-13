#include <fstream>
#include <iostream>
#include <string>

using namespace std;

void main()
{
	ifstream file("Text.txt", ios::in);
	if (!file.is_open())
	{
		cout << "Create file 'Text.txt' " << endl;
		return;
	}
	int counterOfNotEmptyStrings = 0;
	while (!file.eof())
	{
		string buffer;
		getline(file, buffer);
		for (int i = 0; i < buffer.size(); ++i)
		{ 
			if (buffer[i] != '\t' && buffer[i] != ' ' && buffer[i] != '\n')
			{
				++counterOfNotEmptyStrings;
				break;
			}
		}
	}
	file.close();
	cout << "Quantity of not empty strings: " << endl;
	cout << counterOfNotEmptyStrings << endl;
}