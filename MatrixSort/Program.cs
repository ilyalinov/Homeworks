using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixSort
{
    class Program
    {
        // Two dimensional array initialization
        static void Initialization(int[ , ] array)
        {
            int width = array.GetLength(1);
            int height = array.GetLength(0);
            Console.WriteLine("Enter your array {0} x {1}:", height, width);
            for (int j = 0; j < height; ++j)
            {
                for (int i = 0; i < width; ++i)
                {
                    array[j, i] = Convert.ToInt32(Console.ReadLine());
                }
            }
        }

        // Prints matrix to console
        static void PrintMatrix(int[ , ] array)
        {
            int height = array.GetLength(0);
            int width = array.GetLength(1);
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

        // Swaps two given matrix columns
        static void ChangeColumns(ref int[ , ] array, int index1, int index2, int height)
        {
            for (int i = 0; i < height; ++i)
            {
                int temp = array[i, index1];
                array[i, index1] = array[i, index2];
                array[i, index2] = temp;
            }
        }

        // quicksort separation of the array on two arrays
        static int Partition(int[,] array, int leftBorder, int rightBorder)
        {
            int height = array.GetLength(0);
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

        // Quicksort for first elems in the matrix columns
        static void Quicksort(int[ , ] array, int leftBorder, int rightBorder)
        {
            if (leftBorder < rightBorder)
            {
                int pivotAdress = Partition(array, leftBorder, rightBorder);
                Quicksort(array, leftBorder, pivotAdress - 1);
                Quicksort(array, pivotAdress + 1, rightBorder);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter width and height of your array: ");
            int width = Convert.ToInt32(Console.ReadLine());
            int height = Convert.ToInt32(Console.ReadLine());
            int[ , ] array = new int[height, width];
            Initialization(array);
            Quicksort(array, 0, width - 1);
            PrintMatrix(array);
        }
    }
}

// Tested and working.