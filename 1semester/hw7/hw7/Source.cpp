#include <iostream>
#include <string>

using namespace std;

void main()
{
	cout << "Enter first (main) string: " << endl;
	string s1;
	cin >> s1;
	cout << "Enter second string: " << endl;
	string s2;
	cin >> s2;
	
	int counterOfOccurences = 0;
	for (int i = 0; i <= s1.length() - s2.length(); ++i)
	{
		for (int s2Counter = i; s2Counter < s2.length() + i; s2Counter++)
		{
			if (s1[s2Counter] != s2[s2Counter - i])
			{
				
				break;
			}
			if (s2Counter == s2.length() + i - 1)
			{
				counterOfOccurences++;
			}
		}
	}
	cout << "The number of occurrences s2 in s1: " << counterOfOccurences << endl;
}