using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SWP_Games;

namespace SWP_Games
{
    public enum StateEnum { Bought, Installed, Started, Closed , Removed, Updated }
    public class Game : ICommand
    {
        public static GameRepository GameRepository { get; set; }
        public static void Init(GameRepository gameRepository)
        {
            GameRepository = gameRepository;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public StateEnum State
        {
            get => state;
            set
            {
                state = value;
                switch (state)
                {
                    case StateEnum.Bought:
                        command = new Bought(this);
                        break;
                    case StateEnum.Installed:
                        command = new Installed(this);
                        break;
                    case StateEnum.Started:
                        command = new Started(this);
                        break;
                    case StateEnum.Closed:
                        command = new Closed(this);
                        break;
                    case StateEnum.Removed:
                        command = new Removed(this);
                        break;
                    case StateEnum.Updated:
                        command = new Updated(this);
                        break;
                }
            }
        }
        private ICommand command;
        private StateEnum state;


        public static Game FindById(int id)
        {
            return GameRepository.FindById(id);
        }

        public void Edit(string title, string description)
        {
            Title = title;
            Description = description;
        }
        public static Game Create(int id)
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
            command.Install();
        }

        public void Start()
        {
           command.Start();
        }

        public void Remove()
        {
            command.Remove();
        }

        public void Close()
        {
            command.Close();
        }


        public void Update()
        {
            command.Update();
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
