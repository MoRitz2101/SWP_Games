using System;
using System.Buffers;

namespace SWP_Games
{
    public class Installed: BaseState, ICommand
    {
        private readonly Game owner;
        public Installed(Game owner) : base(owner)
        {
            this.owner = owner;
        }

        public void Install()
        {
            Console.WriteLine("Game is already installed.");

        }

        public void Start()
        {
            owner.State = StateEnum.Started;
            Console.WriteLine("STARTED");
        }

        public void Close()
        {
            Console.WriteLine("Game is not started, you cant close it without starting it.");
        }

        public void Remove()
        {
            owner.State = StateEnum.Removed;
            Console.WriteLine("REMOVED");
        }

        public void Update()
        {
            owner.State = StateEnum.Updated;
            Console.WriteLine("UPDATED");
        }
    }
}