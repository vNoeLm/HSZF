namespace ClassTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new MoveiDBContext();

            var movieQuerry = from m in context.Movie select new
            {
                Title = m.Title,
                Year = m.ReleasedAt.Year,
                DircetorName = m.Director.Name,
                Revenue = m.Revenue,
                Rating = m.Rating,
            };

            foreach (var item in movieQuerry)
            {
                Console.WriteLine($"{item.Title} ({item.Year}) - Rendező: {item.DircetorName} | Bevétel: ${item.Revenue}M | Értékelés: {item.Rating}");
            }
        }
    }
}
