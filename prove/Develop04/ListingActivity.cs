using System;

namespace Develop04
{
    public class ListingActivity
    {
        protected int _count;
        protected List<string> _list;

        // public ListingActivity()
        // {
        //     
        // }
        public void Run()
        {
            
        }

        public string GetRandomPrompt()
        {
            return "a random prompt here";
        }

        public string GetListFromUser()
        {
            return "a List<string> here";
        }
    }
}