#include <iostream>

using namespace std;

struct ComplexNumber
{
	int re;
	int im;
};

void main()
{
	//auto number = 1; // compiler decides type

	ComplexNumber *number = new ComplexNumber();
	number->re = 5; // (*number.re) = 5; // the same
	number->im = 6;
}