using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{

    class InsertionSort
    {
        /// <summary>
        /// Sorts an array using insertion method. Returns a new Array.
        /// </summary>
        /// <param name="source">Original array.</param>
        /// <returns></returns>
        public static int[] Sort(int[] source)
        {
            var result = new int[source.Length];
            for (int i = 0; i < source.Length; i++)
            {
                result[i] = source[i];
            }
            for (int i = 1; i < source.Length; i++)
            {
                int temp = result[i];
                int count = 0;
                for (int j = i - 1; j >= 0 && count != 1;) // 2 5 3 8 1
                {
                    if (temp < result[j])
                    {
                        result[j + 1] = result[j];
                        j--;
                        result[j + 1] = temp;
                    }
                    else count = 1;
                }
            }
            return result;
        }
    }

    class BubbleSort
    {
        /// <summary>
        /// Sorts an array using Bubble method. Returns a new Array.
        /// </summary>
        /// <param name="source">Original array.</param>
        /// <returns></returns>
        public static int[] Sort(int[] source)
        {
            var result = new int[source.Length];
            for (int i = 0; i < source.Length; i++)
            {
                result[i] = source[i];
            }

            int temp;
            for (int i = 0; i < result.Length; i++)
            {
                for (int j = 0; j < result.Length - 1; j++)
                {
                    if (result[j] > result[j + 1])
                    { // 5 2
                        temp = result[j];
                        result[j] = result[j + 1];
                        result[j + 1] = temp;
                    }
                }
            }

            return result;
        }
    }

    class SelectionSort
    {
        /// <summary>
        /// Sorts an array using Selection method. Returns a new Array.
        /// </summary>
        /// <param name="source">Original array.</param>
        /// <returns></returns>
        public static int[] Sort(int[] source)
        {
            var result = new int[source.Length];
            for (int i = 0; i < source.Length; i++)
            {
                result[i] = source[i];
            }

            int temp;
            int small_sub;
            for (int i = 0; i < result.Length; i++)
            {
                small_sub = i;
                for (int j = i + 1; j < result.Length; j++)
                {    // 0 1 2 3 4
                    if (result[j] < result[small_sub])
                    {                    // 7 8 2 5 9
                        small_sub = j;
                    }
                }
                temp = result[i];
                result[i] = result[small_sub];
                result[small_sub] = temp;
            }

            return result;
        }
    }
}
