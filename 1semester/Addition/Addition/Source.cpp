#include <iostream>
#include <vector>
#include <cmath>

using namespace std;

// �������� �������� �����
void add(vector<int> &array1, vector<int> &array2)
{
	int transfer = 0;
	for (unsigned i = 1; i <= array1.size(); ++i)
	{
		array1[array1.size() - i] = array1[array1.size() - i] + array2[array2.size() - i] + transfer;
		if (array1[array1.size() - i] >= 2)
		{
			transfer = 1;
		}
		else
		{
			transfer = 0;
		}
		array1[array1.size() - i] = array1[array1.size() - i] % 2;
 	}
}

// �������������� �������� ����� � ��������� � ���� �������
void reverse(vector<int> &array)
{
	for (unsigned i = 0; i < array.size(); ++i)
	{
		array[i] = (array[i] + 1) % 2;
	}
	for (unsigned i = array.size() - 1; i >= 0; --i)
	{
		if (array[i] == 0)
		{
			array[i] = 1;
			for (unsigned j = i + 1; j < array.size(); j++)
			{
				array[j] = 0;
			}
			break;
		}
	}
}

// ������� ����������� ����� � ��������
void decToBin(int number, vector<int> &array)
{
	if (number < 0)
	{
		decToBin(-number, array);
		reverse(array);
		return;
	}
	int temp = number;
	unsigned counter = array.size() - 1;
	while (temp > 0)
	{
		if (temp % 2 == 0)
		{
			array[counter] = 0;
		}
		else
		{
			array[counter] = 1;
		}
		temp = temp / 2;
		--counter;
	}
	for (unsigned i = 0; i < counter; ++i)
	{
		array[i] = 0;
	}
}

// ������� ��������� ����� � ����������
int binToDec(vector<int> &array)
{
	int temp = 0;
	for (unsigned i = 0; i < array.size(); ++i)
	{
		if (array[i] == 1)
		{
			temp = temp + static_cast<int>(pow(2, array.size() - i - 1));
		}
	}
	return temp;
}

void main()
{
	setlocale(LC_ALL, "Russian");
	int const size = 32;
	int num1 = 0;
	int num2 = 0;
	cout << "������� ������ �����: " << endl;
	cin >> num1;
	cout << "������� ������ �����: " << endl;
	cin >> num2;
	vector<int> number1, number2;
	number1.resize(size);
	number2.resize(size);
	decToBin(num1, number1);
	cout << "������ ����� � �������� �������: " << endl;
	for (auto const number : number1)
	{
		cout << number;
	}
	cout << endl;
	decToBin(num2, number2);
	cout << "������ ����� � �������� �������: " << endl;
	for (auto const number : number2)
	{
		cout << number;
	}
	cout << endl;
	add(number1, number2);
	cout << "��������� � �������� �������: " << endl;
	for (auto const number : number1)
	{
		cout << number;
	}
	cout << endl;
	cout << "��������� � ���������� �������: " << endl;
	cout << binToDec(number1) << endl;
}