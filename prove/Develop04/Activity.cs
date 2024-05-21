using System;

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
            Console.WriteLine(_name);
        }

        public void DisplayEndingMessage()
        {
            Console.WriteLine(_description);
        }

        public void ShowSpinner(int seconds)
        {
            
        }

        public void ShowCountDown(int seconds)
        {
            
        }
    }
}