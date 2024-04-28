using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade in percentage? ");
        string grade = Console.ReadLine();
        int percent = int.Parse(grade);

        string letter = "";

        if (percent >= 90) {
            letter = "A";
        } else if (percent >= 80) {
            letter = "B";
        } else if (percent >= 70) {
            letter = "C";
        } else if (percent >= 60) {
            letter = "D";
        } else {
            letter = "F";
        }

        int lastDigit = percent % 10;
        string sign = "";

        if (percent >= 70 && percent < 100) {
            if (lastDigit >= 7) {
                sign = "+";
            } else if (lastDigit < 3) {
                sign = "-";
            }
        }

        if (letter == "A" && percent != 100) {
            if (percent >= 93) {
                sign = "";
            } else if (lastDigit < 3) {
                letter += "-";
                sign = "";
            } else if (lastDigit >= 7) {
                letter += "-";
            }
        } else if (letter == "F" && percent != 0) {
            if (lastDigit < 3 || lastDigit >= 7) {
                sign = "";
            }
        }

        Console.WriteLine($"Your grade is: {letter}{sign}");

        if (percent >= 70) {
            Console.WriteLine("You passed!");
        } else {
            Console.WriteLine("Better luck next time!");
        }
    }
}