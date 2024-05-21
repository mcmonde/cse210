using System;

namespace Develop04
{
    public class BreathingActivity : Activity
    {

        public BreathingActivity(string name, string description, int duration): base(name,description)
        {
            _name = name;
            _description = description;
        }
        public void Run()
        {
            
        }
    }
}