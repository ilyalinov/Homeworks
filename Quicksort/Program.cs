using System;

namespace Quicksort
{
    class Program
    {
        static int Partition(ref int[] array, int leftBorder, int rightBorder)
        {
            int i = leftBorder;
            for (int j = leftBorder; j < rightBorder; ++j)
            {
                if (array[j] <= array[rightBorder])
                {
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    ++i;
                }
            }
            int temp1 = array[rightBorder];
            array[rightBorder] = array[i];
            array[i] = temp1;
            return i;
        }

        static void Quicksort(ref int[] array, int leftBorder, int rightBorder)
        {
            if (leftBorder < rightBorder)
            {
                int pivotAdress = Partition(ref array, leftBorder, rightBorder);
                Quicksort(ref array, leftBorder, pivotAdress - 1);
                Quicksort(ref array, pivotAdress + 1, rightBorder);
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Enter array elements number:\n");
            int elemsNumber = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[elemsNumber];
            Console.Write("Enter array elements:\n");
            for (int i = 0; i < elemsNumber; ++i)
            {
                array[i] = Convert.ToInt32(Console.ReadLine());
            }
            Quicksort(ref array, 0, elemsNumber - 1);
            Console.WriteLine("Sorted array:");
            for (int i = 0; i < elemsNumber; ++i)
            {
                Console.Write(array[i]);
                if (i != elemsNumber - 1)
                {
                    Console.Write(", ");
                }
                else Console.Write(".");
            }
        }
    }
}
