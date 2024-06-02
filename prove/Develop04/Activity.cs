using System;
using System.Collections.Generic;
using System.Threading;

namespace Develop04
{
    public class Activity
    {
        protected string _name;
        protected string _description;
        protected int _duration;

        public Activity(string name, string description)
        {
            _name = name;
            _description = description;
        }
        
        public void DisplayStartingMessage()
        {
            Console.WriteLine($"Starting: {_name}");
            Console.WriteLine(_description);
            Console.Write("How long, in seconds, would you like for your session? ");
            string input = Console.ReadLine();
            _duration = int.Parse(input);
            Console.WriteLine("Get ready...");
            ShowSpinner(3);
        }

        public void DisplayEndingMessage()
        {
            Console.WriteLine("Well done!");
            Console.WriteLine($"You have completed the {_name} activity for {_duration} seconds.");
            ShowSpinner(3);
        }

        public void ShowSpinner(int seconds)
        {
            for (int i = 0; i < seconds; i++)
            {
                Console.Write("/");
                Thread.Sleep(250);
                Console.Write("\b\b");
                Console.Write("-");
                Thread.Sleep(250);
                Console.Write("\b\b");
                Console.Write("\\");
                Thread.Sleep(250);
                Console.Write("\b\b");
                Console.Write("|");
                Thread.Sleep(250);
                Console.Write("\b\b");
            }
            Console.WriteLine();
        }

        public void ShowCountDown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.WriteLine(i);
                Thread.Sleep(1000);
            }
        }
    }
}