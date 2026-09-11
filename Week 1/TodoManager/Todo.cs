using System;
using System.Collections.Generic;
using System.Text;

namespace TodoManager
{
    internal class Todo
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public int Importance { get; set; }
        public Todo(string name, string desc, int importance)
        {
            this.Name = name;
            this.Desc = desc;
            this.Importance = importance;
        }
    }
}
