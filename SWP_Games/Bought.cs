using System;
using System.Threading;

namespace SWP_Games
{
    public class Bought : BaseState, ICommand
    {
    private readonly Game owner;
        public Bought(Game owner) : base(owner)
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
            Console.WriteLine("Game is not installed, you cant start it without installing it.");
        }

        public void Close()
        {
            Console.WriteLine("Game is not installed, you cant stop it without installing it.");
        }

        public void Remove()
        {
            Console.WriteLine("Game is not installed, you cant remove it without installing it.");

        }

        public void Update()
        {
            Console.WriteLine("Game is not installed, you cant update it without installing it.");

        }
    }
}