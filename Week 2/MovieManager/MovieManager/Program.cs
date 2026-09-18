namespace MovieManager
{
    internal class Program
    {
        List<Movie> movieList = new List<Movie>();
        static void Main(string[] args)
        {
            Program app = new Program();
            app.GetMovies();
        }

        public void GetMovies()
        {
            while (true)
            {
                Console.Write($"Add meg a film címét: ");
                string name = Console.ReadLine();
                Console.Write($"Add meg a film Hosszát: ");
                int length = Convert.ToInt32( Console.ReadLine() );
                Console.Write($"Add meg a film Megjelenési évét(1999,2005 stb): ");
                int release = Convert.ToInt32( Console.ReadLine() );

                movieList.Add(new Movie(name, length, release));

                Console.Write("Szeretnél még filmet felvinni?: ");
                string command = Console.ReadLine();
                if (command == "nem")
                {
                    return;
                }
            }
        }
    }
}
