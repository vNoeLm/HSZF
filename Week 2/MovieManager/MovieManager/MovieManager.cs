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
                OrderMoviesByLength();
                Console.WriteLine("Jelenlegi Filmek(Hossz szerint novekv!): \nCím || Hossz || Megjelenés");
                string json = File.ReadAllText("MoviesSaved.json");
                movieList = JsonSerializer.Deserialize<List<Movie>>(json);
                foreach (Movie movie in movieList)
                {
                    Console.WriteLine($"{movie.Title} || {movie.Length} || {movie.ReleaseDate}");
                }

                MoviesAfter2000();
                MoviesLongerThan2Hours();
                IsThereShortMovie();
                AllLongerThanHalfHour();

            }
            GetMovies();
        }

        public void OrderMoviesByLength()
        {
            movieList.OrderBy(x => x.Length);
        }

        public void MoviesAfter2000()
        {
            var lista = movieList.Where(x => x.ReleaseDate > 2000);
            Console.WriteLine("2000 utáni filmek: ");
            foreach (Movie movie in lista)
            {
                Console.WriteLine($"{movie.Title}");
            }
        }

        public void MoviesLongerThan2Hours()
        {
            var lista = movieList.Where(x => (x.Length / 60) > 2);
            Console.WriteLine("2 Oranal hosszabb filmek: ");
            foreach (Movie movie in lista)
            {
                Console.WriteLine($"{movie.Title}");
            }
        }

        public void IsThereShortMovie()
        {
            if (movieList.Any(x => (x.Length / 60) < 1))
            {
                Console.WriteLine("Van 1 oranal rovidebb film");
            }
            else
            {
                Console.WriteLine("Nincs 1 oranal rovidebb film");
            }
            
        }

        public void AllLongerThanHalfHour()
        {
            if (movieList.All(x => x.Length > 30))
            {
                Console.WriteLine("Fel oranal minden film hosszabb");
            }
            else
            {
                Console.WriteLine("Fel oranal nem minden film hosszabb");
            }
        }
    }
}
