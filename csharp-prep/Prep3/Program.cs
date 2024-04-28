using System;

class Program
{
    static void Main(string[] args)
    {
        bool playAgain = true;

        while (playAgain) 
        {
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101);

            int guess = -1;
            int guesses = 0;
            
            // just to know what really is the magic number
            // Console.WriteLine($"{magicNumber}");  
            
            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                guesses++;

                if (magicNumber > guess) {
                    Console.WriteLine("Higher");
                } else if (magicNumber < guess) {
                    Console.WriteLine("Lower");
                } else {
                    Console.WriteLine("You guessed it!");
                }
            }

            Console.WriteLine($"You made {guesses} guesses.");

            Console.Write("Do you want to play again? yes[1] no[any key]: ");
            string playAgainInput = Console.ReadLine();
            playAgain = playAgainInput == "1";
        }
        
        Console.WriteLine($"Thank you for playing!");
    }
}