using System;

namespace SWP_Games
{
    public class Updated: BaseState, ICommand
    {
        private readonly Game owner;
        public Updated(Game owner) : base(owner)
        {
            this.owner = owner;
        }

        public void Install()
        {
            Console.WriteLine("Cant Install, Game is already installed.");
        }

        public void Start()
        {
            owner.State = StateEnum.Started;
            Console.WriteLine("STARTED");
        }

        public void Close()
        {
            Console.WriteLine("Game is already closed, because its updated.");
        }

        public void Remove()
        {
            Console.WriteLine("Removing game.....");
            owner.State = StateEnum.Removed;
            Console.WriteLine("Game is removed");
        }

        public void Update()
        {
            Console.WriteLine("Game is already updated.");
        }
    }
}