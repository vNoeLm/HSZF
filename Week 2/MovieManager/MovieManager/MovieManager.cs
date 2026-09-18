using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MovieManager
{
    internal class MovieManager
    {
        List<Movie> movieList = new List<Movie>();
        public void GetMovies()
        {
            while (true)
            {
                Console.Write("Szeretnél filmet felvinni?: ");
                string command = Console.ReadLine();
                
                switch (command)
                {
                    case "igen":
                        AddMovie();
                        break;
                    case "nem":
                        SaveToJson();
                        return;
                }

            }
        }

        public void AddMovie()
        {
            Console.Write($"Add meg a film címét: ");
            string name = Console.ReadLine();
            Console.Write($"Add meg a film Hosszát: ");
            int length = Convert.ToInt32(Console.ReadLine());
            Console.Write($"Add meg a film Megjelenési évét(1999,2005 stb): ");
            int release = Convert.ToInt32(Console.ReadLine());

            movieList.Add(new Movie(name, length, release));
        }
        public void SaveToJson()
        {
            string jsonSave = JsonSerializer.Serialize(movieList);
            File.WriteAllText("MoviesSaved.json", jsonSave);
        }

        public void CheckForMovies()
        {
            if (File.Exists("MoviesSaved.json"))
            {
                Console.WriteLine("Jelenlegi Filmek: \nCím || Hossz || Megjelenés");
                string json = File.ReadAllText("MoviesSaved.json");
                movieList = JsonSerializer.Deserialize<List<Movie>>(json);
                foreach (Movie movie in movieList)
                {
                    Console.WriteLine($"{movie.Title} || {movie.Length} || {movie.ReleaseDate}");
                }
            }
            GetMovies();
        }
    }
}
