namespace DbTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new WorkshopDBContext();

            var all = context.Registrations.Where(x => x.Score > 80).ToList();
        }
    }
}
