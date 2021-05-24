using System;

namespace SWP_Games
{
    public class Removed: BaseState, ICommand
    {

        private readonly Game owner;
        public Removed(Game owner) : base(owner)
        {
            this.owner = owner;
        }

        public void Install()
        {
            Console.WriteLine("Game is installing.....");
            owner.State = StateEnum.Installed;
            Console.WriteLine("Game is installed");

        }

        public void Start()
        {
            Console.WriteLine("Cant start a game which is removed.");
        }

        public void Close()
        {
            Console.WriteLine("Game is removed, cant close it.");
        }

        public void Remove()
        {
            Console.WriteLine("Game is already removed.");
        }

        public void Update()
        {
            Console.WriteLine("Game is removed, cant update it.");
        }
    }
}
