using System;

namespace Develop04
{
    public class BreathingActivity : Activity
    {

        public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
        {
        }
        public void Run()
        {
            // Console.Write("How long, in seconds, would you like for your session? ");
            // string input = Console.ReadLine();
            // _duration = int.Parse(input);
            // Console.WriteLine("Prepare to begin...");
            // ShowSpinner(3);
            
            DisplayStartingMessage();
            int totalDuration = _duration;
            while (totalDuration > 0)
            {
                Console.WriteLine("Breathe in...");
                ShowCountDown(3);
                Console.WriteLine("Breathe out...");
                ShowCountDown(3);
                totalDuration -= 6; // Each breathe in and out cycle takes 6 seconds
            }
            DisplayEndingMessage();
        }
    }
}