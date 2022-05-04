using System;

namespace M1L3HW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create an array and fill it by numbers from 1 to 26.
            int[] startArr = ArrayCreateAndFill();

            // Learn how many odd and even nums we have and then create two arrays - one with odd numbers, second - with even.
            int oddCount = 0;
            int evenCount = 0;
            (oddCount, evenCount) = ArrayLength(startArr, oddCount, evenCount);

            int[] oddArray = new int[oddCount];
            int[] evenArray = new int[evenCount];

            // Fill the char arrays with corresponding symbols.
            (oddArray, evenArray) = CreateAndFillOddEvenArrays(startArr, oddArray, evenArray);

            // Create two char arrays with numbers swapped with alphabet letters.
            (char[] oddLetters, char[] evenLetters) = CreateAndFillCharArrays(oddArray, evenArray);

            int oddUpper = 0;
            int evenUpper = 0;
            string arrToPrintOdd = "";
            string arrToPrintEven = "";

            // Count how many uppercase letters in both arrays and push the array elements to the string.
            CountUpperCaseLettersAndArrayToString(oddLetters, ref arrToPrintOdd, ref oddUpper);
            CountUpperCaseLettersAndArrayToString(evenLetters, ref arrToPrintEven, ref evenUpper);

            // Printing the counts of uppercased letters and elements of both arrays.
            Console.WriteLine($"The odd lettered array:\n{arrToPrintOdd}\n");
            Console.WriteLine($"The even-lettered array:\n{arrToPrintEven}\n");
            string nameOfMostCountOfUpperLetters = evenUpper > oddUpper ? $"The even-lettered array has more upper case letters: {evenUpper} vs {oddUpper}" :
                                                   evenUpper == oddUpper ? $"The arrays have the same number of upper case words: {evenUpper}" : $"The odd-lettered array has more upper case letters: {oddUpper} vs {evenUpper}";
            Console.WriteLine(nameOfMostCountOfUpperLetters);
            Console.ReadKey();
        }

        /// <summary>
        /// Letters that must be in Upper case after convertation.
        /// </summary>
        static string lettersToUpper = "aeidhj";

        /// <summary>
        /// Method that creates an array with length inputted by user and fill it by numbers in range 1-26. 
        /// </summary>
        /// <returns>The filled array.</returns>
        static int[] ArrayCreateAndFill()
        {
            Console.WriteLine("Add an array length");
            // Catch an exception while user inputs not a number or number that < 0.
            int arrLength = -1;
            while (arrLength < 0)
            {
                try
                {
                    arrLength = Convert.ToInt32(Console.ReadLine());
                    if (arrLength < 0)
                    {
                        Console.WriteLine("A length must be > 0");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Add a number, not letters");
                }
            }

            int[] startArr = new int[arrLength];
            for (int i = 0; i < arrLength; i++)
            {
                startArr[i] = new Random().Next(1, 26);
            }
            return startArr;
        }

        /// <summary>
        /// Method that counts length of odd and even numbers from the start array.
        /// </summary>
        /// <param name="startArr"></param>
        /// <param name="evenCount"></param>
        /// <param name="oddCount"></param>
        /// <returns>The tuple of numners of odd and even numbers of the array.</returns>
        static (int oddcnt, int evencnt) ArrayLength(int[] startArr, int evenCount, int oddCount)
        {
            for (int i = 0; i < startArr.Length; i++)
            {
                if (startArr[i] % 2 == 0)
                {
                    evenCount++;
                }
                else
                {
                    oddCount++;
                }
            }
            return (oddcnt: oddCount, evencnt: evenCount);
        }

        /// <summary>
        /// Method that creates two arrays and fill them one with odd, another - with even numbers from the start array.
        /// </summary>
        /// <param name="startArr"></param>
        /// <param name="oddArray"></param>
        /// <param name="evenArray"></param>
        /// <returns>The tuple of the odd and even number arrays.</returns>
        static (int[] oddArray, int[] evenArray) CreateAndFillOddEvenArrays(int[] startArr, int[] oddArray, int[] evenArray)
        {
            int evenIndex = 0;
            int oddIndex = 0;
            for (int i = 0; i < startArr.Length; i++)
            {
                if (startArr[i] % 2 == 0)
                {
                    evenArray[evenIndex] = startArr[i];
                    evenIndex++;
                }
                else
                {
                    oddArray[oddIndex] = startArr[i];
                    oddIndex++;
                }
            }
            return (oddArray: oddArray, evenArray: evenArray);
        }

        /// <summary>
        /// Method creates two char arrays and fill them by corresponding to numbers letters of the english alphabet.
        /// </summary>
        /// <param name="oddArray"></param>
        /// <param name="evenArray"></param>
        /// <returns>The tuple of two arrays, which letters correspond to the number of element of the corresponding integer array.</returns>
        static (char[] oddLetters, char[] evenLetters) CreateAndFillCharArrays(int[] oddArray, int[] evenArray)
        {
            // Create two char arrays with numbers swapped with alphabet letters.
            char[] oddLetters = new char[oddArray.Length];
            char[] evenLetters = new char[evenArray.Length];

            ChangeIntArraysToChar(ref oddArray, ref oddLetters);
            ChangeIntArraysToChar(ref evenArray,ref evenLetters);
            return (oddLetters: oddLetters, evenLetters: evenLetters);
        }

        /// <summary>
        /// Method that helps method called 'CreateAndFillCharArrays' to fill arrays by corresponding letters.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="letters"></param>
        static void ChangeIntArraysToChar(ref int[] array, ref char[] letters)
        {
            for (int i = 0; i < array.Length; i++)
            {
                letters[i] = (char)('a' + (array[i] - 1));
                if (lettersToUpper.Contains(letters[i]))
                {
                    letters[i] = Convert.ToChar(letters[i].ToString().ToUpper());
                }
            }
        }

        /// <summary>
        /// Method that counts how many uppercase letters in array and push the array`s elements to the string.
        /// </summary>
        /// <param name="letters"></param>
        /// <param name="arrToPrint"></param>
        /// <param name="upper"></param>
        static void CountUpperCaseLettersAndArrayToString(char[] letters, ref string arrToPrint, ref int upper)
        {
            for (int i = 0; i < letters.Length; i++)
            {
                if (letters[i].ToString().ToUpper() == letters[i].ToString())
                {
                    upper++;
                }
                arrToPrint += letters[i].ToString() + " ";
            }
        }

    }
}
