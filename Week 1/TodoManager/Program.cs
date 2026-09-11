namespace TodoManager
{
    internal class Program
    {
        List<Todo> TodoLista = new List<Todo>();
        static void Main(string[] args)
        {
            Program app = new Program();
            app.StartManager();
        }

        public void StartManager()
        {
            while (true)
            {
                string command = Console.ReadLine().ToLower();
                switch (command)
                {
                    case "list":
                        ListTodos();
                        break;
                    case "add":
                        GetTodoData();
                        break;
                    case "remove":
                        RemoveTodo();
                        break;
                }

            }
        }

        public void AddTodo(string name, string desc, int importance)
        {
            TodoLista.Add(new Todo(name, desc, importance));
        }

        public void GetTodoData()
        {
            Console.Write("Add meg a nevet: ");
            string name = Console.ReadLine();
            Console.Write("Add meg a leirast: ");
            string desc = Console.ReadLine();
            Console.Write("Add meg a fontossagot");
            int imp = Convert.ToInt32(Console.ReadLine());

            AddTodo(name, desc, imp);
            Console.WriteLine("Sikeresen Hozzaadva!");
        }


        public void ListTodos()
        {
            Console.WriteLine("ID || Name || Desc || Importance");
            for (int i = 0; i < TodoLista.Count; i++)
            {
                Console.WriteLine($"{i + 1} || {TodoLista[i].Name} || {TodoLista[i].Desc} || {TodoLista[i].Importance}");
            }
        }

        public void RemoveTodo()
        {
            Console.WriteLine("Add meg az eltavolitani kivant ToDo ID-jat");
            int ID = Convert.ToInt32(Console.ReadLine());
            TodoLista.Remove(TodoLista[ID - 1]);
            Console.WriteLine("Sikeresen Eltavolitva!");
        }
    }
}
