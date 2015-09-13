using System;

namespace Spiral
{
    class Program
    {
        // Two dimensional array initialization
        static int[ , ] Initialization(int size)
        {
            Console.WriteLine("Enter your array {0} x {1}:", size, size);
            int[ , ] array = new int[size, size];
            for (int j = 0; j < size; ++j)
            {
                for (int i = 0; i < size; ++i)
                {
                    array[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
            return array;
        }

        // Prints two dimensional array in the form of a spiral
        static void PrintAsSpiral(int[ , ] array)
        {
            int size = array.GetLength(0);
            int direction = 0;
            // 0 - down, 1 - right, 2 - up, 3 left.
            int stepsCounter = 0;
            int startX = size / 2;
            int startY = size / 2;
            int numberOfSteps = 1;
            Console.WriteLine("Your spiral: ");
            while (stepsCounter <= size * size - 1)
            {
                for (int i = 0; i < numberOfSteps; ++i)
                {
                    if (direction % 4 == 0)
                    {
                        Console.Write("{0} ", array[startX, startY + i]);
                    }
                    else if (direction % 4 == 1)
                    {
                        Console.Write("{0} ", array[startX + i, startY]);
                    }
                    else if (direction % 4 == 2)
                    {
                        Console.Write("{0} ", array[startX, startY - i]);
                    }
                    else if (direction % 4 == 3)
                    {
                        Console.Write("{0} ", array[startX - i, startY]);
                    }
                }
                if (direction % 4 == 0)
                {
                    startY = startY + numberOfSteps;
                    stepsCounter += numberOfSteps;
                }
                else if (direction % 4 == 1)
                {
                    startX = startX + numberOfSteps;
                    stepsCounter += numberOfSteps;
                    numberOfSteps++;
                }
                else if (direction % 4 == 2)
                {
                    startY = startY - numberOfSteps;
                    stepsCounter += numberOfSteps;
                }
                else if (direction % 4 == 3)
                {
                    startX = startX - numberOfSteps;
                    stepsCounter += numberOfSteps;
                    numberOfSteps++;
                }
                direction = (direction + 1) % 4;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter your array size: (this integer number shouldn't be divisible by 2)");
            int size = Convert.ToInt32(Console.ReadLine());
            int[ , ] array = Initialization(size);
            PrintAsSpiral(array);
        }
    }
}

// Tested and working. Sizes: 1, 3, 5.
