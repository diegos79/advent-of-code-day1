using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace aocd4p1
{
    internal class Program
    {
        /* ------------------------------------------------------------- */
        /* Read input file and convert to array string                   */

        static public string[] ReadFile(string path)
        {
            return File.ReadAllLines(path);
        }
        /* ------------------------------------------------------------- */
        /* Calculate the most common bit in position n                   */
        static public char GetMostCommonBit (string[] array, int position)
        {

            return ' ';
        }
        /* ------------------------------------------------------------- */
        /* Count bit 1 in a single column of the array of bit (array)    */
        static public int CountBitOneInAColumn (string[] array, int column)
        {
            int count = 0;
            foreach (var item in array) //loop for return total of 1 bit in a column 
            {
                if (item[column] == '1')
                {
                    count++;
                }
            }
            return count;
        }

        /* ------------------------------------------------------------- */

        /* ------------------------------------------------------------- */
        /* Count bit 1 in a single column of the array of bit (array)    */
        static public int CountBitOneInAColumn(List<string> array, int column)
        {
            int count = 0;
            foreach (var item in array) //loop for return total of 1 bit in a column 
            {
                if (item[column] == '1')
                {
                    count++;
                }
            }
            return count;
        }

        /* ------------------------------------------------------------- */
        /* Count bit 0 in a single column of the array of bit (list)    */
        static public int CountBitZeroInAColumn(string[] array, int column)
        {
            int count = 0;
            foreach (var item in array) //loop for return total of 1 bit in a column 
            {
                if (item[column] == '0')
                {
                    count++;
                }
            }
            return count;
        }

        /* ------------------------------------------------------------- */

        /* ------------------------------------------------------------- */
        /* Count bit 0 in a single column of the array of bit (list)    */
        static public int CountBitZeroInAColumn(List<string> array, int column)
        {
            int count = 0;
            foreach (var item in array) //loop for return total of 1 bit in a column 
            {
                if (item[column] == '0')
                {
                    count++;
                }
            }
            return count;
        }

        /* ------------------------------------------------------------- */
        /* Get common bit in a column array of string  (array)           */
        static public byte GetCommonBitInAColumn (string[] array, int column)
        {

            if (CountBitOneInAColumn(array, column) > CountBitZeroInAColumn(array, column))
                return 1;
            else
                return 0; 
        }

        /* ------------------------------------------------------------- */

        /* ------------------------------------------------------------- */
        /* Get common bit in a column array of string  (list)           */
        static public byte GetCommonBitInAColumn(List<string> array, int column)
        {

            if (CountBitOneInAColumn(array, column) >= CountBitZeroInAColumn(array, column))
                return 1;
            else
                return 0;
        }

        /* ------------------------------------------------------------- */

        /* Get least common bit in a column array of string  (list)           */
        static public byte GetLeastCommonBitInAColumn(List<string> array, int column)
        {

            if (CountBitOneInAColumn(array, column) < CountBitZeroInAColumn(array, column))
                return 1;
            else
                return 0;
        }

        /* ------------------------------------------------------------- */

        /* ------------------------------------------------------------- */
        /*  Get Gamma Rate                                               */
        static public byte[] GetGammaRate (string[] array, int numberOfBits)
        {
            int cont = 0;
            byte[]res = new byte[numberOfBits];
            for (int column = 0; column < numberOfBits; column++)
            {
                res[cont] = GetCommonBitInAColumn(array, column);
                cont++;
            }
            return res;
        }

        /* ------------------------------------------------------------- */
        /* Print an array of byte                                        */
        static public void PrintByteArray (byte[] array)
        {
            foreach (var item in array)
            {
                Console.Write(item);
            }
        }

        /* ------------------------------------------------------------- */
        /* Invert array of byte for calculate Epsilon Rate               */
        static public byte[] InvertArrayOfByte (byte[] array)
        {
            byte[] res = new byte[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == 1)
                    res[i] = 0;
                else res[i] = 1;
            }
            return res;
        }

        /* ------------------------------------------------------------- */
        /* Get Epsilon by calculate opposite of gamma                    */
        static public byte[] GetEpsilonRate(byte[] gamma) => 
            InvertArrayOfByte(gamma);

        /* ------------------------------------------------------------- */
        /*  Convert byte array to decimal                                */

        static int ConvertByteArrayToDecimal (byte[] array)
        {
            int res = 0;
            int j = 1;
            for (int i = array.Length-1; i >= 0 ; i--)
            {
                res += array[i] * j;
                j *= 2;
            }
            return res;
        }

        /* ------------------------------------------------------------- */
        /* get oxygen rating */
        
        static byte[] GetOxygenRating (List<string> list, int totalColumn)
        {

            for (int column = 0; column < totalColumn; column++)
            {
                var common = GetCommonBitInAColumn(list, column);
                Console.WriteLine("Common bit: " + common + " in position " + column);
                if (common == 1)
                {
                    Console.WriteLine($"Removing 0 from oxygentlist...");
                    RemoveNumbersFromList(list, column, digit: '0');
                }
                else
                {
                    Console.WriteLine($"Removing 1 from oxygentlist...");
                    RemoveNumbersFromList(list, column, digit: '1');
                }
                Console.WriteLine($"\nOxygenlist after removing least common value\n------------------------\n");
                PrintList(list);
                Console.WriteLine("------------------------");
                if (list.Count == 1)
                    break;
            }
            return ConvertListElementToByteArray(list,totalColumn);
        }

        /* ------------------------------------------------------------- */

        /* ------------------------------------------------------------- */
        /* get CO2 rating */

        static byte[] GetCo2Rating(List<string> list, int totalColumn)
        {

            for (int column = 0; column < totalColumn; column++)
            {
                var common = GetLeastCommonBitInAColumn(list, column);
                Console.WriteLine("Common bit: " + common + " in position " + column);
                if (common == 1)
                {
                    Console.WriteLine($"Removing 0 from co2 list...");
                    RemoveNumbersFromList(list, column, digit: '0');
                }
                else
                {
                    Console.WriteLine($"Removing 1 from co2 list...");
                    RemoveNumbersFromList(list, column, digit: '1');
                }
                Console.WriteLine($"\nCO2 list after removing least common value\n------------------------\n");
                PrintList(list);
                Console.WriteLine("------------------------");
                if (list.Count == 1)
                    break;
            }
            return ConvertListElementToByteArray(list, totalColumn);
        }

        /* ------------------------------------------------------------- */
        /* Remove number from list with criteria of position and digit   */
        static public List<string> RemoveNumbersFromList (List<string> list, int position, char digit)
        {
            List<int> indexOfNumbersFound = new List<int>(); //to get position of digit
            for (int i = list.Count-1; i >= 0; i--) //loop for remove numbers from list in position with specific digit 
            {
                if (list[i][position] == digit)
                {
                    list.RemoveAt(i);
                }
            }
            
            return list;
        }
        /* ------------------------------------------------------------- */
        /*   Print element of a list of string                           */
        public static void PrintList (List<string> list)
        {
            Console.WriteLine("\n");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n");
        }

        /* ------------------------------------------------------------- */
        /*  Convert last element of list in a byte array                 */
        public static byte[] ConvertListElementToByteArray(List<string> list, int column)
        {
            byte[] result = new byte[column];
            for (int i = 0; i < column; i++)
            {
                result[i] = byte.Parse(list[0][i].ToString());
            }
            foreach (var item in list)
            {
                Console.Write(item);
            }
            return result;
        }
/* ------------------------------------------------------------- */

/* -------------------------  MAIN ----------------------------  */
static void Main()
        {
            // read input data file and convert to string array
            string[] inputArrayString = ReadFile("input-day3.txt");
            Console.WriteLine("\n\n\n************* ADVENT OF CODE - DAY 3 - PART 1 *************");
            Console.WriteLine("\n\n\n****************** PART 1 *******************");
            Console.WriteLine("\n Press a key when ready to process input data......");
            Console.ReadKey();
            // calculate gamma rate
            var gamma = GetGammaRate(inputArrayString, 12);
            Console.Write($"From your input data, this is Gamma Rate: ");
            PrintByteArray(gamma);
            var epsilon = GetEpsilonRate(gamma);
            Console.WriteLine("");
            Console.Write($"From yout input data, this is Epsilon Rate: "); 
            PrintByteArray(epsilon);
            Console.WriteLine("");
            var gammaDec = ConvertByteArrayToDecimal(gamma);
            var epsilonDec = ConvertByteArrayToDecimal(epsilon);
            Console.WriteLine("\nThis is Gamma converted to decimal = " + gammaDec);
            Console.WriteLine("\nThis is Epsilon converted to decimal = " + epsilonDec);
            var power = gammaDec * epsilonDec;
            Console.WriteLine("\nThis is Power consumption= " + power);
            Console.WriteLine("\n Press a key to continue to part 2......");
            Console.ReadKey();
            /********************  PART 2 *******************************/
            Console.WriteLine("\n\n\n************* ADVENT OF CODE - DAY 3 - PART 2 *************");
            Console.WriteLine("\n\n\n****************** PART 2 *******************");
            Console.WriteLine("\n Press a key when ready to process input data......");
            Console.ReadKey();
            //convert input array of string in list of string
            List<string> oxygenList = new List<string>(inputArrayString);
            //test print oxygentlist
            //Console.WriteLine("\n\nOxygenlist");
            //PrintList(oxygenList);
            var oxygen = GetOxygenRating(oxygenList, 12);
            var oxygenDec = ConvertByteArrayToDecimal(oxygen);
            Console.WriteLine("Oxygen rating = " + oxygenDec);
            //------- Co2 -------- //
            //convert input array of string in list of string
            List<string> co2list = new List<string>(inputArrayString);
            //test print co2 list
            Console.WriteLine("\n\nCO2 list");
            PrintList(co2list);
            var co2 = GetCo2Rating(co2list, 12);
            var co2Dec = ConvertByteArrayToDecimal(co2);
            Console.WriteLine("\n\nCO2 rating = " + co2Dec);
            var lifeSupportRating = oxygenDec * co2Dec;
            Console.WriteLine("\nOxygen rating = " + oxygenDec);
            Console.WriteLine($"\nLife Support Rating = {lifeSupportRating}");
            Console.ReadKey();
        }
    }


}
