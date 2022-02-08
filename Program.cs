using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace aocd1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("******** ADVENT OF CODE ********* ");
            Console.WriteLine("******** DAY 1 - PART 1 *********\n\n ");
            var input = GetInputFile("test.txt"); //get input data from file to string array
            var intArray = ConvertStringArrayToIntArray(input); //convert string to int array
            var result = GetIncreaseMeasurements(intArray); //get larger measurements
            Console.WriteLine($"From your input data, there are {result} increased measurements ");
            Console.WriteLine("-------------------------------\n");
            Console.WriteLine("Press a key to process data input for part 2\n\n");
            Console.ReadKey();
            var intArray2 = GetSlidingWindowsThreeMeasurements(intArray); //sum of group of 3 measurements
            var result2 = GetIncreaseMeasurements(intArray2); //get larger meas. on sliding array
            Console.WriteLine($"From your input data, there are {result2} increased sliding measurements ");
            Console.WriteLine("-------------------------------\n");
            Console.ReadKey();
        }

        public static string[] GetInputFile (string path) 
            //get text input data file to string array
        {
            return File.ReadAllLines(path);
        }

        public static int[] ConvertStringArrayToIntArray (string[] array)
            //convert string to int array ready to be processed by conting method
        {
            int[] result = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                result[i]  = int.Parse(array[i]);
            }
            return result;
        }

        public static int GetIncreaseMeasurements (int[] array)
            //counting method to extract measurements larger then previous ones
        {
            int count = 0;
            for (int i = 0; i < array.Length-1; i++)
            {
                if (array[i] < array[i + 1])
                {
                    count++;
                }
            }
            return count;
        }

        public static int[] GetSlidingWindowsThreeMeasurements (int[] array)
        {
            int[] result = new int[array.Length];
            for (int i = 0;i < array.Length-2;i++)
            {
                result[i] = array[i]+array[i+1]+array[i+2];
            }
            return result;
        }
    }
}
