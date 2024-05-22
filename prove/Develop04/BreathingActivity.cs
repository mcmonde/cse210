using System;

namespace Develop04
{
    public class BreathingActivity : Activity
    {

        public BreathingActivity(string name, string description): base(name, description)
        {
            _name = name;
            _description = description;
        }
        public void Run()
        {
            Console.Write("How long, in seconds, would you like for your session? ");
            string input = Console.ReadLine();
            _duration = int.Parse(input);
        }
    }
}