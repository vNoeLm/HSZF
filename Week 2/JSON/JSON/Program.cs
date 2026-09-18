using System.Text.Json;

namespace JSON
{
    public class Animal
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Age { get; set; }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string json = File.ReadAllText("animals.json");

            List<Animal> animalsLista = JsonSerializer.Deserialize<List<Animal>>(json);

            string jsonSave = JsonSerializer.Serialize(animalsLista);
            File.WriteAllText("animalsSave.json",jsonSave);
        }
    }
}
