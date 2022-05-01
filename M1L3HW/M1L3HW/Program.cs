using System;

namespace M1L3HW
{
    internal class Program
    {
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

            Console.ReadKey();
        }
    }
}
