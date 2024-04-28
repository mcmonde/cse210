using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        int input;
        do {
            Console.Write("Enter number: ");
            input = int.Parse(Console.ReadLine());

            if (input != 0)
            {
                numbers.Add(input);
            }
        } while (input != 0);

        if (numbers.Count == 0) {
            Console.WriteLine("No numbers were entered.");
            return;
        }

        int sum = 0;

        foreach (int num in numbers) {
            sum += num;
        }

        double average = (double)sum / numbers.Count;

        int max = numbers[0];

        foreach (int num in numbers) {
            if (num > max) {
                max = num;
            }
        }

        int minPositive = int.MaxValue;
        foreach (int num in numbers) {
            if (num > 0 && num < minPositive) {
                minPositive = num;
            }
        }

        numbers.Sort();

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");
        Console.WriteLine($"The smallest positive number is: {(minPositive == int.MaxValue ? "N/A" : minPositive.ToString())}");
        Console.WriteLine("The sorted list is:");

        foreach (int num in numbers) {
            Console.WriteLine(num);
        }
    }
}