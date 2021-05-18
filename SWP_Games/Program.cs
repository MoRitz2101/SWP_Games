using System;
using System.Linq;

namespace SWP_Games
{
    class Program
    {
        static void Main(string[] args)
        {
            var gamemRepository = new GameRepository();
            Game.Init(gamemRepository);
            string title = null, desc = null;
            PrintUsage();
            while (true)
            {
                string input = Console.ReadLine();
                var inputArray = input.Split(" ");
                string command;
                int id;
                try
                {
                    command = inputArray[0].ToLower();
                    id = int.Parse(inputArray[1]);

                    if (inputArray.Count() > 2)
                    {
                        title = inputArray[2];
                        desc = inputArray[3];
                    }
                }
                catch (Exception)
                {
                    PrintUsage();
                    return;
                }

                try
                {
                    Game game;
                    switch (command)
                    {
                        case "buy":
                            game = Game.Buy(id);
                            game.Edit(title, desc);
                            game.Print();
                            break;

                        case "edit":
                            game = Game.FindById(id);
                            game.Edit(title, desc);
                            game.Print();
                            break;

                        case "install":
                            game = Game.FindById(id);
                            game.Install();
                            break;

                        case "start":
                            game = Game.FindById(id);
                            game.Start();
                            break;

                        case "close":
                            game = Game.FindById(id);
                            game.Close();
                            break;

                        case "delete":
                            game = Game.FindById(id);
                            game.Delete();
                            break;

                        case "print":
                            game = Game.FindById(id);
                            if(game != null)
                            game.Print();
                            else
                            Console.WriteLine("No Game with ID");
                            break;
                        case "update":
                            game = Game.FindById(id);
                            game.Update();
                            break;
                    }

                    gamemRepository.Save();
                }
                catch (Exception)
                {
                    PrintUsage();
                }
            }
            
        }

        private static void PrintUsage()
        {
            Console.WriteLine("buy   [id] [title] [description]");
            Console.WriteLine("edit   [id] [title] [description]");
            Console.WriteLine("install  [id]");
            Console.WriteLine("start    [id]");
            Console.WriteLine("close   [id]");
            Console.WriteLine("print    [id]");
            Console.WriteLine("delete   [id]");
            Console.WriteLine("update    [id]");
        }
    }
}

