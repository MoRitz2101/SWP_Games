using System;

namespace SWP_Games
{
    public class Closed: BaseState, ICommand
    {
        private readonly Game owner;
        public Closed(Game owner) : base(owner)
        {
            this.owner = owner;
        }

        public void Install()
        {
            Console.WriteLine("Game is only installed, you need to start it before you close it.");

        }

        public void Start()
        {
            owner.State = StateEnum.Started;
            Console.WriteLine("STARTED");
        }

        public void Close()
        {
            Console.WriteLine("Game is already closed.");
        }

        public void Remove()
        {
            owner.State = StateEnum.Removed;
            Console.WriteLine("REMOVED");
        }

        public void Update()
        {
            owner.State = StateEnum.Updated;
            Console.WriteLine("Updated");
        }
    }
}