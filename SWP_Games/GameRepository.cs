using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace SWP_Games
{
    public class GameRepository
    {
        private readonly ICollection<Game> games;
        private readonly string filename = "games.json";

        public GameRepository()
        {
            games = LoadData();
            if (games == null)
            {
                games = new List<Game>();
                SaveData();
            }
        }



        public void Add(Game game)
        {
            games.Add(game);
            SaveData();
        }

        public void Update(Game game)
        {
            SaveData();
        }

        public bool Delete(Game game)
        {
            var @return = games.Remove(game);
            SaveData();
            return @return;
        }

        public long Count()
        {
            return games.Count;
        }

        public Game FindById(int id)
        {
            return games.FirstOrDefault(w => w.Id == id);
        }

        public void Save()
        {
            SaveData();
        }

        private void SaveData()
        {
            var data = JsonConvert.SerializeObject(games);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), filename);
            File.WriteAllText(filePath, data);
           
        }

        private ICollection<Game> LoadData()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), filename);
            if (!File.Exists(filePath)) return null;
            var jsonData = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<Game>>(jsonData);
        }
    }
}