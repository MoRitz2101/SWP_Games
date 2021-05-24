using System;

namespace SWP_Games
{
    public class Started: BaseState, ICommand
    {
        private readonly Game owner;
        public Started(Game owner) : base(owner)
        {
            this.owner = owner;
        }

        public void Install()
        {
            Console.WriteLine("Cant install a game which is started.");

        }

        public void Start()
        {
            Console.WriteLine("Game is already started.");
        }

        public void Close()
        {
            owner.State = StateEnum.Closed;
            Console.WriteLine("CLOSED");
        }

        public void Remove()
        {
            Console.WriteLine("Game is started, cant remove it.");
        }

        public void Update()
        {
            Console.WriteLine("Game is started, cant update it.");
        }
    }
}
