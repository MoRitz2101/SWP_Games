using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWP_Games
{
    public enum StateEnum { Bought, Installed, Started, Closed , Removed, Updated }
    public class Game
    {
        public static GameRepository GameRepository { get; set; }
        public static void Init(GameRepository gameRepository)
        {
            GameRepository = gameRepository;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public StateEnum State { get; set; }
      

        public static Game FindById(int id)
        {
            return GameRepository.FindById(id);
        }

        public void Edit(string title, string description)
        {
            Title = title;
            Description = description;
        }
        public static Game Buy(int id)
        {
            var game = new Game()
            {
                Id = id,
                State = StateEnum.Bought
            };
            GameRepository.Add(game);
            return game;
        }
        public void Install()
        {
            switch (State)
            {
                case StateEnum.Bought:
                    this.State = StateEnum.Installed;
                    Console.WriteLine("Game was installed sucesfully.");
                    break;
                case StateEnum.Installed:
                    Console.WriteLine("Game is already installed.");
                    break;
                case StateEnum.Started:
                    Console.WriteLine("Game is started, you cant install it.");
                    break;
                case StateEnum.Closed:
                    Console.WriteLine("Game is closed, you cant install it");
                    break;
                case StateEnum.Removed:
                    this.State = StateEnum.Installed;
                    Console.WriteLine("Game was installed sucesfully.");
                    break;
                case StateEnum.Updated:
                    Console.WriteLine("Game is already installed.");
                    break;
            }
        }

        public void Start()
        {
            switch (State)
            {
                case StateEnum.Bought:
                    Console.WriteLine("Game is in bought state and cannot be directly started install it first.");
                    break;
                case StateEnum.Installed:
                    this.State = StateEnum.Started;
                    Console.WriteLine("Game was started sucesfully.");
                    break;
                case StateEnum.Started:
                    Console.WriteLine("Game is already started.");
                    break;
                case StateEnum.Closed:
                    this.State = StateEnum.Started;
                    Console.WriteLine("Game was started sucesfully.");
                    break;
                case StateEnum.Removed:
                    Console.WriteLine("Game is not installed please install it.");
                    break;
                case StateEnum.Updated:
                    this.State = StateEnum.Started;
                    Console.WriteLine("Game was started sucesfully.");
                    break;
            }
        }

        public void Delete()
        {
            switch (State)
            {
                case StateEnum.Bought:
                    Console.WriteLine("Game is not installed, so it cant be deleted.");
                    break;
                case StateEnum.Installed:
                    this.State = StateEnum.Removed;
                    Console.WriteLine("Game was removed sucesfully.");
                    break;
                case StateEnum.Started:
                    Console.WriteLine("Game is already started and cannot be deleted.");
                    break;
                case StateEnum.Closed:
                    this.State = StateEnum.Removed;
                    Console.WriteLine("Game was removed sucesfully.");
                    break;
                case StateEnum.Removed:
                    Console.WriteLine("Game is already removed.");
                    break;
                case StateEnum.Updated:
                    this.State = StateEnum.Removed;
                    Console.WriteLine("Game was removed sucesfully.");
                    break;
            }
        }

        public void Close()
        {
            switch (State)
            {
                case StateEnum.Bought:
                    Console.WriteLine("Game is in bought state and cannot be closed.");
                    break;
                case StateEnum.Installed:
                    Console.WriteLine("Game is already closed.");
                    break;
                case StateEnum.Started:
                    this.State = StateEnum.Closed;
                    Console.WriteLine("Game was closed sucesfully.");
                    break;
                case StateEnum.Closed:
                    Console.WriteLine("Game is already closed.");
                    break;
                case StateEnum.Removed:
                    Console.WriteLine("Game is removed cannot close it.");
                    break;
                case StateEnum.Updated:
                    Console.WriteLine("Game is updated cannot close it.");
                    break;
            }
        }
        public void Update()
        {
            switch (State)
            {
                case StateEnum.Bought:
                    Console.WriteLine("Game is in bought state and cannot be updated, install it first.");
                    break;
                case StateEnum.Installed:
                    this.State = StateEnum.Updated;
                    Console.WriteLine("Game was updated sucesfully.");
                    break;
                case StateEnum.Started:
                    Console.WriteLine("Game is already running, please close before updating.");
                    break;
                case StateEnum.Closed:
                    this.State = StateEnum.Updated;
                    Console.WriteLine("Game was updated sucesfully.");
                    break;
                case StateEnum.Removed:
                    Console.WriteLine("Game is removed please install to update it.");
                    break;
                case StateEnum.Updated:
                    Console.WriteLine("Game is updated already.");
                    break;
            }
        }

        public void Print()
        {
            Console.WriteLine($"Id: {Id}");
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"State: {State}");
            Console.WriteLine($"Description: {Description}");

        }
    }
}
