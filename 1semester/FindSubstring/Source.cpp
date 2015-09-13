#include <iostream>
#include <vector>
#include <string>
#include <fstream>

using namespace std;

int hashFunction(string const &buffer)
{
	int result = 0;
	for (unsigned i = 0; i < buffer.length(); ++i)
	{
		result = result + static_cast<int>(buffer[i]);
	}
	return result;
}

string getfirstString(ifstream &file, unsigned const int size)
{
	string result;
	for (unsigned int i = 0; i < size; ++i)
	{
		char temp = ' ';
		file.get(temp);
		result += temp;
	}
	return result;
}

string addLastAndDeleteFirst(string buffer, char const symbol)
{
	string result;
	for (unsigned i = 1; i < buffer.size(); ++i)
	{
		result += buffer[i];
	}
	result += symbol;
	return result;
}

bool compare(string buffer1, string buffer2)
{
	if (buffer1.size() != buffer2.size())
	{
		return false;
	}
	else
	{
		for (unsigned i = 0; i < buffer1.size(); ++i)
		{
			if (buffer1[i] != buffer2[i])
			{
				return false;
			}
		}
	}
	return true;
}

void main()
{
	ifstream file("Text.txt", ios::in);
	cout << "Enter your pattern: " << endl;
	string pattern;
	cin >> pattern;
	string buffer = getfirstString(file, pattern.size());
	char prevSymbol = buffer[0];
	int hashValue = hashFunction(buffer);
	int hashPattern = hashFunction(pattern);
	int position = 0;
	while (!file.eof())
	{
		if (hashValue == hashPattern)
		{
			if (compare(buffer, pattern))
			{
				cout << "Congruence found at position: ";
				cout << position << endl;
				return;
			}
		}
		char nextSymbol = '\0'; 
		file.get(nextSymbol);
		hashValue = hashValue - static_cast<int>(prevSymbol) + static_cast<int>(nextSymbol);
		buffer = addLastAndDeleteFirst(buffer, nextSymbol);
		prevSymbol = buffer[0];
		position++;
	}

	file.close();
}
// Tested and working
// Tests: 
// "International" result: 18
// "on" result: 4
// "science" result: 1468
// Firt position is numbered by zero! 