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
        string[] commands = ["add","save","list","order","op","exit"];
        public void GetMovies()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("mit Szeretnel csinalni?: ");
                foreach (string com in commands)
                {
                    Console.WriteLine(com);
                }
               
                string command = Console.ReadLine();
                
                switch (command)
                {
                    case "add":
                        AddMovie();
                        break;
                    case "save":
                        SaveToJson();
                        WaitAndReturn();
                        break;
                    case "list":
                        ListMovies();
                        WaitAndReturn();
                        break;
                    case "order":
                        OrderMoviesByLength();
                        WaitAndReturn();
                        break;
                    case "op":
                        ExecuteOp();
                        WaitAndReturn();
                        break;
                    case "exit":
                        Environment.Exit(0);
                        break;
                }

            }
        }

        void WaitAndReturn()
        {
            Console.WriteLine("Nyomj meg egy gombot a visszalepeshez");
            Console.ReadKey();
        }

        public void AddMovie()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("Uj film hozzaadasa");
                Console.Write($"Add meg a film címét: ");
                string name = Console.ReadLine();
                Console.Write($"Add meg a film Hosszát: ");
                int length = Convert.ToInt32(Console.ReadLine());
                Console.Write($"Add meg a film Megjelenési évét(1999,2005 stb): ");
                int release = Convert.ToInt32(Console.ReadLine());

                movieList.Add(new Movie(name, length, release));

                Console.Write("Szeretnel meg filmet hozzaadni?: ");
                string command = Console.ReadLine();
                if (command != "igen")
                {
                    break;
                }
            }
        }
        public void SaveToJson()
        {
            string jsonSave = JsonSerializer.Serialize(movieList);
            File.WriteAllText("MoviesSaved.json", jsonSave);
            Console.WriteLine("Saved!");
        }

        public void CheckForMovies()
        {
            if (File.Exists("MoviesSaved.json"))
            {
                string json = File.ReadAllText("MoviesSaved.json");
                movieList = JsonSerializer.Deserialize<List<Movie>>(json);
                ListMovies();
                WaitAndReturn();
            }
            GetMovies();
        }

        public void ListMovies()
        {
            Console.Clear();
            Console.WriteLine("Jelenlegi Filmek: \nCím || Hossz || Megjelenés");
            foreach (Movie movie in movieList)
            {
                Console.WriteLine($"{movie.Title} || {movie.Length} || {movie.ReleaseDate}");
            }
        }

        public void OrderMoviesByLength()
        {
            movieList = movieList.OrderBy(x => x.Length).ToList();
            ListMovies();
        }

        public void ExecuteOp()
        {
            Console.Clear();
            Console.WriteLine("2000 utáni filmek: ");
            foreach (var movie in movieList.Where(x => x.ReleaseDate > 2000))
            {
                Console.WriteLine(movie.Title);
            }
            Console.WriteLine();

            Console.WriteLine("2 Oranal hosszabb filmek: ");
            foreach (var movie in movieList.Where(x => x.Length > 120))
            {
                Console.WriteLine(movie.Title);
            }
            Console.WriteLine();

            if (movieList.Any(x => x.Length < 60))
            {
                Console.WriteLine("Van 1 oranal rovidebb film");
            }
            else
            {
                Console.WriteLine("Nincs 1 oranal rovidebb film");
            }
            Console.WriteLine();

            if (movieList.All(x => x.Length > 30))
            {
                Console.WriteLine("Fel oranal minden film hosszabb");
            }
            else
            {
                Console.WriteLine("Fel oranal nem minden film hosszabb");
            }

            var firstLongRecentMovie = movieList.FirstOrDefault(x => x.ReleaseDate > 2000 && x.Length > 120);
            if (firstLongRecentMovie != null)
            {
                Console.WriteLine($"Az első 2000 utani 2 oranal hosszabb film: {firstLongRecentMovie.Title} ({firstLongRecentMovie.ReleaseDate}, {firstLongRecentMovie.Length} perc)");
            }
            else
            {
                Console.WriteLine("Nincs olyan film a listaban amely 2000 utan jelent meg es hosszabb 2 oranal.");
            }
        }
    }
}
