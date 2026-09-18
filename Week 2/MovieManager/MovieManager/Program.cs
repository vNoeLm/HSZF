using System.Text.Json;

namespace MovieManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MovieManager manager = new MovieManager();
            manager.CheckForMovies();
        }

    }
}
