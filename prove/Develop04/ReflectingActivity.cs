using System;

namespace Develop04
{
    public class ReflectingActivity : Activity
    {
        private string _prompt;
        private string _question;

        public ReflectingActivity(string prompt, string question, string name, string description) : base(name,description)
        {
            _prompt = prompt;
            _question = question;

        }
        public void Run()
        {
            
        }

        public string GetRandomPrompt()
        {
            return "a random prompt";
        }

        public string GetRandomQuestion()
        {
            return "a random question";
        }

        public void DisplayPrompt()
        {
            
        }

        public void DisplayQuestions()
        {
            
        }
    }
}