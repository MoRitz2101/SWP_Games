using System;

namespace SWP_Games
{
    public abstract class BaseState
    {
        private Game owner;
        public BaseState(Game owner)
        {
            this.owner = owner;
        }

        public void Print()
        {
            Console.WriteLine($"Id: {owner.Id}");
            Console.WriteLine($"Title: {owner.Title}");
            Console.WriteLine($"State: {owner.State}");
            Console.WriteLine($"Description: {owner.Description}");
        }
    }
}