using System;

namespace M1L3HW
{
    internal class Program
    {
        static string alphabet = "abcdefghijklmnopqrstuvwxyz";
        static string lettersToUpper = "aeidhj";
        static void Main(string[] args)
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
            
            //Create an array and fill it by numbers from 1 to 26.
            int[] startArr = new int[arrLength];
            for (int i = 0; i < arrLength; i++)
            {
                startArr[i] = new Random().Next(1,26);
            }

            // Learn how many odd and even nums we have and then create two arrays - one with odd numbers, second - with even.
            int oddCount = 0;
            int evenCount = 0;

            for (int i = 0; i < startArr.Length; i++)
            {
                if(startArr[i] % 2 == 0)
                {
                    evenCount++;
                }
                else
                {
                    oddCount++;
                }
            }

            int[] oddArray = new int[oddCount];
            int[] evenArray = new int[evenCount];

            int evenIndex = 0;
            int oddIndex = 0;
            for (int i = 0; i < startArr.Length; i++)
            {
                if(startArr[i] % 2 == 0)
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

            // Create two char arrays with numbers swapped with alphabet letters.
            char[] oddLetters = new char[oddArray.Length];
            char[] evenLetters = new char[evenArray.Length];

            for (int i = 0; i < oddArray.Length; i++)
            {
                oddLetters[i] = alphabet[oddArray[i] - 1];
                if (lettersToUpper.Contains(oddLetters[i]))
                {
                    oddLetters[i] = Convert.ToChar(oddLetters[i].ToString().ToUpper());
                }
            }

            for (int i = 0; i < evenArray.Length; i++)
            {
                evenLetters[i] = alphabet[evenArray[i] - 1];
                if (lettersToUpper.Contains(evenLetters[i]))
                {
                    evenLetters[i] = Convert.ToChar(evenLetters[i].ToString().ToUpper());
                }
            }

            // Print the arrays and print the most big-lettered array`s name.
            int oddUpper = 0;
            int evenUpper = 0;

            string arrToPrintOdd = "";
            string arrToPrintEven = "";
            for (int i = 0; i < oddLetters.Length; i++)
            {
                if (oddLetters[i].ToString().ToUpper() == oddLetters[i].ToString())
                {
                    oddUpper++;
                }
                arrToPrintOdd += oddLetters[i].ToString() + " ";
            }
            for (int i = 0; i < evenLetters.Length; i++)
            {
                if (evenLetters[i].ToString().ToUpper() == evenLetters[i].ToString())
                {
                    evenUpper++;
                }
                arrToPrintEven += evenLetters[i].ToString() + " ";
            }
            Console.WriteLine($"The odd lettered array:\n{arrToPrintOdd}\n");
            Console.WriteLine($"The even-lettered array:\n{arrToPrintEven}\n");
            string nameOfMostCountOfUpperLetters = evenUpper > oddUpper ? $"The even-lettered array has more upper case letters: {evenUpper} vs {oddUpper}" :
                                                   evenUpper == oddUpper ? $"The arrays have the same number of upper case words: {evenUpper}" : $"The odd-lettered array has more upper case letters: {oddUpper} vs {evenUpper}";
            Console.WriteLine(nameOfMostCountOfUpperLetters);
            Console.ReadKey();
        }
    }
}
