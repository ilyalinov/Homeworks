using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixSort
{
    class Program
    {
        static void Initialization(ref int[ , ] array, int width, int height)
        {
            Console.WriteLine("Enter your array {0} x {1}:", height, width);
            for (int j = 0; j < height; ++j)
            {
                for (int i = 0; i < width; ++i)
                {
                    array[j, i] = Convert.ToInt32(Console.ReadLine());
                }
            }
        }

        static void PrintMatrix(ref int[ , ] array, int width, int height)
        {
            Console.WriteLine("Sorted Matrix");
            for (int i = 0; i < height; ++i)
            {
                for (int j = 0; j < width; ++j)
                {
                    Console.Write("{0} ", array[i, j]);
                }
                Console.Write("\n");
            }
        }

        static void ChangeColumns(ref int[ , ] array, int index1, int index2, int height)
        {
            for (int i = 0; i < height; ++i)
            {
                int temp = array[i, index1];
                array[i, index1] = array[i, index2];
                array[i, index2] = temp;
            }
        }

        static int Partition(ref int[,] array, int leftBorder, int rightBorder, int height)
        {
            int i = leftBorder;
            for (int j = leftBorder; j < rightBorder; ++j)
            {
                if (array[0, j] <= array[0, rightBorder])
                {
                    ChangeColumns(ref array, i, j, height);
                    ++i;
                }
            }
            ChangeColumns(ref array, rightBorder, i, height);
            return i;
        }

        static void Quicksort(ref int[ , ] array, int leftBorder, int rightBorder, int height)
        {
            if (leftBorder < rightBorder)
            {
                int pivotAdress = Partition(ref array, leftBorder, rightBorder, height);
                Quicksort(ref array, leftBorder, pivotAdress - 1, height);
                Quicksort(ref array, pivotAdress + 1, rightBorder, height);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter width and height of your array: ");
            int width = Convert.ToInt32(Console.ReadLine());
            int height = Convert.ToInt32(Console.ReadLine());
            int[ , ] array = new int[height, width];
            Initialization(ref array, width, height);
            Quicksort(ref array, 0, width - 1, height);
            PrintMatrix(ref array, width, height);
        }
    }
}

// Tested and working.