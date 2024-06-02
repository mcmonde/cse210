using System;

namespace Develop04
{
    public class ListingActivity: Activity
    {
        private List<string> _prompts;
        private Random _random;
        private List<string> _responses;

        public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
        {
            _prompts = new List<string>
            {
                "Who are people that you appreciate?",
                "What are personal strengths of yours?",
                "Who are people that you have helped this week?",
                "When have you felt the Holy Ghost this month?",
                "Who are some of your personal heroes?"
            };

            _random = new Random();
            _responses = new List<string>();
        }
        public void Run()
        {
            DisplayStartingMessage();
            string prompt = GetRandomPrompt();
            Console.WriteLine(prompt);
            Console.WriteLine("You have a few seconds to think about your prompt...");
            ShowSpinner(5);

            Console.WriteLine("Start listing items:");
            DateTime endTime = DateTime.Now.AddSeconds(_duration);
            while (DateTime.Now < endTime)
            {
                string response = Console.ReadLine();
                _responses.Add(response);
            }

            Console.WriteLine($"You listed {_responses.Count} items.");
            DisplayEndingMessage();
        }

        private string GetRandomPrompt()
        {
            int index = _random.Next(_prompts.Count);
            return _prompts[index];
        }

        public string GetListFromUser()
        {
            return "a List<string> here";
        }
    }
}