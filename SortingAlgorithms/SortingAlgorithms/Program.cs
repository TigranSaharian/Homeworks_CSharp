using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class Program
    {
        public static void Main(string[] args)
        {
            #region --get the size of array and fill with random numbers
            Console.Write("Please enter the size of an array that you want to sort: ");
            if (!int.TryParse(Console.ReadLine(), out int size))
            {
                Console.Write("Entered value is not a number.");
                return;
            }

            int[] myArray = new int[size];
            var rnd = new Random();
            for (int i = 0; i < myArray.Length; i++)
            {
                myArray[i] = rnd.Next((int)Math.Pow(10, size.ToString().Length + 1));
            }
            #endregion

            #region --prompt for algorithm options
            Console.Write(
                "Select which algorithm you want to perform:\n" +
                "1. Insertion sort\n" +
                "2. Bubble sort\n" +
                "3. Quick sort\n" +
                "4. Heap sort\n" +
                "5. Merge sort\n" +
                "6. All\n");
            // 1-3    | 1 2 3
            // 1,2,5  | 1 2 5
            // 1      | 1
            var algorithm_options = Console.ReadLine();
            #endregion

            var result = new int[size];
            var fastest_time = 0;
            var fastest_algorithm = 0;
            int milliseconds = 0;
            long totalMemory = 0;
            int generationId = 0;

            // check if the entered value is a single number. try to convert 
            // as a single number. if not successful then check other options...
            if (int.TryParse(algorithm_options, out int single_algorithm))
            {
                if (!isAlgorithmIndexValid(single_algorithm, true))
                {
                    Console.Write("Entered number must be between 1 and 6.");
                    return;
                }
                if (single_algorithm != 6)
                {
                    result = Sort(myArray, single_algorithm, out milliseconds, out generationId, out totalMemory);
                }
                else // == 6
                {
                    for (int i = 1; i < 5; i++)
                    {
                        var tmp = Sort(myArray, i, out milliseconds, out generationId, out totalMemory);
                        if (fastest_time == 0 ||
                            fastest_time > milliseconds)
                        {
                            fastest_algorithm = i;
                            fastest_time = milliseconds;
                            result = tmp;
                        }
                    }
                }
            }

            else if (algorithm_options.IndexOf('-') == 1)
            {
                var ranged_values = algorithm_options.Split('-');

                #region --conversion and validation
                if (!int.TryParse(ranged_values[0], out int range_start))
                {
                    Console.Write("Entered range start value is not a number.");
                    return;
                }
                else if (!isAlgorithmIndexValid(range_start, false))
                {
                    Console.Write("Entered range start value is out of range.");
                    return;
                }

                if (!int.TryParse(ranged_values[1], out int range_end))
                {
                    Console.Write("Entered range end value is not a number.");
                    return;
                }
                else if (!isAlgorithmIndexValid(range_end, false))
                {
                    Console.Write("Entered range end value is out of range.");
                    return;
                }


                if (range_end < range_start)
                {
                    Console.Write("Entered range start value must be greater than  the range end value.");
                    return;
                }
                #endregion

                var range = new int[range_end - range_start + 1]; // 2 3 4      3 4 5 6
                for (int i = range_start; i <= range_end; i++)
                {
                    range[i - range_start] = i;
                }
                for (int i = 0; i < range.Length; i++)
                {
                    var tmp = Sort(myArray, range[i], out milliseconds, out generationId, out totalMemory);
                    if (fastest_time == 0 ||
                        fastest_time > milliseconds)
                    {
                        fastest_algorithm = i;
                        fastest_time = milliseconds;
                        result = tmp;
                    }
                }
            }

            else if (algorithm_options.Contains(','))
            {
                var values = algorithm_options.Split(',');
                var range = new int[values.Length];
                for (int i = 0; i < values.Length; i++)
                {
                    if (!int.TryParse(values[i], out int random_number))
                    {
                        Console.Write("Entered random algorithm index {0} is not a number.", values[i]);
                        return;
                    }
                    range[i] = random_number;
                }

                for (int i = 0; i < range.Length; i++)
                {
                    var tmp = Sort(myArray, range[i], out milliseconds, out generationId, out totalMemory);
                    if (fastest_time == 0)
                    {
                        fastest_algorithm = i;
                        fastest_time = milliseconds;
                        result = tmp;
                    }
                    else if (fastest_time > milliseconds)
                    {
                        fastest_algorithm = i;
                        fastest_time = milliseconds;
                        result = tmp;
                    }
                }
            }

            else
            {
                Console.Write("Unknown format");
                return;
            }

            Console.WriteLine("\nSorted Array Statistics: ");
            Console.WriteLine("Running time: {0} milliseconds", fastest_time);
            Console.WriteLine("Memory usage: {0} bytes", totalMemory);
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < result.Length; i++)
            {
                Console.Write(result[i] + " ");
            }

            Console.ReadLine();
        }

        static bool isAlgorithmIndexValid(int algorithmInde, bool includeAll)
        {
            return algorithmInde >= 1 && algorithmInde <= (includeAll ? 6 : 5);
        }
        static int[] Sort(int[] array, int algorithmIndex, out int milliseconds, out int generationId, out long totalMemory)
        {
            generationId = 0; // this is for other options that are not done yet
            totalMemory = 0; // this is for other options that are not done yet

            var sw = new Stopwatch();
            sw.Start();
            var sortedArray = new int[array.Length];
            switch (algorithmIndex)
            {
                case 1:
                    sortedArray = processWithMemoryCheck(InsertionSort.Sort, array, out generationId, out totalMemory);
                    break;
                case 2:
                    sortedArray = processWithMemoryCheck(BubbleSort.Sort, array, out generationId, out totalMemory);
                    break;
                case 3:
                    // Quick sort: NOT IMPLEMENTED
                    break;
                case 4:
                    // Heap sort: NOT IMPLEMENTED
                    break;
                case 5:
                    // Merge sort: NOT IMPLEMENTED
                    break;
                default:
                    break;
            }
            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            milliseconds =
                ts.Hours * 60 * 60 * 60 + // hours * 60 == minutes (* 60 == seconds (* 60 == miliseconds))
                ts.Minutes * 60 * 60 +
                ts.Seconds * 60 +
                ts.Milliseconds;
            if (algorithmIndex > 2)
                milliseconds = -1; // NOT IMPLEMENTED
            return sortedArray;
        }

        /*
            https://docs.microsoft.com/en-us/dotnet/standard/garbage-collection/fundamentals
            The heap is organized into generations so it can handle long-lived and short-lived objects. 
            Garbage collection primarily occurs with the reclamation of short-lived objects that typically 
            occupy only a small part of the heap. There are three generations of objects on the heap:
            

            Generation 0. 
                This is the youngest generation and contains short-lived objects. An example of a short-lived 
                object is a temporary variable. Garbage collection occurs most frequently in this generation.
            
                Newly allocated objects form a new generation of objects and are implicitly generation 0 
                collections, unless they are large objects, in which case they go on the large object heap 
                in a generation 2 collection.
            
                Most objects are reclaimed for garbage collection in generation 0 and do not survive to the 
                next generation.
            

            Generation 1. 
                This generation contains short-lived objects and serves as a buffer between short-lived 
                objects and long-lived objects.
            

            Generation 2. 
                This generation contains long-lived objects. An example of a long-lived object is an object 
                in a server application that contains static data that is live for the duration of the process.
            

            Garbage collections occur on specific generations as conditions warrant. Collecting a generation 
            means collecting objects in that generation and all its younger generations. A generation 2 garbage 
            collection is also known as a full garbage collection, because it reclaims all objects in all 
            generations (that is, all objects in the managed heap).
         */

        static int[] processWithMemoryCheck(
            Func<int[], int[]> action,
            int[] array,
            out int generationId,
            out long totalMemoty)
        {
            // we are interested in Generation 2 memory size because we are 
            // dealing with static objects. these objects are long-lived objects.

            var result = action(array);
            GC.Collect(2);
            generationId = GC.GetGeneration(action);
            totalMemoty = GC.GetTotalMemory(false);
            return result;
        }
    }
}
