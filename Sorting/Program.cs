using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Sorting");

            var arr = new int[10];
            var rnd = new Random();
            for (var i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(100);
            }
            Console.WriteLine("Eredeti tömb:");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("{0} ", arr[i]);
            }

            Console.WriteLine();

            //BubbleSort(arr);
            //SelectSort(arr);
            //MergeSort(arr);
            QuickSort(arr);

            Console.WriteLine("Rendezett tömb:");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("{0} ", arr[i]);
            }

            Console.WriteLine();
        }
        static void Change(int[] arr, int i, int k)
        {
            int temp = arr[i];
            arr[i] = arr[k];
            arr[k] = temp;
        }

        // ****************************************
        // Bubble sort
        // ****************************************
        public static void BubbleSort(int[] arr)
        {

            for (int end = arr.Length; end > -1; end--)
            {
                for (int i = 1; i < end; i++)
                {
                    if (arr[i - 1] > arr[i])
                    {
                        Change(arr, i - 1, i);
                    }
                }


            }
        }

        // **************************************
        // Select sort
        // **************************************
        public static void SelectSort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int min = arr[i];
                int minIdx = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < min)
                    {
                        min = arr[j];
                        minIdx = j;
                    }
                }
                if (minIdx != i)
                {
                    Change(arr, minIdx, i);
                }

            }
        }

        // ******************************
        // MergeSort
        // ******************************
        public static void MergeSort(int[] arr)
        {
            MergeSort(arr, 0, arr.Length - 1);

        }

        private static void MergeSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int middle = left + (right - left) / 2;
                MergeSort(arr, left, middle);
                MergeSort(arr, middle + 1, right);
                Merge(arr, left, middle, right);
            }

        }

        private static void Merge(int[] arr, int left, int middle, int right)
        {
            //Console.WriteLine($"{left} {middle} {right}");
            int leftArrLen = middle - left + 1;
            int rightArrLen = right - middle;
            int[] leftArr = new int[leftArrLen];
            int[] rightArr = new int[rightArrLen];
            int i = 0;
            int j = 0;

            //bemásoljuk a baloldali ideiglenes tömbe a tömb baloldali részét.
            while (i < leftArrLen)
            {
                leftArr[i] = arr[left + i];
                i++;
            }
            //bemásoljuk a jobboldali ideiglenes tömbe a tömb jobboldali részét.
            while (j < rightArrLen)
            {
                rightArr[j] = arr[middle + 1 + j];
                j++;
            }
            //i-t és j-t elölről kezdjük
            i = 0; j = 0;

            //ez a cél index
            int k = left;

            while (i < leftArrLen && j < rightArrLen)
            {
                if (leftArr[i] <= rightArr[j])
                {
                    arr[k++] = leftArr[i++];
                }
                else
                {
                    arr[k++] = rightArr[j++];
                }
            }
            while (i < leftArrLen)
            {
                arr[k++] = leftArr[i++];
            }
            while (j < rightArrLen)
            {
                arr[k++] = rightArr[j++];
            }

        }

        // ********************************
        // Quick Sort
        // ********************************

        public static void QuickSort(int[] arr)
        {
            QuickSort(arr, 0, arr.Length - 1);
        }
        private static void QuickSort(int[] arr, int left, int right)
        {
            int pivot = arr[left];
            int i = left;
            int j = right;

            while (i <= j)
            {
                //az első pivotnál kisebb bal oldalról
                while (arr[i] < pivot)
                {
                    i++;
                }
                //az első pivotnál nagyobb jobb oldalról
                while (arr[j] > pivot)
                {
                    j--;
                }
                //ha nem értek össze a mutatók, akkor a cserélünk
                if (i <= j)
                {
                    int temp = arr[j];
                    arr[j] = arr[i];
                    arr[i] = temp;
                    i++;
                    j--;
                }
            }
            // ha maradt még a bal oldalon rendezni valónk, akkor rendezzük
            if (left < j)
            {
                QuickSort(arr, left, j);
            }
            //ha maradt még rendezni valónk a jobb oldalon, akkor rendezünk
            if (i < right)
            {
                QuickSort(arr, i, right);
            }

        }
    }
}
