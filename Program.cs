using System;
using System.Collections.Generic;

namespace LogicalPractices
{
    public class Sorting_Searching_Logics
    {
        static void Main(string[] args)
        {
            string input = "1";
            while (input != "0")
            {
                Console.WriteLine("Welcome :)  Press 1.Shell Sort 2.Bogo Sort 3.Heap Sort 0.Close");
                input = Console.ReadLine();
                if (input == "1")
                {
                    int[] arr = new int[] { 5, -4, 11, 0, 18, 22, 67, 51, 6 };
                    int n;
                    n = arr.Length;
                    Console.WriteLine("Original Array Elements :");
                    show_array_elements(arr);
                    shellSort(arr, n);
                    Console.WriteLine("\nSorted Array Elements :");
                    show_array_elements(arr);
                }
                else if (input == "2")
                {
                    List<int> list = new List<int>() { 2, 1, 3, 0 };
                    Console.WriteLine("Sorting...");
                    Bogo_sort(list, true, 5);
                    Console.WriteLine("Press any key to exit.");
                }

                else if (input == "3")
                {
                    int[] mykeys = new int[] { 2, 5, -4, 11, 0, 18, 22, 67, 51, 6 };

                    //double[] mykeys = new double[] {2.22, 0.5, 2.7, -1.0, 11.2};

                    //string[] mykeys = new string[] {"Red", "White", "Black", "Green", "Orange"};

                    Console.WriteLine("\nOriginal Array Elements :");
                    printArray(mykeys);

                    heapSort(mykeys);

                    Console.WriteLine("\n\nSorted Array Elements :");
                    printArray(mykeys);
                    Console.WriteLine("\n");
                }
            }

        }

        #region Shel Sort

        static void shellSort(int[] arr, int array_size)
        {
            int i, j, inc, temp;
            inc = 3;
            while (inc > 0)
            {
                for (i = 0; i < array_size; i++)
                {
                    j = i;
                    temp = arr[i];
                    while ((j >= inc) && (arr[j - inc] > temp))
                    {
                        arr[j] = arr[j - inc];
                        j = j - inc;
                    }
                    arr[j] = temp;
                }
                if (inc / 2 != 0)
                    inc = inc / 2;
                else if (inc == 1)
                    inc = 0;
                else
                    inc = 1;
            }
        }

        static void show_array_elements(int[] arr)
        {
            foreach (var element in arr)
            {
                Console.Write(element + " ");
            }
            Console.Write("\n");

        }

        #endregion

        #region Bogo Sort

        static void Bogo_sort(List<int> list, bool announce, int delay)
        {
            int iteration = 0;
            while (!IsSorted(list))
            {
                if (announce)
                {
                    Print_Iteration(list, iteration);
                }
                if (delay != 0)
                {
                    System.Threading.Thread.Sleep(Math.Abs(delay));
                }
                list = Remap(list);
                iteration++;
            }

            Print_Iteration(list, iteration);
            Console.WriteLine();
            Console.WriteLine("Bogo_sort completed after {0} iterations.", iteration);
        }

        static void Print_Iteration(List<int> list, int iteration)
        {
            Console.Write("Bogo_sort iteration {0}: ", iteration);
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i]);
                if (i < list.Count)
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine();
        }
        static bool IsSorted(List<int> list)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                if (list[i] > list[i + 1])
                {
                    return false;
                }
            }

            return true;
        }

        static List<int> Remap(List<int> list)
        {
            int temp;
            List<int> newList = new List<int>();
            Random r = new Random();

            while (list.Count > 0)
            {
                temp = (int)r.Next(list.Count);
                newList.Add(list[temp]);
                list.RemoveAt(temp);
            }
            return newList;
        }

        #endregion

        #region HeapSort

        private static void heapSort<T>(T[] array) where T : IComparable<T>
        {
            int heapSize = array.Length;

            buildMaxHeap(array);

            for (int i = heapSize - 1; i >= 1; i--)
            {
                swap(array, i, 0);
                heapSize--;
                sink(array, heapSize, 0);
            }
        }

        private static void buildMaxHeap<T>(T[] array) where T : IComparable<T>
        {
            int heapSize = array.Length;

            for (int i = (heapSize / 2) - 1; i >= 0; i--)
            {
                sink(array, heapSize, i);
            }
        }

        private static void sink<T>(T[] array, int heapSize, int toSinkPos) where T : IComparable<T>
        {
            if (getLeftKidPos(toSinkPos) >= heapSize)
            {
                // No left kid => no kid at all
                return;
            }


            int largestKidPos;
            bool leftIsLargest;

            if (getRightKidPos(toSinkPos) >= heapSize || array[getRightKidPos(toSinkPos)].CompareTo(array[getLeftKidPos(toSinkPos)]) < 0)
            {
                largestKidPos = getLeftKidPos(toSinkPos);
                leftIsLargest = true;
            }
            else
            {
                largestKidPos = getRightKidPos(toSinkPos);
                leftIsLargest = false;
            }



            if (array[largestKidPos].CompareTo(array[toSinkPos]) > 0)
            {
                swap(array, toSinkPos, largestKidPos);

                if (leftIsLargest)
                {
                    sink(array, heapSize, getLeftKidPos(toSinkPos));

                }
                else
                {
                    sink(array, heapSize, getRightKidPos(toSinkPos));
                }
            }

        }

        private static void swap<T>(T[] array, int pos0, int pos1)
        {
            T tmpVal = array[pos0];
            array[pos0] = array[pos1];
            array[pos1] = tmpVal;
        }

        private static int getLeftKidPos(int parentPos)
        {
            return (2 * (parentPos + 1)) - 1;
        }

        private static int getRightKidPos(int parentPos)
        {
            return 2 * (parentPos + 1);
        }

        private static void printArray<T>(T[] array)
        {

            foreach (T t in array)
            {
                Console.Write(' ' + t.ToString() + ' ');
            }

        }
        #endregion
    }
}
