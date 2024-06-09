using System;
using System.ComponentModel.Design;

namespace ExampleNamespace
{
    public class Program
    {
        public static void Main()
        {

            //Task1

            Console.WriteLine("Write number: ");
            long baseNumber = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Write exponent: ");
            long exponent = Convert.ToInt64(Console.ReadLine());
            long result = Exponentiate(baseNumber, exponent);
            Console.WriteLine($"Result: {result}");

            //Task2

            Console.WriteLine("write 1st number: ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("write 2st number: ");
            int num2 = Convert.ToInt32(Console.ReadLine());
            int result = SumInrange(num1, num2);
            Console.WriteLine($"range sum:{result}");

            //Task3

            Console.WriteLine("Enter the beginning of the range to search for perfect numbers:");
            int start = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the end of the range to search for perfect numbers:");
            int end = Convert.ToInt32(Console.ReadLine());
            int[] perfectNums = FindNums(start, end);
            if (perfectNums.Length > 0)
            {
                Console.WriteLine("Perfect numbers in the range:");
                for (int i = 0; i < perfectNums.Length; i++)
                {
                    Console.WriteLine(perfectNums[i]);
                }
            }
            else
            {
                Console.WriteLine("No perfect numbers in the range.");
            }

            //Task4

            string[] suits = { "Spades", "Hearts", "Diamonds", "Clubs" };
            string[] ranks = { "Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" };

            string[] cards = new string[ranks.Length * suits.Length];
            int index = 0;

            foreach (string suit in suits)
            {
                foreach (string rank in ranks)
                {
                    cards[index++] = $"{rank} {suit}";
                }
            }

            Console.Write("Enter the serial number of the card (from 1 to 52): ");
            string input = Console.ReadLine();
            int cardNumber = Convert.ToInt32(input);
            DisplayCard(cards, cardNumber);

            //Task5

            Console.Write("Enter a six-digit number: ");
            var input = Convert.ToString(Console.ReadLine());   //string для того що считати кількість символів
            if (input.Length == 6)
            {
                int number;
                if (int.TryParse(input, out number))
                {
                    int difference = IsLuckyNumber(input);

                    if (difference == 0)
                    {
                        Console.WriteLine("The number is lucky");
                    }
                    else
                    {
                        Console.WriteLine($"The number is not lucky. Difference: {difference}");
                    }
                }

            }
            else
            {
                Console.WriteLine("Please enter a valid six-digit number.");

            }





        }


        //TasK1
        public static long Exponentiate(long baseNumber, long exponent)
        {
            if (baseNumber == 0 && exponent == 0)
            {

                Console.WriteLine("0 - indeterminate form.");
            }

            long result = 1; //Якщо result = 0, результат виходить 0,бо * 0 = 0. 1 - нейтральне число, і здається не має бути помилки 
            for (long i = 0; i < exponent; i++)
            {
                result *= baseNumber;
            }
            return result;
        }


        //Task2
        public static int SumInrange(int start, int end)
        {
            int sum = 0;
            int min = 0;
            int max = 0;
            int result = 0;
            if (start < end)
            {
                min = start;
                max = end;
            }
            else if (start > end)
            {
                max = start;
                min = end;
            }
            for (int i = min; i <= max; i++)
            {
                sum += i;
                result = sum - (min + max);
            }
            return result;
        }


        //Task3
        public static int[] FindNums(int start, int end)
        {
            int count = 0;
            for (int number = start; number <= end; number++)
            {
                if (IsPerfect(number))
                {
                    count++;
                }
            }
            Console.WriteLine($"The number of perfect numbers in the range: \t{count}");

            int[] perfectNums = new int[count];
            int index = 0;

            for (int number = start; number <= end; number++)
            {
                if (IsPerfect(number))
                {
                    perfectNums[index] = number;
                    index++;
                }
            }
            return perfectNums;

        }

        public static bool IsPerfect(int number)
        {
            int sum = 0;
            for (int j = 1; j <= number / 2; j++)                    //1 - дільник для будь-якого числа// ділити на 2 щоб отримати кінцевий дільник 
            {
                if (number % j == 0)
                {
                    sum += j;
                }
            }
            return sum == number;

        }

        //Task4
        static void DisplayCard(string[] cards, int cardNumber)
        {
            if (cardNumber >= 1 && cardNumber <= cards.Length)
            {
                Console.WriteLine("Your card: " + cards[cardNumber - 1]);
            }
            else
            {
                Console.WriteLine("Incorrect serial number of the card.");
            }
        }

        //Task5
        static int IsLuckyNumber(string input)
        {
            if (input.Length != 6 || !int.TryParse(input, out int number))
            {
                return -1;
            }

            int firstHalf = number / 1000;
            int secondHalf = number % 1000;

            int sumFirstHalf = SumOfDigits(firstHalf);
            int sumSecondHalf = SumOfDigits(secondHalf);

            return sumFirstHalf - sumSecondHalf;
        }

        static int SumOfDigits(int number)
        {
            int sum = 0;
            while (number > 0)
            {
                sum += number % 10;
                number /= 10;
            }
            return sum;
        }




    }
}
